using MarsRoverExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverExample
{
    public class MarsRover
    {
        public Plateau RoverPlateau { get; private set; }
        public Coordinates CurrentLocation { get; private set; }
        public Direction RoverDirection { get; private set; }

        public MarsRover(Plateau roverPlateau,Coordinates currentLocation,Direction roverDirection)
        {
            this.RoverPlateau = roverPlateau;
            this.CurrentLocation = currentLocation;
            this.RoverDirection = roverDirection;
        }

        public void Run(string command)
        {

        }

        private void ChangeDirection(ChangeDirectionBy changeDirectionBy)
        {
            this.RoverDirection.ChangeDirection(changeDirectionBy);
        }

        private void Move()
        {
            Coordinates newCoordinate = this.CurrentLocation.NewCordinateForStepSize(this.RoverDirection.StepSizeXDirection(), this.RoverDirection.StepSizeYDirection());
            if(this.RoverPlateau.HasWithinBounds(newCoordinate))
            {
                this.CurrentLocation = newCoordinate;
            }
        }
    }
}
