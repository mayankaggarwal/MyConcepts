using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseIfModelChanges<PhotoSharingContext>
    {
        public void InitializeDatabase(PhotoSharingContext context)
        {
            
            context.Database.ExecuteSqlCommand("ALTER DATABASE Tocrates SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
            //_initializer.InitializeDatabase(context);
        }

        protected override void Seed(PhotoSharingContext context)
        {
            Photo photo = new Photo
            {
                Title = "TestPhoto",
                Description = "My first Photo",
                UserName = "NaokiSato",
                PhotoFile = GetFileBytes("\\Images\\flower.JPG"),
                ImageMimeType = "image/jpeg",
                CreatedDate = DateTime.Now
            };

            Comment comment = new Comment
            {
                PhotoID = 1,
                UserName = "NaokiSato",
                Subject = "Test Comment",
                Body = "This comment should appear in photo 1"
            };

            context.Photos.Add(photo);
            context.SaveChanges();
            context.Comments.Add(comment);
            context.SaveChanges();

        }

        private byte[] GetFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}