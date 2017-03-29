using ContosoUniversity.Core.Services;
using ContosoUniversity.Domain.Contoso;
using ContosoUniversity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Services
{
    public class StudentService:BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
