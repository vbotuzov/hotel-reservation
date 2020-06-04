using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestPersonRepository
        : BaseRepository<Person>
    {
        public TestPersonRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputPersonInstance_CalledAddMethodOfDBSetWithPersonInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<Hotel_ordContext>()
                .Options;
            var mockContext = new Mock<Hotel_ordContext>(opt);
            var mockDbSet = new Mock<DbSet<Person>>();
            mockContext
                .Setup(context =>
                    context.Set<Person>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestPersonRepository(mockContext.Object);

            Person expectedPerson = new Mock<Person>().Object;

            //Act
            repository.Create(expectedPerson);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedPerson
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<Hotel_ordContext>()
                .Options;
            var mockContext = new Mock<Hotel_ordContext>(opt);
            var mockDbSet = new Mock<DbSet<Person>>();
            mockContext
                .Setup(context =>
                    context.Set<Person>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestPersonRepository(mockContext.Object);

            Person expectedPerson = new Person() { pasport_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPerson.pasport_id)).Returns(expectedPerson);

            //Act
            repository.Delete(expectedPerson.pasport_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedPerson.pasport_id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedPerson
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<Hotel_ordContext>()
                .Options;
            var mockContext = new Mock<Hotel_ordContext>(opt);
            var mockDbSet = new Mock<DbSet<Person>>();
            mockContext
                .Setup(context =>
                    context.Set<Person>(
                        ))
                .Returns(mockDbSet.Object);

            Person expectedPerson = new Person() { pasport_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPerson.pasport_id))
                    .Returns(expectedPerson);
            var repository = new TestPersonRepository(mockContext.Object);

            //Act
            var actualPerson = repository.Get(expectedPerson.pasport_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedPerson.pasport_id
                    ), Times.Once());
            Assert.Equal(expectedPerson, actualPerson);
        }


    }
}