using HotChocolate;
using HotChocolate.Types;
using MSA2021p2.Data;
using MSA2021p2.Extensions;
using MSA2021p2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSA2021p2.GraphQL
{
    //define Query
    [ExtendObjectType(name: "Query")]
    public class ProjectQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<Project> GetProjects([ScopedService] AppDbContext context)
        {
            return context.Projects.OrderBy(c => c.Created);
        }

        [UseAppDbContext]
        public Project GetProject(int id, [ScopedService] AppDbContext context)
        {
            return context.Projects.Find(id);
        }
    }
}
