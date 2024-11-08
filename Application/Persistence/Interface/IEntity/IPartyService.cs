using Application.Feature.Auth.Request.Command;

namespace Application.Persistence.Interface.IEntity
{
    public interface IPartyService
    {
        public Task<long> Regiter(RegisterViewModel request);
    }
}
