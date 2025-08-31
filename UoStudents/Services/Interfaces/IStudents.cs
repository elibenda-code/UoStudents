using UoStudents.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UoStudents.Services.Interfaces
{
    public interface IStudents
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<bool> UpdateAsync(int id, Student student);
        Task<bool> DeleteAsync(int id);
    }
}
