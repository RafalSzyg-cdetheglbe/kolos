using BLL;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            _context.Database.ExecuteSqlRaw("EXEC DodajStudenta @Imie, @Nazwisko, @GroupID",
                 new SqlParameter("@Imie", student.Imie),
                     new SqlParameter("@Nazwisko", student.Nazwisko),
                         new SqlParameter("@GroupID", student.GroupID ?? (object)DBNull.Value)); //Konwersja na DBNull, jeśli GroupID jest null
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
