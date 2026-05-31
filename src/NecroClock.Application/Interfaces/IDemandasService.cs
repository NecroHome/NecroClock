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
        Task<List<DemandaDTO>> GetDemandas(DateTime inicio, DateTime fim, long userID);
    }
}
