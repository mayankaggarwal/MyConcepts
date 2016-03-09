using System;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConcepts.EventsAndCallbacks
{
    internal class EventUsingAction : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Evolution of Event from Action to EventHandler");
        }

        public void MainMethod()
        {
            EventUsingActionExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            DecoratingActionWithEvent();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingEventHandlerDelegateWithEvent();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingEventHandlerWithEventArgs();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            EventsWithExceptions();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            EventsWithExceptionHandling();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }



        private void EventUsingActionExample()
        {
            Console.WriteLine("Implementing publish subscribe using Action");
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised from method 1");
            p.OnChange += () => Console.WriteLine("Event raised from method 2");
            //p.OnChange();
            Console.WriteLine("On Change can be called from the subscriber"); 
            p.Raise();
            Console.WriteLine("Problem with above implementation is:");
            Console.WriteLine("Any subscriber can remove handlers by using = instead of +=");
            Console.WriteLine("Ideally Pub class should raise the event but using above approach other users can also raise the event");
        }

        public class Pub
        {
            public Action OnChange { get; set; }

            public void Raise()
            {
                if (OnChange != null)
                {
                    OnChange();
                }
            }
        }

        private void DecoratingActionWithEvent()
        {
            Console.WriteLine("Decorating Action with event attribute");
            Pub1 pub = new Pub1();
            pub.OnChange += () => Console.WriteLine("Called from method 1");
            pub.OnChange += () => Console.WriteLine("Called from method 2");
            //p.OnChange();
            Console.WriteLine("On Change cannot be called from the subscriber");
            pub.Raise();
            Console.WriteLine("Changes happened with using event syntax:");
            Console.WriteLine("1:We are no longer using a public property but a public field which due to event syntax is protected by compiler from unwanted access");
            Console.WriteLine("2:Event cannot be assigned to = operator instead of +=");
            Console.WriteLine("3:No outside uers can raise the event");


        }

        public class Pub1
        {
            public event Action OnChange = delegate { };
            public void Raise()
            {
                OnChange();
            }
        }

        private void UsingEventHandlerDelegateWithEvent()
        {
            Console.WriteLine("Using Event Handler delegate instead of Action");
            Console.WriteLine("Event handler by default takes a sender object and some event arguments");
            Pub2 pub = new Pub2();
            pub.onChange += (sender, e) => Console.WriteLine("1st Event raised: {0} by :{1}", e, sender);
            pub.onChange += (sender, e) => Console.WriteLine("2nd Event raised: {0} by :{1}", e, sender);
            pub.Raise();
        }

        public class Pub2
        {
            public event EventHandler<int> onChange = delegate { };

            public void Raise()
            {
                onChange(this, 1);
            }
        }

        private void UsingEventHandlerWithEventArgs()
        {
            Console.WriteLine("Implementing Event Handler with Event Args, locking and event Property");
            Console.WriteLine("Type applied to Event handler need not extent EventArgs class");
            Pub3 pub = new Pub3();
            pub.OnChange += (sender, e) => Console.WriteLine("Event 1 raised:{0} by {1}", e.Value, sender);
            pub.OnChange += (sender, e) => Console.WriteLine("Event 2 raised:{0} by {1}", e.Value, sender);
            pub.Raise();
            Console.WriteLine("In above example a custom event accessor is used");
            Console.WriteLine("Custom event accessor is like property but it has add and remove blocks instead of get and set;");
        }

        public class Pub3
        {
            private event EventHandler<MyArgs> onChange = delegate { };
            public event EventHandler<MyArgs> OnChange
            {
                add
                {
                    lock (onChange)
                    {
                        onChange += value;
                    }
                }

                remove
                {
                    lock (onChange)
                    {
                        onChange -= value;
                    }
                }
            }

            public void Raise()
            {
                //OnChange(this, new MyArgs(42)); This gives compiler time error;
                onChange(this, new MyArgs(42));
            }
        }

        public class MyArgs : EventArgs
        {
            public MyArgs(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }
        }

        private void EventsWithExceptions()
        {
            Console.WriteLine("Events in which subscriber raises an exception");
            Pub4 pub = new Pub4();
            pub.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 is called");
            pub.OnChange += (sender, e) => { throw new Exception(); };
            pub.OnChange += (sender, e) => Console.WriteLine("Subscriber 2 is called");
            pub.Raise();
            Console.WriteLine("Once the exception is riased by the subscriber none of the remaining handlers are called");
        }

        public class Pub4
        {
            public event EventHandler OnChange = delegate { };
            public void Raise()
            {
                try
                {
                    OnChange(this, EventArgs.Empty);
                }
                catch(Exception exp)
                {
                    Console.WriteLine("Exception is raised by the subscriber");
                }
            }
        }

        private void EventsWithExceptionHandling()
        {
            Console.WriteLine("Events in which manual event handler invokers and exception handling to enable all the handlers to get called even after exceptions");
            Pub5 pub = new Pub5();
            pub.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 is called");
            pub.OnChange += (sender, e) => { throw new Exception(); };
            pub.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 is called");
            try
            {
                pub.Raise();
            }
            catch(AggregateException exp)
            {
                Console.WriteLine(exp.InnerExceptions.Count);
            }
        }

        public class Pub5
        {
            public event EventHandler OnChange = delegate { };
            public void Raise()
            {
                var exceptions = new List<Exception>();
                foreach(Delegate handler in OnChange.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(this, EventArgs.Empty);
                    }
                    catch(Exception exp)
                    {
                        exceptions.Add(exp);
                    }
                }

                if(exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }
            }
        }

        

        

        

        
    }


}