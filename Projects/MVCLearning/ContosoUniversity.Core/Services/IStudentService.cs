using ContosoUniversity.Domain.Contoso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Core.Services
{
    public interface IStudentService:IService<Student>
    {
    }
}
