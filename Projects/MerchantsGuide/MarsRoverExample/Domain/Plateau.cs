using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverExample.Domain
{
    public class Plateau
    {
        public Coordinates TopRightCoordinates = new Coordinates(0, 0);
        public Coordinates BottomLeftCoordinates = new Coordinates(0, 0);

        public Plateau(Coordinates topRightCoordinates)
        {
            this.TopRightCoordinates = new Coordinates(topRightCoordinates.X, topRightCoordinates.Y);
        }

        internal bool HasWithinBounds(Coordinates newCoordinates)
        {
            if (newCoordinates.X >= BottomLeftCoordinates.X && newCoordinates.X <= TopRightCoordinates.X
                && newCoordinates.Y >= BottomLeftCoordinates.Y && newCoordinates.Y <= TopRightCoordinates.Y)
                return true;
            else
                return false;
        }
    }
}
