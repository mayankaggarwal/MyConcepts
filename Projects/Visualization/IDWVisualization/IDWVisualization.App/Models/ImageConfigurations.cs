using IDW.ImageProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDWVisualization.App.Models
{
    public class ImageConfigurations
    {

        public List<TextDetails> GetTextDetails(string imageName, string firstText, string secondText, string thirdText, string fourthText, string fifthText, string sixthText, string seventhText)
        {
            switch(imageName)
            {
                case "Template1":
                    return PrepareImage1(firstText, secondText, thirdText, fourthText, fifthText, sixthText, seventhText);
                case "Template2":
                    return PrepareImage2(firstText, secondText, thirdText, fourthText, fifthText, sixthText, seventhText);
                default:
                    return null;
            }
        }

        public List<TextDetails> PrepareImage1(string firstText,string secondText,string thirdText,string fourthText,string fifthText,string sixthText,string seventhText)
        {
            TextScale textScale1 = new TextScale(1.25, 3);
            TextScale textScale2 = new TextScale(4, 5);
            FontColor fontColor1 = new FontColor(0, 0, 0);
            FontColor fontColor2 = new FontColor(223, 105, 12);
            List<TextDetails> lstTextDetails = new List<TextDetails>();
            lstTextDetails.Add(new TextDetails()
            {
                Text = firstText,
                TextPoint = new TextPoint(2000, 145),
                TextScale = textScale1,
                FontColor = fontColor1,
                Thickness = 3
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = secondText,
                TextPoint = new TextPoint(715, 1452),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = thirdText,
                TextPoint = new TextPoint(1320, 1635),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = fourthText,
                TextPoint = new TextPoint(1390, 1835),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = fifthText,
                TextPoint = new TextPoint(770, 2648),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = sixthText,
                TextPoint = new TextPoint(450, 3015),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = seventhText,
                TextPoint = new TextPoint(255, 3349),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 9
            });

            return lstTextDetails;
        }

        public List<TextDetails> PrepareImage2(string firstText, string secondText, string thirdText, string fourthText, string fifthText, string sixthText, string seventhText)
        {
            TextScale textScale1 = new TextScale(.1, .6);
            TextScale textScale2 = new TextScale(.5, .8);
            FontColor fontColor1 = new FontColor(0, 0, 0);
            FontColor fontColor2 = new FontColor(223, 105, 12);
            List<TextDetails> lstTextDetails = new List<TextDetails>();
            lstTextDetails.Add(new TextDetails()
            {
                Text = firstText,
                TextPoint = new TextPoint(285, 22),
                TextScale = textScale1,
                FontColor = fontColor1,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = secondText,
                TextPoint = new TextPoint(92, 210),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = thirdText,
                TextPoint = new TextPoint(189, 235),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = fourthText,
                TextPoint = new TextPoint(197, 260),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = fifthText,
                TextPoint = new TextPoint(106, 380),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = sixthText,
                TextPoint = new TextPoint(42, 435),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });
            lstTextDetails.Add(new TextDetails()
            {
                Text = seventhText,
                TextPoint = new TextPoint(30, 480),
                TextScale = textScale2,
                FontColor = fontColor2,
                Thickness = 1
            });

            return lstTextDetails;
        }
    }
}