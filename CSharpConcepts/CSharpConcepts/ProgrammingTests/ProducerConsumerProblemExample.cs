using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpConcepts.ProgrammingTests
{
    public class ProducerConsumerProblemExample:IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Producer Consumer Problem Example");
        }

        public void MainMethod()
        {
            RecommendedWay();
            ExperimentalWay();
        }

        private void RecommendedWay()
        {
            Console.WriteLine("Recommended Way");
            Principle principleOffice = new Principle();
            ClassRooms classRoom1 = new ClassRooms(principleOffice);
            ClassRooms classRoom2 = new ClassRooms(principleOffice);
            ClassRooms classRoom3 = new ClassRooms(principleOffice);
            ClassRooms classRoom4 = new ClassRooms(principleOffice);
            ClassRooms classRoom5 = new ClassRooms(principleOffice);
            ClassRooms classRoom6 = new ClassRooms(principleOffice);
            principleOffice.RaiseAlarm();
        }

        private void ExperimentalWay()
        {
            Console.WriteLine("Experimental Way");
            PrincipalOffice princi = new PrincipalOffice();
            Classrooms classroom1 = new Classrooms("Class 1", princi);
            Classrooms classroom2 = new Classrooms("Class 2", princi);
            Classrooms classroom3 = new Classrooms("Class 3", princi);
            Classrooms classroom4 = new Classrooms("Class 4", princi);
            Classrooms classroom5 = new Classrooms("Class 5", princi);
            Classrooms classroom6 = new Classrooms("Class 6", ref princi.RaiseAlarm);
            Classrooms classroom7 = new Classrooms("Class 7", ref princi.RaiseAlarm);
            Classrooms classroom8 = new Classrooms("Class 8", ref  princi.RaiseAlarm);
            Classrooms classroom9 = new Classrooms("Class 9", ref  princi.RaiseAlarm);
            Classrooms classroom10 = new Classrooms("Class 10", ref  princi.RaiseAlarm);
            Classrooms classroom11 = new Classrooms(princi, "Class 11");
            Classrooms classroom12 = new Classrooms(princi, "Class 12");
            Classrooms classroom13 = new Classrooms(princi, "Class 13");
            Classrooms classroom14 = new Classrooms(princi, "Class 14");
            Classrooms classroom15 = new Classrooms(princi, "Class 15");
            princi.RaiseRecessAlarmMethod();
            princi.GivePunishment();
        }

        #region Recommended Way
        public class Principle
        {
            public event EventHandler<Message> RaiseAlarmEvent;

            public void RaiseAlarm()
            {
                if(RaiseAlarmEvent!=null)
                {
                    RaiseAlarmEvent(this, new Message { msg = "Bell Rings" });
                }
            }
        }

        public class ClassRooms
        {
            private static int counter = 1;
            private int ClassId;
            public ClassRooms(Principle principleOffice)
            {
                ClassId = counter++;
                principleOffice.RaiseAlarmEvent += principleOffice_RaiseAlarmEvent;
            }

            void principleOffice_RaiseAlarmEvent(object sender, Message e)
            {
                Console.WriteLine("{0} in class {1}", e.msg, ClassId);
            }
        }
        #endregion

        public class Message:EventArgs
        {
            public string msg { get; set; }
        }

        #region "ExperimentalWay"
        public delegate void RaiseAlarm(string message);
        public delegate void Punishment();
        internal class PrincipalOffice
        {
            public EventHandler RaiseAlarm;
            public event Punishment punishment;
            public PrincipalOffice()
            {

            }

            public void RaiseRecessAlarmMethod()
            {
                RaiseAlarm(this, new Message() { msg = "Recess" });
            }

            public void GivePunishment()
            {
                if (punishment != null)
                {
                    punishment();
                }
            }
        }

        internal class Classrooms
        {
            private string ClassName { get; set; }
            public Classrooms(string className, PrincipalOffice princi)
            {
                this.ClassName = className;
                princi.RaiseAlarm += new EventHandler(Classrooms_raiseAlarm);
            }
            public Classrooms(string className, ref EventHandler del)
            {
                this.ClassName = className;
                del += new EventHandler(Classrooms_raiseAlarm);
            }

            public Classrooms(PrincipalOffice principalOffice, string className)
            {
                this.ClassName = className;
                principalOffice.punishment += principalOffice_punishment;
            }

            private void principalOffice_punishment()
            {
                Console.WriteLine(ClassName + " got punishment");
            }

            private void Classrooms_raiseAlarm(object sender, EventArgs e)
            {
                Console.WriteLine(((Message)e).msg + " " + ClassName);
            }
        }
        #endregion
    }
}
