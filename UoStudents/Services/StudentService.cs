using Microsoft.EntityFrameworkCore;
using UoStudents.Data;
using UoStudents.Models;
using UoStudents.Services.Interfaces;

namespace UoStudents.Services
{
    public class StudentService : IStudents
    {
        private readonly UopenDbContext _context;

        public StudentService(UopenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateAsync(int id, Student student)
        {
            var existing = await _context.Students.FindAsync(id);
            if (existing == null) return false;

            existing.FullName = student.FullName;
            existing.BirthDate = student.BirthDate;
            existing.AverageGrade = student.AverageGrade;
            existing.IsActive = student.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Students.FindAsync(id);
            if (existing == null) return false;

            _context.Students.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
