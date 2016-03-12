using System;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;

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
    }
}