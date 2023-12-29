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
    class TestTenderRepository
        : BaseRepository<Tender>
    {
        public TestTenderRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputTenderInstance_CalledAddMethodOfDBSetWithTenderInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<TenderContext>()
                .Options;
            var mockContext = new Mock<TenderContext>(opt);
            var mockDbSet = new Mock<DbSet<Tender>>();
            mockContext
                .Setup(context =>
                    context.Set<Tender>(
                        ))
                .Returns(mockDbSet.Object);
            EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestTenderRepository(mockContext.Object);

            Tender expectedTender = new Mock<Tender>().Object;

            //Act
            repository.Create(expectedTender);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedTender
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<TenderContext>()
                .Options;
            var mockContext = new Mock<TenderContext>(opt);
            var mockDbSet = new Mock<DbSet<Tender>>();
            mockContext
                .Setup(context =>
                    context.Set<Tender>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestTenderRepository(mockContext.Object);

            Tender expectedTender = new Tender() { IdTender = 1};
            mockDbSet.Setup(mock => mock.Find(expectedTender.IdTender)).Returns(expectedTender);

            //Act
            repository.Delete(expectedTender.IdTender);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedTender.IdTender
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedTender
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<TenderContext>()
                .Options;
            var mockContext = new Mock<TenderContext>(opt);
            var mockDbSet = new Mock<DbSet<Tender>>();
            mockContext
                .Setup(context =>
                    context.Set<Tender>(
                        ))
                .Returns(mockDbSet.Object);

            Tender expectedTender = new Tender() { IdTender = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedTender.IdTender))
                    .Returns(expectedTender);
            var repository = new TestTenderRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedTender.IdTender);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedTender.IdTender
                    ), Times.Once());
            Assert.Equal(expectedTender, actualStreet);
        }


    }
}