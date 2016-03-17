using System;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;
using System.Collections;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class StandardInterfacesImplementation : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Implementation of standard interfaces like IComparable, IEnumerable, IDisposable and IUnknown");
        }

        public void MainMethod()
        {
            IComparableImplementationExample();
            IEnumerableImplementationExample();
            IDisposableImplementationExample();
            IUnknownImplementationExample();
        }

        private void IComparableImplementationExample()
        {
            Console.WriteLine("Interface IComparable Implementation");
            Console.WriteLine("It is used to sort elements");
            Console.WriteLine("The CompareTo method returns an int value that shows how two elements are related");
            Console.WriteLine("<0 : current object precedes the object specified by CompareTo method in sort order");
            Console.WriteLine("=0 : current object occurs in the same position in sort as the Object specifed by CompareTo method");
            Console.WriteLine(">0 : current instance follows the object specified by CompareTo method in sort order");

            List<Order> orders = new List<Order>()
            {
                new Order {Created = new DateTime(2012,12,2) },
                new Order {Created = new DateTime(2012,1,6) },
                new Order {Created = new DateTime(2012,7,8) },
                new Order {Created = new DateTime(2012,2,20) }
            };

            orders.Sort();
        }

        private void IEnumerableImplementationExample()
        {
            Console.WriteLine("Implementing IEnumerable Interface");
            Console.WriteLine("IEnumeranble and IEnumerator pattern helps to implement iterator pattern.");
            Console.Write("IEnumerable interface exposes GetEnumerator method that returns an enumerator.");
            Console.WriteLine("The enumerator has MoveNext method that returns the next item in iteration.");
            Console.Write("Yield is a special keyword that can be used only in context of iterators.");
            Console.WriteLine("It helps in tracking where you are in collection and it implements methods such as MoveNext and Current");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            //using (IEnumerator<int> enumerator = numbers.GetEnumerator())
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }

            Person[] persons = new Person[]
            {
                new Person("Mayank","Aggarwal"),
                new Person("A","B"),
                new Person("C","D"),
                new Person("E","F"),
                new Person("G","H"),
        };
            People people = new People(persons);
            using (IEnumerator<Person> enumerator = people.GetEnumerator())
                {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current.ToString());
            }



        }

        private void IDisposableImplementationExample()
        {
            Console.WriteLine("Implementation of IDisposable Interface");
            Console.WriteLine("IDisposable is used to facilitate working with external and unmanaged resources");
            Console.WriteLine("Not Implemented------------------------------------");
        }

        private void IUnknownImplementationExample()
        {
            Console.WriteLine("Implemention of IUnknown Interface");
            Console.WriteLine("Not Implemented---------------------------");
        }

        class Order : IComparable
        {
            public DateTime Created { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null)
                    return 1;

                Order o = obj as Order;
                if (o == null)
                    throw new ArgumentException("Object is not an Order");

                return this.Created.CompareTo(o.Created);
            }
        }

        class Person
        {
            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            public string FirstName { get; private set; }
            public string LastName { get; private set; }

            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        class People : IEnumerable<Person>
        {
            private Person[] people;

            public People(Person[] people)
            {
                this.people = people;
            }

            public IEnumerator<Person> GetEnumerator()
            {
                for (int index = 0; index < people.Length; index++)
                {
                    yield return people[index];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}