using Core.UserException;
using DataAccess.UserActions;
using Domain;
using Domain.Impl;
using Domain.Impl.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.User
{
    [TestClass]
    public class UserTests
    {
        private Mock<IUserDomain> userDomainMock;
        private Mock<IUserAction> userActionMock;
        private UserFakeData userFakedata;
        private UserFormatter userFormatter;

        [TestInitialize]
        public void Initialize()
        {
            userActionMock = new Mock<IUserAction>();
            userDomainMock = new Mock<IUserDomain>();
            userFakedata = new UserFakeData();
            userFormatter = new UserFormatter();
        }

        [TestMethod]
        [TestCategory("User")]
        public async Task GetAllUsers_Ok()
        {
            var users = userFakedata.GetAllUsersModel();
            userActionMock.Setup(u => u.GetAll())
                .ReturnsAsync(users);

            var usersResponse = users.Select(u => userFormatter.ToUserResponse(u)).ToList();

            var domain = new UserDomain(userActionMock.Object);
            var result = await domain.GetAll();

            Assert.IsNotNull(result);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Id, usersResponse[i].Id);
                Assert.AreEqual(result[i].FirstName, usersResponse[i].FirstName);
                Assert.AreEqual(result[i].LastName, usersResponse[i].LastName);
                Assert.AreEqual(result[i].Email, usersResponse[i].Email);
            }
        }

        [TestMethod]
        [TestCategory("User")]
        public async Task GetById_Ok()
        {
            var user = userFakedata.GetAllUsersModel()[0];
            var id = 6;

            userActionMock.Setup(u => u.GetById(id))
                .ReturnsAsync(user);
            var userResponse = userFormatter.ToUserResponse(user);
            var domain = new UserDomain(userActionMock.Object);
            var result = await domain.GetById(id.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, userResponse.Id);
            Assert.AreEqual(result.FirstName, userResponse.FirstName);
            Assert.AreEqual(result.LastName, userResponse.LastName);
            Assert.AreEqual(result.Email, userResponse.Email);
        }

        [ExpectedException(typeof(UserIdNotFoundException))]
        [TestMethod]
        [TestCategory("User")]
        public async Task GetById_Exception()
        {
            var user = userFakedata.GetAllUsersModel()[0];
            var id = 6;

            userActionMock.Setup(u => u.GetById(id))
                .ThrowsAsync(new UserIdNotFoundException());

            var userResponse = userFormatter.ToUserResponse(user);
            var domain = new UserDomain(userActionMock.Object);
            var result = await domain.GetById(id.ToString());
        }

        [TestMethod]
        [TestCategory("User")]
        public async Task CreateUser_Ok()
        {
            var user = userFakedata.GetAllUsersModel()[0];

            userActionMock.Setup(u => u.Create(user))
                .ReturnsAsync(user);

            var domain = new UserDomain(userActionMock.Object);
            var result = await domain.Create(user);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, user);
        }

        [TestMethod]
        [TestCategory("User")]
        public async Task UpdateUser_Ok()
        {
            var user = userFakedata.GetAllUsersModel()[1];
            var id = 2;

            userActionMock.Setup(u => u.Update(id, user))
                .ReturnsAsync(user);
            var userResponse = userFormatter.ToUserResponse(user);
            var domain = new UserDomain(userActionMock.Object);
            var result = await domain.Update(id.ToString(), user);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, userResponse.Id);
            Assert.AreEqual(result.FirstName, userResponse.FirstName);
            Assert.AreEqual(result.LastName, userResponse.LastName);
            Assert.AreEqual(result.Email, userResponse.Email);
        }
    }
}
