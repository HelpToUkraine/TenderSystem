using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using DAL.Entities;
using DAL.Entities.Enum;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class TenderService
        : ITenderService
    {
        private readonly IUnitOfWork _database;

        public TenderService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<TenderDTO> GetTenders()
        {
            var user = SecurityContext.GetUser();

            if (user.UserType != Role.Client
                && user.UserType != Role.Administrator) // &&
            {
                throw new MethodAccessException();
            }
            var userId = user.UserId;
            var tendersEntities =
                _database
                    .Tenders
                    .Find(t => t.UserId == userId);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Tender, TenderDTO>()
                    ).CreateMapper();
            var tendersDto =
                mapper
                    .Map<IEnumerable<Tender>, List<TenderDTO>>(
                        tendersEntities);
            return tendersDto;
        }

        public void AddTender(TenderDTO tender)
        {
            var user = SecurityContext.GetUser();

            if (user.UserType != Role.Client
                && user.UserType != Role.Administrator)
            {
                throw new MethodAccessException();
            }
            if (tender == null)
            {
                throw new ArgumentNullException(nameof(tender));
            }

            validate(tender);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TenderDTO, Tender>()).CreateMapper();
            var tenderEntity = mapper.Map<TenderDTO, Tender>(tender);
            _database.Tenders.Create(tenderEntity);
        }

        private void validate(TenderDTO tender)
        {
            if (string.IsNullOrEmpty(tender.Description))
            {
                throw new ArgumentException("Description повинне містити значення!");
            }
        }
    }
}