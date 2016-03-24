using System;
using CSharpConcepts.Interfaces;
using System.Security.Permissions;
using System.Security;

namespace CSharpConcepts.SecurityConcepts
{
    internal class CASExample : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Code Access Permission Examples:");
        }

        public void MainMethod()
        {
            CASDeclerativeExample();
            CASImerativeExample();

        }

        [FileIOPermission(SecurityAction.Demand,AllFiles = FileIOPermissionAccess.Read)]
        private void CASDeclerativeExample()
        {
            Console.WriteLine("Example of Declerative approach");
            Console.WriteLine("Method with attribute FileIOPermission");
        }

        private void CASImerativeExample()
        {
            Console.WriteLine("Example of Imperative approach");
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch(SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}