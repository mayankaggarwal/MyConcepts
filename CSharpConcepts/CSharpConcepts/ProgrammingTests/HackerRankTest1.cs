using System;
using CSharpConcepts.Interfaces;

namespace CSharpConcepts.ProgrammingTests
{
    internal class HackerRankTest1 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Not Implemented");
        }
        public void MainMethod()
        {
            //AlgoMethod();
        }

        private void AlgoMethod()
        {
            int length = 10;
            string mainString = "aabbbabbab";
            int num = 10;

            for (int i = 0; i < num; i++)
            {
                string query = Console.ReadLine();
                string[] qparams = query.Split(' ');
                switch (qparams[0].ToString())
                {
                    case "C":
                        TransFormForC(mainString, GetInt(qparams[1]), GetInt(qparams[2]), qparams[3]);
                        break;
                    case "S":
                        TransFormForS(mainString, GetInt(qparams[1]), GetInt(qparams[2]), GetInt(qparams[3]), GetInt(qparams[4]));
                        break;
                    case "R":
                        TransFormForR(mainString, GetInt(qparams[1]), GetInt(qparams[2]));
                        break;
                    case "W":
                        TransFormForW(mainString, GetInt(qparams[1]), GetInt(qparams[2]));
                        break;
                    case "H":
                        TransFormForH(mainString, GetInt(qparams[1]), GetInt(qparams[2]), GetInt(qparams[3]));
                        break;
                }
            }

        }

        private void TransFormForH(string mainString, int v1, int v2, int v3)
        {
            string s1 = mainString.Substring(v1 - 1, v3);
            string s2 = mainString.Substring(v2 - 1, v3);
            int hammingDistance = HammingDistance(s1, s2);
            Console.WriteLine(hammingDistance);
        }

        private void TransFormForW(string mainString, int v1, int v2)
        {
            Console.WriteLine(mainString.Substring(v1 - 1, v2 - v1 + 1));
        }

        private void TransFormForR(string mainString, int v1, int v2)
        {
            mainString = mainString.Substring(0, v1 - 2);
        }

        private void TransFormForS(string mainString, int v1, int v2, int v3, int v4)
        {
            throw new NotImplementedException();
        }

        private void TransFormForC(string mainString, int v1, int v2, string v3)
        {
            throw new NotImplementedException();
        }

        private int HammingDistance(string s1, string s2)
        {
            throw new NotImplementedException();
        }

        private int GetInt(string v)
        {
            int result;
            Int32.TryParse(v, out result);
            return result;
        }
    }
}