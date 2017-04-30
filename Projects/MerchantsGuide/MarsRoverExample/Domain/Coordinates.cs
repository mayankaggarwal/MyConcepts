using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverExample.Domain
{
    public class Coordinates
    {
        public int X { get;private set; }
        public int Y { get;private set; }

        public Coordinates(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinates NewCordinateForStepSize(int stepX,int stepY)
        {
            return new Coordinates(this.X + stepX, this.Y + stepY);
        }
    }
}
