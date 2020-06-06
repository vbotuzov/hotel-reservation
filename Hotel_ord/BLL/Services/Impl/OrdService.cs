using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identify;

namespace BLL.Services.Impl
{
    public class OrdService
        : IOrdService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public OrdService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<OrdDTO> OrdStreets(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Client)
                && userType != typeof(Admin1))
            {
                throw new MethodAccessException();
            }
            var ordId = user.OrdID;
            var ordsEntities =
                _database
                    .Ords
                    .Find(z => z.id_ord == ordId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Ord, OrdDTO>()
                    ).CreateMapper();
            var ordsDto =
                mapper
                    .Map<IEnumerable<Ord>, List<OrdDTO>>(
                        ordsEntities);
            return ordsDto;
        }

        public void AddStreet(OrdDTO ord)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Client)
                || userType != typeof(Admin1))
            {
                throw new MethodAccessException();
            }
            if (ord == null)
            {
                throw new ArgumentNullException(nameof(ord));
            }

            validate(ord);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrdDTO, Ord>()).CreateMapper();
            var ordEntity = mapper.Map<OrdDTO, Ord>(ord);
            _database.Ords.Create(ordEntity);
        }

        private void validate(OrdDTO ord)
        {
            if (string.IsNullOrEmpty(ord.Room_id))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }

        IEnumerable<OrdDTO> IOrdService.GetOrds(int page)
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable<OrdDTO> GetOrds(int page)
        {
            throw new NotImplementedException();
        }*/
    }
}