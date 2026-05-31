using NecroClock.Application.Models;
using NecroClock.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Interfaces.Repositories
{
    public interface IDemandasRepositorie
    {
        Task<bool> AddDemanda(DemandaModel model);
        Task<DemandaModel> GetDemandaByIdAndUserID(long demandaId, long userID);
        Task<bool> UpdateDemanda(DemandaModel model);
        Task<bool> DeleteDemanda(DemandaModel model);
        Task<List<DemandaModel>> GetDemandasByIntervalAndUserId(DateTime inicio, DateTime fim, long userID);
    }
}
