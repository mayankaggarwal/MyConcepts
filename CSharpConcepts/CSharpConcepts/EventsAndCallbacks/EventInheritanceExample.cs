using System;
using CSharpConcepts.Interfaces;

namespace CSharpConcepts.EventsAndCallbacks
{
    internal class EventInheritanceExample : IMainMethod
    {
        public void MainMethod()
        {
            PrincipleRoom princi = new PrincipleRoom(1);
            ClassRoom room2 = new ClassRoom(2, princi);
            ClassRoom room3 = new ClassRoom(3, princi);
            ClassRoom room4 = new ClassRoom(4, princi);
            ClassRoom room5 = new ClassRoom(5, princi);
            ClassRoom room6 = new ClassRoom(6, princi);
            princi.RaiseSchoolBell("3");

        }

        public void SummaryMethod()
        {
            Console.WriteLine("As the event can be raised only within the class that "
                + "declared it, so .Net framework provided a protected method to base "
                + "class that raises the event. Then the derived class can call that "
                + "method to raise the event. The method name should begin with “On” "
                + "and ends with event name.");
        }
    }

    public class Room
    {
        public event EventHandler<string> RingBell = delegate { };
        public Room(int RoomNumber)
        {
            this.RoomNumber = RoomNumber;
        }
        public int RoomNumber { get; private set; }

        protected void OnRingBell(string ringHour)
        {
            RingBell(this, ringHour);
        }
    }

    public class PrincipleRoom : Room
    {
        public PrincipleRoom(int RoomNumber) : base(RoomNumber)
        {

        }

        public void RaiseSchoolBell(string hour)
        {
            Console.WriteLine("Raising Bell from Room Number: {0} for Hour:{1}", this.RoomNumber, hour);
            //if(this.ORingBell!=null)
            OnRingBell(hour);
            //this.RingBell(hour);
        }
    }

    public class ClassRoom : Room
    {
        private Room PrincipleRoom;
        public ClassRoom(int RoomNumber, Room principleRoom) : base(RoomNumber)
        {
            PrincipleRoom = principleRoom;
            //this.PrincipleRoom.RingBell += (hour) => RaiseBell(hour);
            this.PrincipleRoom.RingBell += PrincipleRoom_RingBell;
        }

        private void PrincipleRoom_RingBell(object sender, string e)
        {
            Console.WriteLine("Bell ringing in class:{0} for Hour: {1}", this.RoomNumber, e);
        }

        private void RaiseBell(string hour)
        {
            Console.WriteLine("Bell ringing in class:{0} for Hour: {1}", this.RoomNumber, hour);
        }
    }

}