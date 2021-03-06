﻿using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ImplementExceptionHandling
{
    public class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((ExceptionsConceptList)concept)
            {
                case ExceptionsConceptList.ParsingInvalidNumberExceptionEg:
                    conceptExecutionClass = new BasicExceptionExample1();
                    break;
            }
        }
    }

    public enum ExceptionsConceptList
    {
        ParsingInvalidNumberExceptionEg
    }
}
