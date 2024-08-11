using System.Collections.Generic;
using ProjectX.Models;
using System.Linq;
using ProjectX.Data;

namespace ProjectX.Services
{
    public class StudentServices
    {
        private readonly ApplicationDbContext _context;
        public StudentServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public Student read(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
        public List<Student> readAll()
        {
            return _context.Students.ToList();
        }
        public void update(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                _context.SaveChanges();
            }
        }
        public void delete(int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
