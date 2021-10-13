using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MSA2021p2.Data;
using MSA2021p2.Models;
using MSA2021p2.Extensions;

namespace MSA2021p2.GraphQL.Students
{
    [ExtendObjectType(name: "Query")]
    public class StudentQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<Student> GetStudents([ScopedService] AppDbContext context)
        {
            return context.Students;
        }
        [UseAppDbContext]
        public Student GetStudent(int id, [ScopedService] AppDbContext context)
        {
            return context.Students.Find(id);
        }
    }
}
