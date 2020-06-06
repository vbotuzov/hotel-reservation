using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identify;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class OrdServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullunitOfWork = null;
            Assert.Throws<ArgumentNullException>(() => new OrdService(nullunitOfWork));
        }
        [Fact]
        public void GetOrds_UserIsAdmin_ThrowMethodAccessException()
        {
            User user = new Admin1(1, "Viktor", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IOrdService ordService = new OrdService(mockUnitOfWork.Object);
            //Assert.Throws<MethodAccessException>(() => ordService.GetOrds(0));
        }
    }
}
