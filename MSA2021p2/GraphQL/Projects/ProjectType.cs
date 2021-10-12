﻿using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MSA2021p2.Data;
using MSA2021p2.GraphQL.Comments;
using MSA2021p2.GraphQL.Students;
using MSA2021p2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSA2021p2.GraphQL.Projects
{
    public class ProjectType : ObjectType<Project>
    {
        protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
        {
            descriptor.Field(p => p.Id).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.Name).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Description).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Link).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Year).Type<NonNullType<EnumType<Year>>>();
            descriptor.Field(p => p.Modified).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Created).Type<NonNullType<DateTimeType>>();

            descriptor
                .Field(p => p.Student)
                .ResolveWith<Resolvers>(r => r.GetStudent(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<StudentType>>();

            descriptor
                .Field(p => p.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<CommentType>>>>();


        }

        private class Resolvers
        {
            public async Task<Student> GetStudent(Project project, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Students.FindAsync(new object[] { project.StudentId }, cancellationToken);
            }

            public async Task<IEnumerable<Comment>> GetComments(Project project, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Comments.Where(c => c.ProjectId == project.Id).ToArrayAsync(cancellationToken);
            }
        }
    }
}
