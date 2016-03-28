using System;
using CSharpConcepts.Interfaces;
using System.IO;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class WorkingWithFilesExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Working with files examples");
        }

        public void MainMethod()
        {
            DriveInformationExample();
        }

        private void DriveInformationExample()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();
            foreach(var driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine(" File type: {0}", driveInfo.DriveType);

                if(driveInfo.IsReady == true)
                {
                    Console.WriteLine(" Volume Label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine(" File system: {0}", driveInfo.DriveFormat);

                    Console.WriteLine(" Available space to current user:{0,15}", driveInfo.AvailableFreeSpace);
                    Console.WriteLine(" Total available space:{0,15}", driveInfo.TotalFreeSpace);
                    Console.WriteLine(" Total size of drive:{0,15}", driveInfo.TotalSize);
                }
            }
        }
    }
}