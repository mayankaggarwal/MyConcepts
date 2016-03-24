using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.SecurityConcepts
{
    public class ConceptSelectionClass:ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch((SecurityConcepts)concept)
            {
                case SecurityConcepts.SymmetricAESAlogorithmExample:
                    conceptExecutionClass = new SymmetricAESAlogorithmExample();
                    break;
                case SecurityConcepts.HashingExample:
                    conceptExecutionClass = new SplittingDataUsingHashing();
                    break;
                case SecurityConcepts.DigitalCertificateImplementationExample:
                    conceptExecutionClass = new DigitalCertificateExample();
                    break;
                case SecurityConcepts.CodeAccessPermissionExample:
                    conceptExecutionClass = new CASExample();
                    break;
                case SecurityConcepts.SecureStringExample:
                    conceptExecutionClass = new SecureStringExamples();
                    break;
            }
        }
    }

    public enum SecurityConcepts
    {
        SymmetricAESAlogorithmExample,
        HashingExample,
        DigitalCertificateImplementationExample,
        CodeAccessPermissionExample,
        SecureStringExample
    }
}
