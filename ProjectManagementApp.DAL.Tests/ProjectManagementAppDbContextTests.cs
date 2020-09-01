
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using ProjectManagementApp.DAL.Entities;
using ProjectManagementApp.DAL.Enums;
using Xunit;

namespace ProjectManagementApp.DAL.Tests
{
    public class ProjectManagementAppDbContextTests
    {
        private ProjectManagementAppDbContext TestContext { get; set; }
        private DbContextOptions<ProjectManagementAppDbContext> ContextOptions { get; set; }

        public ProjectManagementAppDbContextTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementAppDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestingDB");
            ContextOptions = optionsBuilder.Options;

        }


        [Fact]
        public void AddUserTest()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);

            var user = new User
            {
                Id = new Guid("ba17ad46-baac-487e-8cc1-97ebd7551b13"),
                FirstName = "Freddie",
                LastName = "Tester",
                Email = "TheEmail",
            };

            //Act
            TestContext.Users.Add(user);
            TestContext.SaveChanges();


            //Assert
            var retrievedUser = TestContext.Users.First(entity => entity.Id == user.Id);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.FirstName, retrievedUser.FirstName);
            Assert.Equal(user.LastName, retrievedUser.LastName);

            //Teardown
            ClearDatabase(TestContext);
        }


        [Fact]
        public void AddUserWithTeamTest()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);
            var team = new Team
            {
                Id = new Guid(),
                Name = "TestingTeam"
            };
            var user = new User
            {
                Id = new Guid(),
                FirstName = "Freddie",
                LastName = "Tester",
                Email = "TheEmail",
            };
            var membership = new Membership
            {
                Id = new Guid(),
                Position = Position.Leader,
                Team = team,
                User = user
            };
            //Act
            TestContext.Memberships.Add(membership);
            TestContext.SaveChanges();

            //Assert
            var retrievedMembership = TestContext.Memberships.First(entity => entity.Id == membership.Id);
            Assert.Equal(membership.Position, retrievedMembership.Position);
            Assert.Equal(membership.Team.Id, retrievedMembership.Team.Id);

            var retrievedTeam = TestContext.Teams.First(entity => entity.Id == team.Id);
            Assert.Equal(team.Id, retrievedTeam.Id);

            var retrievedUser = TestContext.Users.First(entity => entity.Id == user.Id);
            Assert.Equal(user.Id, retrievedUser.Id);

            //Teardown
            ClearDatabase(TestContext);
        }


        [Fact]
        public void AddUserWithSameIdTwice()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);
            var user = new User
            {
                Id = new Guid(),
                FirstName = "Freddie",
                LastName = "Tester",
                Email = "TheEmail",
            };
            //Act

            TestContext.Users.Update(user);
            TestContext.SaveChanges();
            user.Email = "NewMail";
            TestContext.Users.Update(user);
            TestContext.SaveChanges();

            //Verify
            var retrievedUser = TestContext.Users.First(entity => entity.Id == user.Id);
            Assert.Equal(user.Id, retrievedUser.Id);
            Assert.Equal(user.Email, retrievedUser.Email);
            //Teardown
            ClearDatabase(TestContext);
        }


        [Fact]
        public void UpdateDataInUser()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);
            var user = new User
            {
                Id = new Guid(),
                FirstName = "Freddie",
                LastName = "Tester",
                Email = "TheEmail",
            };
            //Act
            TestContext.Users.Add(user);
            TestContext.SaveChanges();
            user.Email = "NewMail";
            user.Nickname = "Nickname";
            TestContext.Users.Update(user);
            TestContext.SaveChanges();
            //Verify
            var retrievedUser = TestContext.Users.Find(user.Id);
            Assert.Equal(user.LastName, retrievedUser.LastName);
            Assert.Equal(user.Nickname, retrievedUser.Nickname);
            Assert.Equal(user.Email, retrievedUser.Email);
            //Teardown
            ClearDatabase(TestContext);
        }
        
        [Fact]
        public void AddTeam()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);
            var team = new Team
            {
                Id = new Guid(),
                Name = "testerTeam",
                Members =
                {
                    new Membership
                    {
                        Position = Position.Leader,
                        User = new User()
                        {
                            FirstName = "John",
                            LastName =  "Tester",
                            Email = "johnytesing@mail.com",
                            Nickname = "Johny",
                            Password = "SafePassword"
                        }
                    },
                    new Membership
                    {
                        Position = Position.Leader,
                        User = new User()
                        {
                            FirstName = "anotherJohn",
                            LastName =  "anotherTester",
                            Email = "anotherjohnytesing@mail.com",
                            Nickname = "anotherJohny",
                            Password = "anotherSafePassword"
                        }
                    }
                }
            };
            //Act
            TestContext.Teams.Add(team);
            TestContext.SaveChanges();
            //Verify

            var retrievedTeam = TestContext.Teams.Find(team.Id);
            Assert.Equal(team.Id, retrievedTeam.Id);
            var retrievedUser = TestContext.Users.First();
            Assert.True("John" == retrievedUser.FirstName || "anotherJohn" == retrievedUser.FirstName);
            
            //Teardown
            ClearDatabase(TestContext);
        }

        [Fact]
        public void AddThread()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);
            var thread = new Thread
            {
                Id = new Guid(),
                Team = new Team()
                {
                    Id = new Guid(),
                    Name = "TestingTeam"
                },
                Title = "MyCoolTestingThread",
                Comments =
                {
                    new Comment
                    {
                        Id = new Guid(),
                        Author = new User
                        {
                            Nickname = "yourNick10"
                        },
                        Text = "CoolText"
                    }
                }
            };
            //Act
            TestContext.Threads.Add(thread);
            TestContext.SaveChanges();
            //Verify
            var retrievedThread = TestContext.Threads.Find(thread.Id);
            Assert.Equal(thread.Id, retrievedThread.Id);
            Assert.Equal(thread.Title, thread.Title);
            var retrievedComment = TestContext.Comments.First();
            Assert.Equal(thread.Id, retrievedComment.Thread.Id);
            //Teardown
            ClearDatabase(TestContext);
        }

        [Fact]
        public void AddComment()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);

            var comment = new Comment
            {
                Id = new Guid(),
                Author = new User(),
                Text = "Some weird comment",
                Thread = new Thread
                {
                    Id = new Guid(),
                    Title = "The Comment Test",
                    Team = new Team()
                }
            };

            //Act
            TestContext.Comments.Add(comment);
            TestContext.SaveChanges();

            //Assert
            var retrievedComment = TestContext.Comments.First(entity => entity.Id == comment.Id);
            Assert.Equal(comment.Id, retrievedComment.Id);
            Assert.Equal( "The Comment Test", retrievedComment.Thread.Title);

            //Teardown
            ClearDatabase(TestContext);
        }

        [Fact]
        public void AddUserLog()
        {
            //Setup
            TestContext = new ProjectManagementAppDbContext(ContextOptions);

            var userLog = new UserLog
            {
                Id = new Guid(),
                Action = Operation.TeamJoin,
                Team = new Team
                {
                    Id = new Guid(),
                    Name = "TheTeam"
                },
                Timestamp = DateTime.Now,
                User = new User
                {
                    Id = new Guid(),
                    Nickname = "Frank"
                }
            };

            //Act
            TestContext.UserLogs.Add(userLog);
            TestContext.SaveChanges();

            //Assert
            var retrievedLog = TestContext.UserLogs.First(entity => entity.Id == userLog.Id);
            Assert.Equal(Operation.TeamJoin, retrievedLog.Action);
            Assert.Equal("Frank", retrievedLog.User.Nickname);

            //Teardown
            ClearDatabase(TestContext);

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


    }
}
