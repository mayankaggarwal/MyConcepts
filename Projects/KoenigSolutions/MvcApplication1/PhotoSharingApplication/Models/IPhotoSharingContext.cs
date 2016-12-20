using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Models
{
    public interface IPhotoSharingContext
    {
        IQueryable<Photo> Photos { get; }
        IQueryable<Comment> Comments { get; }
        int SaveChanges();
        T Add<T>(T entity) where T:class;
        Photo FindByPhotoID(int ID);
        Comment FindByCommentID(int commentID);
        T Delete<T>(T entity) where T : class;

    }
}
