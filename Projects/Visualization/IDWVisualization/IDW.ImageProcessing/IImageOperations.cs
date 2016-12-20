using IDW.ImageProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.ImageProcessing
{
    public interface IImageOperations
    {
        string WriteTextToImage(string sourceImagePath, List<TextDetails> lstTextDetails);
        string WriteTextToBase64Image(string sourceImageString, List<TextDetails> lstTextDetails);
    }
}
