using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverExample.Domain
{
    public enum Direction
    {
        East = 0,
        North = 1,
        West = 2,
        South = 3
    }

    public enum ChangeDirectionBy
    {
        Left,
        Right
    }

    public static class NextDirection
    {
        public static Direction ChangeDirection(this Direction d, ChangeDirectionBy changeDirectionBy)
        {
            int directionCount = (int)d;
            switch (changeDirectionBy)
            {
                case ChangeDirectionBy.Right:
                    
                    if (directionCount == 0)
                        return Direction.South;
                    else
                        return (Direction)(directionCount - 1);
                case ChangeDirectionBy.Left:
                    if (directionCount == 3)
                        return Direction.East;
                    else
                        return (Direction)(directionCount + 1);
                default:
                    return d;

            }
        }

        public static int StepSizeXDirection(this Direction direction)
        {
            int stepSize = 0;
            if (direction == Direction.East)
                stepSize = 1;
            else if (direction == Direction.West)
                stepSize = -1;

            return stepSize;
        }

        public static int StepSizeYDirection(this Direction direction )
        {
            int stepSize = 0;
            if (direction == Direction.North)
                stepSize = 1;
            else if (direction == Direction.South)
                stepSize = -1;

            return stepSize;
        }
    }
}
