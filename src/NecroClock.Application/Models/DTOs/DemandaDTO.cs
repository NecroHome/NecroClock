using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Models.DTOs
{
    public class DemandaDTO
    {
        public long Id { get; set; }
        public string NumeroDemanda { get; set; }
        public string Descricao { get; set; }
        public DateOnly Data { get; set; }
        public long Horas { get; set; }
        public long UserId { get; set; }

        public DemandaDTO()
        {

        }

        public DemandaDTO(DemandaModel model)
        {
            Id = model.Id;
            NumeroDemanda = model.NumeroDemanda;
            Descricao = model.Descricao;
            Data = model.Data;
            Horas = model.Horas;
            UserId = model.UserId;
        }

        public static List<DemandaDTO> GenerateList(List<DemandaModel> list)
        {
            List<DemandaDTO> retorno = new List<DemandaDTO>();
            foreach (DemandaModel model in list)
            {
                retorno.Add(new DemandaDTO(model));
            }
            return retorno;
        }
    }
}
