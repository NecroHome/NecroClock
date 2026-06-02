using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Util
{
    public static class DataUtil
    {
        public static DateOnly ObterInicioSemana(DateOnly data)
        {
            DateOnly primeiroDiaMes = new(data.Year, data.Month, 1);

            DateOnly inicioSemana = data.AddDays(-(int)data.DayOfWeek);

            return inicioSemana < primeiroDiaMes
                ? primeiroDiaMes
                : inicioSemana;
        }

        public static DateOnly ObterFimSemana(DateOnly data)
        {
            DateOnly primeiroDiaMes = new(data.Year, data.Month, 1);
            DateOnly ultimoDiaMes = primeiroDiaMes.AddMonths(1).AddDays(-1);

            DateOnly inicioSemana = data.AddDays(-(int)data.DayOfWeek);
            DateOnly fimSemana = inicioSemana.AddDays(6);

            return fimSemana > ultimoDiaMes
                ? ultimoDiaMes
                : fimSemana;
        }
    }
}
