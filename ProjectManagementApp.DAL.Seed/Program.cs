using ProjectManagementApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using ProjectManagementApp.DAL.Enums;

namespace ProjectManagementApp.DAL.Seed
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var dbContext = CreateDbContext())
            {
                ClearDatabase(dbContext);
                SeedData(dbContext);
            }
        }

        private static void SeedData(ProjectManagementAppDbContext dbContext)
        {
            var johnUser = new User
            {
                Id = new Guid("5abdfee1-c970-4afd-aff8-aa3cfef8b1ac"),
                Email = "johntheuser@coolmail.com",
                FirstName = "John",
                LastName = "TheUser",
                Nickname = "Johny",
                Password = "safe password"
            };
            dbContext.Users.Add(johnUser);

            var floydUser = new User
            {
                Id = new Guid("cb181669-4e02-449f-bf02-ab6020dfecb4"),
                Email = "floydmw@mail.com",
                FirstName = "Floyd",
                LastName = "Mayweather",
                Nickname = "FM Jr",
                Password = "pass1234"
            };
            dbContext.Users.Add(floydUser);

            var charlieUser = new User
            {
                Id = new Guid("2711f535-3566-446c-9ac6-58261efe3fa3"),
                Email = "Chch@plin.com",
                FirstName = "Charlie",
                LastName = "Chaplin",
                Nickname = "Chch",
                Password = "awesomepassword"
            };
            dbContext.Users.Add(charlieUser);

            var fjTeam = new Team
            {
                Id = new Guid("012ac89a-94e3-4bc2-94b5-c9b05fc83375"),
                Name = "Team Floyd"
            };

            var membership1 = new Membership
            {
                Id = new Guid("b417ad46-baac-487e-8cc1-97ebd7551b13"),
                User = floydUser,
                Position = Position.Leader,
                Team = fjTeam
            };

            var membership2 = new Membership
            {
                Id = new Guid("aa17ad46-baac-487e-8cc1-97ebd7551b13"),
                User = johnUser,
                Team = fjTeam
            };

            fjTeam.Members.Add(membership1);
            fjTeam.Members.Add(membership2);
            dbContext.Memberships.Add(membership1);
            dbContext.Memberships.Add(membership2);
            dbContext.Teams.Add(fjTeam);

            var chTeam = new Team
            {
                Id = new Guid("b417ad46-b94c-487e-8cc1-97ebd7551b13"),
                Name = "Team Charlie"
            };

            var membership3 = new Membership
            {
                Id = new Guid("c417ad46-baac-487e-8cc1-97ebd7551b13"),
                User = charlieUser,
                Position = Position.Leader,
                Team = chTeam
            };

            var membership4 = new Membership
            {
                Id = new Guid("ba17ad46-baac-487e-8cc1-97ebd7551b13"),
                User = floydUser,
                Team = chTeam
            };
            chTeam.Members.Add(membership3);
            chTeam.Members.Add(membership4);
            dbContext.Memberships.Add(membership3);
            dbContext.Memberships.Add(membership4);
            dbContext.Teams.Add(chTeam);

            var johnUserLog = new UserLog
            {
                Id = new Guid("12345678-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.TeamJoin,
                User = johnUser,
                Timestamp = new DateTime(1998, 09, 8),
                Team = fjTeam

            };
            dbContext.UserLogs.Add(johnUserLog);

            var floydUserLog = new UserLog
            {
                Id = new Guid("abcd4561-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.TeamJoin,
                User = floydUser,
                Timestamp = new DateTime(1995, 09, 8),
                Team = fjTeam
            };
            dbContext.UserLogs.Add(floydUserLog);

            var floydUserLog2 = new UserLog
            {
                Id = new Guid("12cd4561-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.TeamJoin,
                User = floydUser,
                Timestamp = new DateTime(2005, 09, 8),
                Team = chTeam
            };
            dbContext.UserLogs.Add(floydUserLog2);

            var charlieUserLog = new UserLog
            {
                Id = new Guid("ab554561-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.TeamJoin,
                User = charlieUser,
                Timestamp = new DateTime(2005, 09, 10),
                Team = chTeam
            };
            dbContext.UserLogs.Add(charlieUserLog);

            var fiThread = new Thread
            {
                Id = new Guid("a9dcad46-b94c-487e-8cc1-97ebd7551b13"),
                Team = chTeam,
                Title = "Test Thread"
            };

            var chComment = new Comment
            {
                Id = new Guid("a98cad46-b94c-487e-8cc1-97ebd7551b13"),
                Author = charlieUser,
                Thread = fiThread,
                Timestamp = new DateTime(2005, 09, 10),
                Text = "First comment test"
            };

            var flComment = new Comment
            {
                Id = new Guid("a98c7d46-b94c-487e-8cc1-97ebd7551b13"),
                Author = floydUser,
                Thread = fiThread,
                Timestamp = new DateTime(2015, 09, 10),
                Text = "Everything seems to be working fine :)"
            };

            fiThread.Comments.Add(chComment);
            fiThread.Comments.Add(flComment);
            dbContext.Threads.Add(fiThread);
            dbContext.Comments.Add(chComment);
            dbContext.Comments.Add(flComment);

            var floydUserLog3 = new UserLog
            {
                Id = new Guid("13cd4561-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.CommentCreate,
                User = floydUser,
                Timestamp = new DateTime(2005, 09, 8),
                Comment = flComment
            };
            dbContext.UserLogs.Add(floydUserLog3);

            var charlieUserLog2 = new UserLog
            {
                Id = new Guid("9b554561-b94c-487e-8cc1-97ebd7551b13"),
                Action = Operation.CommentCreate,
                User = charlieUser,
                Timestamp = new DateTime(2005, 09, 10),
                Comment = chComment
            };
            dbContext.UserLogs.Add(charlieUserLog2);

            dbContext.SaveChanges();
        }

        private static void ClearDatabase(ProjectManagementAppDbContext dbContext)
        {
            dbContext.RemoveRange(dbContext.Threads);
            dbContext.RemoveRange(dbContext.Comments);
            dbContext.RemoveRange(dbContext.Teams);
            dbContext.RemoveRange(dbContext.Users);
            dbContext.RemoveRange(dbContext.UserLogs);
            dbContext.RemoveRange(dbContext.Memberships);
            dbContext.SaveChanges();
        }

        private static ProjectManagementAppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementAppDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ManagementApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new ProjectManagementAppDbContext(optionsBuilder.Options);
        }
    }
}