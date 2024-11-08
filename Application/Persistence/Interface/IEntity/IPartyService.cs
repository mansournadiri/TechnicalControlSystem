using Application.Base;
using Application.Feature.Auth.Request.Command;
using Application.Feature.Auth.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Interface.IEntity
{
    public interface IPartyService
    {
        public Task<long> Regiter(RegisterViewModel request);
    }
}
