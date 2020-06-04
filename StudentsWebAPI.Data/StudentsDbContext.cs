using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using StudentsWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsWebAPI.Data
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }

        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {           
        }

    }
}
