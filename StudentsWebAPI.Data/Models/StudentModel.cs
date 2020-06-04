using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsWebAPI.Data.Models
{
    public class StudentModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JMBG { get; set; }

    }
}
