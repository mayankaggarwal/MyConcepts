using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.ImageProcessing.Entities
{
    public class TextDetails
    {
        public string Text { get; set; }
        public TextPoint TextPoint { get; set; }
        public FontColor FontColor { get; set; }
        public TextScale TextScale { get; set; }
        public int Thickness { get; set; }
    }

    public class TextPoint
    {
        public int X { get;private set; }
        public int Y { get;private set; }

        public TextPoint()
        {
            this.X = 0;
            this.Y = 0;
        }

        public TextPoint(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public class FontColor
    {
        public int R { get;private set; }
        public int G { get;private set; }
        public int B { get;private set; }

        public FontColor()
        {
            this.R = 255;
            this.G = 255;
            this.B = 255;
        }

        public FontColor(int R,int G,int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }

    public class TextScale
    {
        public double HScale { get;private set; }
        public double YScale { get;private set; }
        public TextScale(double hScale,double yScale)
        {
            this.HScale = hScale;
            this.YScale = yScale;
        }
    }
}
