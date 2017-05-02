using ReadingCards.Entities;
using ReadingCards.IImageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.ServiceProvider
{
    public static class ProcessingEngineSelector
    {
        public static ImageProcessingOps GetProcessingEngine(ProcessingEngine engine)
        {
            ImageProcessingOps processingEngine = null;

            switch (engine)
            {
                case ProcessingEngine.DotNet:
                    break;
                case ProcessingEngine.OpenCV:
                    break;
                case ProcessingEngine.Aforge:
                    break;
            }

            return processingEngine;
        }
    }
}
