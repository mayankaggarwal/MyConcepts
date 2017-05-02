using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.ServiceProvider
{
    public static class DetectionEngineSelector
    {
        public static IDetection.ICardDetectionOps GetProcessingEngine(ProcessingEngine engine)
        {
            IDetection.ICardDetectionOps processingEngine = null;

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
