using NecroClock.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Interfaces
{
    public interface IDemandasService
    {
        Task<bool> AddDemanda(DemandaDTO dto, long userID);
        Task<bool> UpdateDemanda(DemandaDTO dto, long userID);
        Task<bool> DeleteDemanda(long demandaID, long userID);
        Task<List<DemandaDTO>> GetDemandas(DateOnly inicio, DateOnly fim, long userID);
        Task<List<DemandaDTO>> FiltrarDemandas(string busca, long userID);
    }
}
