using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class StudentBLL_EF
    {
        private readonly KolokwiumContext _context;

        public StudentBLL_EF(KolokwiumContext context)
        {
            _context = context;
        }

        public List<StudentDTO> GetAllStudents()
        {
            return _context.Studenci.Select(s => new StudentDTO
            {
                ID = s.ID,
                Imie = s.Imie,
                Nazwisko = s.Nazwisko,
                GroupID = s.GroupaID
            }).ToList();
        }

        public StudentDTO GetStudentById(int studentId)
        {
            var student = _context.Studenci.Find(studentId);
            if (student != null)
            {
                return new StudentDTO
                {
                    ID = student.ID,
                    Imie = student.Imie,
                    Nazwisko = student.Nazwisko,
                    GroupID = student.GroupaID
                };
            }
            return null;
        }

        public void AddStudent(StudentDTO student)
        {
            var newStudent = new Model.Student
            {
                Imie = student.Imie,
                Nazwisko = student.Nazwisko,
                GroupaID = student.GroupID
            };
            _context.Studenci.Add(newStudent);
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentDTO student)
        {
            var existingStudent = _context.Studenci.Find(student.ID);
            if (existingStudent != null)
            {
                existingStudent.Imie = student.Imie;
                existingStudent.Nazwisko = student.Nazwisko;
                existingStudent.GroupaID = student.GroupID;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Studenci.Find(studentId);
            if (student != null)
            {
                _context.Studenci.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
