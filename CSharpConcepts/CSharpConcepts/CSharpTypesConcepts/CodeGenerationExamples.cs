using System;
using CSharpConcepts.Interfaces;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class CodeGenerationExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("CodeDom Examples");
        }

        public void MainMethod()
        {
            Console.WriteLine("Hello World Code Generation");
            GenerateFile();
        }

        private CodeCompileUnit GenerateHelloWorldCode()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNameSpace = new CodeNamespace("MyNamespace");
            myNameSpace.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello World!"));

            compileUnit.Namespaces.Add(myNameSpace);
            myNameSpace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);

            return compileUnit;

        }

        private void GenerateFile()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(GenerateHelloWorldCode(), tw, new CodeGeneratorOptions());
                tw.Close();

            }
        }
    }
}