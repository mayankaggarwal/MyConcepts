using System;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace CSharpConcepts.SecurityConcepts
{
    internal class SplittingDataUsingHashing : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Hashing Example for storing and retreiving data fast");
        }

        public void MainMethod()
        {
            SetImplementation();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            HashCodeUsingSHA256();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }

        private void SetImplementation()
        {
            Console.WriteLine("Implemented set operation with HashCode");
            Set<int> setList = new Set<int>();
            setList.Insert(56);
            setList.Insert(44);
            setList.Insert(102);
            setList.Insert(10000056);
            setList.Insert(-12345);
            setList.Insert(44);
            if (setList.Contains(102))
                Console.WriteLine("102 is present");
            else
                Console.WriteLine("102 is absent");
            if (setList.Contains(11))
                Console.WriteLine("11 is present");
            else
                Console.WriteLine("11 is absent");
        }

        private void HashCodeUsingSHA256()
        {
            Console.WriteLine("Using SHA256 hashing algorithm");
            UnicodeEncoding encoder = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();
            string data = "A paragraph of text";
            byte[] hashA = sha256.ComputeHash(encoder.GetBytes(data));

            string data1 = "A paragraph of changed text";
            byte[] hashB = sha256.ComputeHash(encoder.GetBytes(data1));

            string data2 = "A paragraph of text";
            byte[] hashC = sha256.ComputeHash(encoder.GetBytes(data2));

            Console.WriteLine("Check if {0} and {1} are equal :{2}",data,data1,hashA.SequenceEqual(hashB));
            Console.WriteLine("Check if {0} and {1} are equal :{2}", data, data2, hashA.SequenceEqual(hashC));
        }

        class Set<T>
        {
            private List<T>[] buckets = new List<T>[100];

            public void Insert(T item)
            {
                int bucket = GetBucket(item.GetHashCode());
                if (Contains(item, bucket))
                    return;
                if (buckets[bucket] == null)
                    buckets[bucket] = new List<T>();
                buckets[bucket].Add(item);
            }

            public bool Contains(T item)
            {
                return Contains(item, GetBucket(item.GetHashCode()));
            }

            private bool Contains(T item, int bucket)
            {
                if(buckets[bucket]!=null)
                {
                    foreach(T member in buckets[bucket])
                    {
                        if (member.Equals(item))
                            return true;
                    }
                }

                return false;
            }

            private int GetBucket(int hashcode)
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }
    }
}