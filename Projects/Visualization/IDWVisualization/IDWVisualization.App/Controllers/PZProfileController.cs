using IDW.ImageProcessing;
using IDW.ImageProcessing.Entities;
using IDWVisualization.App.Models;
using IDWVisualization.DataAccessLayer.Repositories;
using IDWVisualization.DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

namespace IDWVisualization.App.Controllers
{
    public class PZProfileController : ApiController
    {
        private Object lockobject = new Object();

        [HttpGet()]
        public List<PZProfileCompletion> GetProfileStats()
        {
            List<PZProfileCompletion> pzProfileCompletion = new List<PZProfileCompletion>();
            IPZProfileRepository profileRepo = new PZProfileRepository();
            var result = profileRepo.GetStats();
            if (result != null)
            {

                foreach (IDWVisualization.DataAccessLayer.Entities.PZProfileStats stat in result)
                {
                    pzProfileCompletion.Add(new PZProfileCompletion
                    {
                        PercentageCompleted = (int)stat.PercentCompleted,
                        Section = stat.Section
                    });
                }
            }

            return pzProfileCompletion;
        }

        public IHttpActionResult GetPlazzaImage(string quality)
        {
            string lastUploadDate = "23/10/2016";
            ImageConfigurations imageConfigurations = new ImageConfigurations();

            IPZProfileRepository profileRepo = new PZProfileRepository();
            IPZActivityRepository activityRepo = new PZActivityRepository();
            IPZSocialGroupRepository socialGroupRepository = new PZSocialGroupRepository();
            string firstText = DateTime.Now.ToShortDateString();
            decimal profiles = 102700; //profileRepo.GetCreatedProfiles();
            int activeUsers = activityRepo.GetActiveIdentitiesCount(lastUploadDate);
            string secondText = profiles.ToString();
            string thirdText = activeUsers.ToString();
            string fourthText = ((int)((activeUsers / profiles) * 100)).ToString() + "%";
            string fifthText = socialGroupRepository.GetTotalCount().ToString();
            string sixthText = activityRepo.GetViewCommunities().ToString();
            string seventhText = activityRepo.GetAverageActivites(lastUploadDate).ToString();

            string imageFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Images/PlazzaImage.png");

            string template = "Template1";
            if (quality.ToUpper().Equals("HIGH"))
            {
                imageFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Images/TemplateEnglish.jpg");
                template = "Template1";
            }
            else if (quality.ToUpper().Equals("LOW"))
            {
                imageFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Images/PlazzaImage.png");
                template = "Template2";
            }
            List<TextDetails> lstTextDetails = null;
            lstTextDetails = imageConfigurations.GetTextDetails(template, firstText, secondText, thirdText, fourthText, fifthText, sixthText, seventhText);

            string newPath = string.Empty;
           
            Trace.TraceInformation("Sending file to Opne CV with file path :" + imageFilePath);
            Trace.Flush();
            if (lstTextDetails != null)
            {
                IImageOperations imageOperations = new ImageOperationsOpenCV(Path.GetDirectoryName(imageFilePath));


                try
                {
                    newPath = imageOperations.WriteTextToImage(imageFilePath, lstTextDetails);
                }
                catch (Exception exp)
                {
                    Trace.TraceInformation("Exception raised" + exp.Message);
                    Trace.TraceInformation(exp.InnerException.ToString());
                    Trace.Flush();
                    newPath = string.Empty;
                }
            }
            if (!String.IsNullOrEmpty(newPath) && File.Exists(newPath))
            {

                Bitmap bitmap = (Bitmap)Image.FromFile(newPath);
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] imageBytes = ms.ToArray();
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                return Ok(imageBytes);
            }
            else
            {
                Trace.TraceInformation("File Not retreived :" + newPath);
                Trace.Flush();
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                return Ok();
            }

        }


    }
}
//PointF firstLocation = new PointF(285f, 4f);
//PointF secondLocation = new PointF(92f, 188f);
//PointF thirdLocation = new PointF(189f, 214f);
//PointF fourthLocation = new PointF(197f, 242f);
//PointF fifthLocation = new PointF(106f, 360f);
//PointF sixthLocation = new PointF(42f, 410f);
//PointF seventhLocation = new PointF(24f, 458f);


////string imageFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Images\image1.png");
//string imageFilePath = @"C:\D\Learning\Repository\MyConcepts\Projects\Visualization\IDWVisualization\IDWVisualization.App\Images\PlazzaImage.png";
////bool resultImage = File.Exists(@"C:\D\Learning\Repository\MyConcepts\Projects\Visualization\IDWVisualization\IDWVisualization.App\Images\image1.png");

//Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
//var brush = new SolidBrush(Color.FromArgb(255, (byte)223, (byte)105, (byte)12));
//using (Graphics graphics = Graphics.FromImage(bitmap))
//{
//    using (Font arialFont = new Font("Arial", 10))
//    {
//        graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
//    }



//    using (Font font = new Font("Calibri", 18,FontStyle.Bold))
//    {
//        graphics.DrawString(secondText, font, brush, secondLocation);
//        graphics.DrawString(thridText, font, brush, thirdLocation);
//        graphics.DrawString(fourthText, font, brush, fourthLocation);
//        graphics.DrawString(fifthText, font, brush, fifthLocation);
//        graphics.DrawString(sixthText, font, brush, sixthLocation);
//        graphics.DrawString(seventhText, font, brush, seventhLocation);
//    }

//}