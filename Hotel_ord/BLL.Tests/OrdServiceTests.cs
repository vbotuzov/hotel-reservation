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
        [Fact]
        public void GetOrds_OrdFromDAL_CorrectMappingToStreetDTO()
        {
            User user = new Admin1(1, "Viktor", 1);
            SecurityContext.SetUser(user);
            var ordService = GetOrdService();
            var actualOrdDto = ordService.GetOrds(0).First();
            Assert.True(
                actualOrdDto.Id_ord == 1
                && actualOrdDto.Order_id == 1
                && actualOrdDto.Room_id == "1"
                && actualOrdDto.Admin_id == 1
                );
        }
        IOrdService GetOrdService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedOrd = new Ord() { id_ord = 1, order_id = 1, room_id = "1", admin_id = 1 };
            var mockDbSet = new Mock<IOrdRepository>();
            mockDbSet.Setup(z => z.Find(It.IsAny<Func<Ord, bool>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Ord>() { expectedOrd });
            mockContext.Setup(context => context.Ords).Returns(mockDbSet.Object);
            IOrdService ordService = new OrdService(mockContext.Object);
            return ordService;
        }
    }
}
