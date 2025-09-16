using System;
using System.Collections.Generic;

namespace ProyectoAndina.Utils
{
    public class ResultadoPaginado<T>
    {
        public List<T> Datos { get; set; }
        public int TotalRegistros { get; set; }
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / RegistrosPorPagina);

        public ResultadoPaginado()
        {
            Datos = new List<T>();
        }
    }

    public class ControladorPaginacion
    {
        public int PaginaActual { get; set; } = 1;
        public int RegistrosPorPagina { get; set; } = 20;
        public int TotalRegistros { get; set; } = 0;
        public int TotalPaginas { get; set; } = 0;
        public string FiltroActual { get; set; } = "";

        public void ActualizarTotales(int totalRegistros)
        {
            TotalRegistros = totalRegistros;
            TotalPaginas = (int)Math.Ceiling((double)totalRegistros / RegistrosPorPagina);
        }

        public void IrAPrimera() => PaginaActual = 1;
        public void IrAAnterior() => PaginaActual = Math.Max(1, PaginaActual - 1);
        public void IrASiguiente() => PaginaActual = Math.Min(TotalPaginas, PaginaActual + 1);
        public void IrAUltima() => PaginaActual = TotalPaginas;

        public bool PuedeIrAnterior => PaginaActual > 1;
        public bool PuedeIrSiguiente => PaginaActual < TotalPaginas;

        public string ObtenerInfoPaginacion()
        {
            if (TotalRegistros == 0) return "No hay registros";

            int desde = ((PaginaActual - 1) * RegistrosPorPagina) + 1;
            int hasta = Math.Min(PaginaActual * RegistrosPorPagina, TotalRegistros);

            return $"Mostrando {desde}-{hasta} de {TotalRegistros} registros | Página {PaginaActual} de {TotalPaginas}";
        }
    }
}