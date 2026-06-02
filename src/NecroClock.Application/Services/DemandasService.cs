using NecroClock.Application.Interfaces;
using NecroClock.Application.Interfaces.Repositories;
using NecroClock.Application.Models;
using NecroClock.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Services
{
    public class DemandasService : IDemandasService
    {
        private readonly IDemandasRepositorie _demandaRepositorie;
        public DemandasService(
            IDemandasRepositorie demandasRepositorie
            )
        {
            _demandaRepositorie = demandasRepositorie;
        }

        public async Task<bool> AddDemanda(DemandaDTO dto, long userID)
        {
            DemandaModel model = new DemandaModel();
            model.NumeroDemanda = dto.NumeroDemanda;
            model.Descricao = dto.Descricao;
            model.Data = dto.Data;
            model.Horas = dto.Horas;
            model.UserId = userID;

            await _demandaRepositorie.AddDemanda(model);

            return true;
        }

        public async Task<bool> UpdateDemanda(DemandaDTO dto, long userID)
        {
            DemandaModel model = await _demandaRepositorie.GetDemandaByIdAndUserID(dto.Id, userID);
            if (model == null)
            {
                throw new Exception("Demanda não encontrada.");
            }

            model.Descricao = dto.Descricao;
            model.Data = dto.Data;
            model.Horas = dto.Horas;

            await _demandaRepositorie.UpdateDemanda(model);

            return true;
        }

        public async Task<bool> DeleteDemanda(long demandaID, long userID)
        {
            DemandaModel model = await _demandaRepositorie.GetDemandaByIdAndUserID(demandaID, userID);
            if (model == null)
            {
                throw new Exception("Demanda não encontrada.");
            }
            await _demandaRepositorie.DeleteDemanda(model);
            return true;
        }

        public async Task<List<DemandaDTO>> GetDemandas(DateOnly inicio, DateOnly fim, long userID)
        {
            List<DemandaModel> demandas = await _demandaRepositorie.GetDemandasByIntervalAndUserId(inicio, fim, userID);
            return DemandaDTO.GenerateList(demandas);
        }

        public async Task<List<DemandaDTO>> FiltrarDemandas(string busca, long userID)
        {
            List<DemandaModel> demandas = await _demandaRepositorie.FilterDemandasBySearchTermAndUserID(busca, userID);
            return DemandaDTO.GenerateList(demandas);
        }
    }
}
