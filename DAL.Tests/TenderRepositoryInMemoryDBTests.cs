using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using DAL.EF;
using DAL.Entities.Enum;

namespace DAL.Tests
{
    public class TenderRepositoryInMemoryDBTests
    {
        public TenderContext Context => SqlLiteInMemoryContext();

        private TenderContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<TenderContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new TenderContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputTenderWithId()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            ITenderRepository repository = uow.Tenders;

            Tender tender = new Tender()
            {
                IdTender = 1,
                Price = 230000,
                Description = "buy Reactor",
                Deadline = DateTime.Today.AddDays(30),
                Status = TenderStatus.Processing,
            };

            //Act
            repository.Create(tender);
            uow.Save();
            var factListCount = context.Tenders.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistTenderId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            ITenderRepository repository = uow.Tenders;
            Tender tender = new Tender()
            {
                IdTender = 5,
                Price = 230000,
                Description = "buy Reactor",
                Deadline = DateTime.Today.AddDays(30),
                Status = TenderStatus.Processing,
                Proposals = new List<Proposal>(),
            };
            context.Tenders.Add(tender);
            context.SaveChanges();

            //Act
            repository.Delete(tender.IdTender);
            uow.Save();
            var factTenderCount = context.Tenders.Count();

            // Assert
            Assert.Equal(expectedListCount, factTenderCount);
        }

        [Fact]
        public void Get_InputExistTenderId_ReturnTender()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            ITenderRepository repository = uow.Tenders;
            Tender expectedTender = new Tender()
            {
                IdTender = 5,
                Price = 230000,
                Description = "buy Reactor",
                Deadline = DateTime.Today.AddDays(30),
                Status = TenderStatus.Processing,
                Proposals = new List<Proposal>()
            };
            context.Tenders.Add(expectedTender);
            context.SaveChanges();

            //Act
            var factTender = repository.Get(expectedTender.IdTender);

            // Assert
            Assert.Equal(expectedTender, factTender);
        }
    }
}