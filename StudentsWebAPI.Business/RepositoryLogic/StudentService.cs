using Microsoft.EntityFrameworkCore;
using StudentsWebAPI.Data;
using StudentsWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebAPI.Business.RepositoryLogic
{
    public class StudentService : IStudentService
    {
        private readonly StudentsDbContext dbContext;

        public StudentService(StudentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<StudentModel> Students => dbContext.Students;

        public async Task<bool> AddStudent(StudentModel newStudent)
        {
            dbContext.Add<StudentModel>(newStudent);

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteStudent(Guid studentID)
        {
            var studentToDelete = await GetStudent(studentID);

            if (studentToDelete == null)
                return false;

            dbContext.Students.Remove(studentToDelete);

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<StudentModel> GetStudent(Guid studentId)
        {
            return await Students.SingleOrDefaultAsync(s => s.Id.Equals(studentId));
        }

        public List<StudentModel> GetStudents()
        {
            return Students.ToList();
        }

        public async Task<bool> UpdateStudent(StudentModel changedStudent)
        {
            var studentToChange = await GetStudent(changedStudent.Id);

            if (studentToChange == null)
                return false;

            // dbContext.Entry(changedStudent).State = EntityState.Modified;

            studentToChange.FirstName = changedStudent.FirstName;
            studentToChange.LastName = changedStudent.LastName;
            studentToChange.JMBG = changedStudent.JMBG;

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
