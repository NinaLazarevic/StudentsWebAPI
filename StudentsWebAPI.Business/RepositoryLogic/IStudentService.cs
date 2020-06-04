using StudentsWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebAPI.Business.RepositoryLogic
{
    public interface IStudentService
    {
        IQueryable<StudentModel> Students { get; }

        List<StudentModel> GetStudents();

        Task<StudentModel> GetStudent(Guid studentId);

        Task<bool> DeleteStudent(Guid studentID);

        Task<bool> AddStudent(StudentModel newStudent);

        Task<bool> UpdateStudent(StudentModel changedStudent);
    }
}
