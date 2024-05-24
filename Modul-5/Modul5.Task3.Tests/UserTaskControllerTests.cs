using Modul5.Task3.DoNotChange;
using Modul5.Task3.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task3.Tests
{
    [TestFixture]
    public class UserTaskControllerTests
    {
        private readonly UserTaskController _controller;
        private readonly IUserDao _userDao;

        public UserTaskControllerTests()
        {
            _userDao = new UserDaoStub();
            var taskService = new UserTaskService(_userDao);
            _controller = new UserTaskController(taskService);
        }

        [Test]
        public void CreateUserTask_ValidData_ReturnsTaskAndEmptyMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(model.GetActionResult(), Is.Null);
            Assert.That(_userDao.GetUser(userId).Tasks.Count, Is.EqualTo(4));
            StringAssert.AreEqualIgnoringCase(_userDao.GetUser(userId).Tasks[3].Description, description);
        }

        [Test]
        public void CreateUserTask_InvalidUserId_ReturnsNullAndInvalidUserIdMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = -11, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "Invalid userId");
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndUserNotFoundMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 2, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "User not found");
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndTheTaskAlreadyExistsMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 2, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "User not found");
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }
    }
}
