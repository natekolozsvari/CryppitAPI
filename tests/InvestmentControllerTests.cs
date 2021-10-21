using CryppitBackend.Controllers;
using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Tests
{
    [TestFixture]
    public class InvestmentControllerTests
    {

        private InvestmentListController _controller;
        private IInvestmentRepository _repository;

        private IInvestmentRepository GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "MockDB")
                .Options;
            var context = new AppDbContext(options);
            var repository = new SQLInvestmentRepository(context);
            return repository;
        }

        [SetUp]
        public void Setup()
        {
            _repository = GetInMemoryRepository();
            _controller = new InvestmentListController(_repository);
        }

        [Test]
        public void Create()
        {
            var investment = new Investment
            {
                CryptoId = "bitcoin",
                PriceBought = 50000,
                Amount = 1
            };
            var userId = "10";
            _controller.PostInvestment(userId, investment);

            Assert.AreEqual(1, _repository.Investments.Count());
            Assert.AreEqual("bitcoin", _repository.Investments.First().CryptoId);
        }

        [Test]
        public async Task Get()
        {

            var investment1 = new Investment
            {
                CryptoId = "bitcoin",
                PriceBought = 50000,
                Amount = 1
            };
            var userId1 = "1";

            var investment2 = new Investment
            {
                CryptoId = "ethereum",
                PriceBought = 1234,
                Amount = 0.3
            };
            var investment3 = new Investment
            {
                CryptoId = "doge",
                PriceBought = 25,
                Amount = 100
            };
            var userId2 = "2";

            _controller.PostInvestment(userId1, investment1);
            _controller.PostInvestment(userId1, investment2);
            _controller.PostInvestment(userId2, investment3);

            var investments = await _controller.GetInvestments(userId1);
            Assert.AreEqual(2, investments.Count());
            CollectionAssert.Contains(investments, investment1);
            CollectionAssert.Contains(investments, investment2);
            CollectionAssert.DoesNotContain(investments, investment3);
        }

        [Test]
        public void Update()
        {
            var investment = new Investment
            {
                CryptoId = "bitcoin",
                PriceBought = 50000,
                Amount = 1
            };

            var userId = "3";
            var investmentToChange = _controller.PostInvestment(userId, investment);

            var changes = new Investment
            {
                Id = investmentToChange.Id,
                UserId = userId,
                CryptoId = "bitcoin",
                PriceBought = 60000,
                Amount = 1.2
            };
            
            Assert.AreEqual(investmentToChange, _repository.GetInvestment(investmentToChange.Id));

            _controller.UpdateInvestment(investmentToChange.Id, changes);

            Assert.AreEqual(60000, _repository.GetInvestment(investmentToChange.Id).PriceBought);
            Assert.AreEqual(1.2, _repository.GetInvestment(investmentToChange.Id).Amount);
        }

        [Test]
        public async Task Remove()
        {
            var investment = new Investment
            {
                CryptoId = "litecoin",
                PriceBought = 200,
                Amount = 1
            };
            
            var userId = "4";

            var investmentToRemove = _controller.PostInvestment(userId, investment);
            var investments = await _controller.GetInvestments(userId);

            CollectionAssert.Contains(investments, investmentToRemove);

            _controller.DeleteInvestment(investmentToRemove.Id);

            CollectionAssert.DoesNotContain(investments, investmentToRemove);
        }
    }
}