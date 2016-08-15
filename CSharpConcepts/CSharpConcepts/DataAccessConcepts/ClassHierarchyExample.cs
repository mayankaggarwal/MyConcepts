using System;
using System.Collections;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class ClassHierarchyExample : IMainMethod
    {
        public void MainMethod()
        {
            throw new NotImplementedException();
        }

        public void SummaryMethod()
        {
            throw new NotImplementedException();
        }

        public class TreeNode : IEnumerable<TreeNode>
        {
            public IEnumerator<TreeNode> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public class TreeEnumerator : System.Collections.Generic.IEnumerator<TreeNode>
        {
            public TreeNode Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

    }


}