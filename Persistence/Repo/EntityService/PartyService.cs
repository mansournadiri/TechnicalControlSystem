using Application.Feature.Auth.Request.Command;
using Application.Persistence.Interface;
using Application.Persistence.Interface.IEntity;
using Common.Interface;
using Domain.Entity;

namespace Persistence.Repo.EntityService
{
    public class PartyService : IPartyService
    {
        private readonly IBaseRepo<Party> _baseRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommon _common;
        public PartyService(
            IBaseRepo<Party> baseRepo,
            IUnitOfWork unitOfWork,
            ICommon common)
        {
            _baseRepo = baseRepo;
            _unitOfWork = unitOfWork;
            _common = common;
        }
        public async Task<long> Regiter(RegisterViewModel request)
        {
            var exist = await _baseRepo.IsExistAsync(x => x.CompanyIdentity == request.companyIdentity);
            if (exist)
                return _baseRepo.Find(x => x.CompanyIdentity == request.companyIdentity).PartyId;
            Party company = new Party();
            company.CompanyIdentity = request.companyIdentity;
            company.CompanyName = request.companyName;
            company.NationalId = request.nationalID;
            company.Mobile = request.mobileNumber;
            company.PartyId = _baseRepo.MaxKey(x => x.PartyId);
            company.Type = 1;
            company.CreationDate = DateTime.Now;
            company.Email = request.mailAddress;
            company = await _baseRepo.AddAsync(company);
            int numberRowEffected = _unitOfWork.SaveChanges();
            if (numberRowEffected > 0)
                return company.PartyId;
            else
                return 0;
        }
    }
}
