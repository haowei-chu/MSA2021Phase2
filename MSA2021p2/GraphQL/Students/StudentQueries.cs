using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MSA2021p2.Data;
using MSA2021p2.Models;

namespace MSA2021p2.GraphQL.Students
{
    [ExtendObjectType(name: "Query")]
    public class StudentQueries
    {
        public IQueryable<Student> GetStudents([ScopedService] AppDbContext context)
        {
            return context.Students;
        }
    }
}
