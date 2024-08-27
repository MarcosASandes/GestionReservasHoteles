using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadPropia : Actividad
    {
        #region Atributos ACTIVIDAD PROPIA
        public string Responsable { get; set; }
        public string LugarHostal { get; set; }
        public bool AlAireLibre { get; set; }
        #endregion

        #region Constructores
        public ActividadPropia() : base()
        {
            
        }

        public ActividadPropia(string responsable, string lugarDentroHostal, bool esAlAireLibre, string Nombre, string Descripcion, DateTime Fecha, int CantidadMaxima, int EdadMinima, int Costo) : base(Nombre, Descripcion, Fecha, CantidadMaxima, EdadMinima, Costo)
        {
            Responsable = responsable;
            LugarHostal = lugarDentroHostal;
            AlAireLibre = esAlAireLibre;
        }
        #endregion

        #region Bloque Validar
        public void Validar()
        {
            try
            {
                base.Validar();
                ValidarResponsable();
                ValidarLugarHostal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarResponsable()
        {
            if (string.IsNullOrEmpty(Responsable))
            {
                throw new Exception("El responsable no puede estar vacio.");
            }
        }

        private void ValidarLugarHostal()
        {
            if (string.IsNullOrEmpty(LugarHostal))
            {
                throw new Exception("El lugar no puede estar vacio.");
            }
        }
        #endregion


        public override string GetTipo()
        {
            return "Propia";
        }

        /// <summary>
        /// Si el costo es cero, se muestra en el ToString "Actividad gratuita", sino, se muestra el costo.
        /// </summary>
        /// <returns>String</returns>
        public override string esGratuita()
        {
            string retorno = "";
            if (Costo == 0)
            {
                retorno = "Actividad gratuita";
            }
            else
            {
                retorno = Costo.ToString();
            }
            return retorno;
        }
        public string esAlAireLibre()
        {
            string retorno = "";
            if (AlAireLibre)
            {
                retorno = "Si.";
            }
            else
            {
                retorno = "No.";
            }
            return retorno;
        }


        public override double GetDescuentoPrecio(Huesped h)
        {
            double desc = Costo;

            if (h.NivelFidelizacion == 2)
            {
                desc = Costo * 0.90;
            }
            if (h.NivelFidelizacion == 3)
            {
                desc = Costo * 0.85;
            }
            if (h.NivelFidelizacion == 4)
            {
                desc = Costo * 0.80;
            }

            return desc;
        }




        public override string ToString()
        {
            return $"{Id} - Actividad Propia | Responsable: {Responsable} - Lugar: {LugarHostal} | Al aire libre: {esAlAireLibre()} - {Nombre} - {Descripcion} - {Fecha.ToShortDateString()} - Capacidad: {CantidadMaxima} Cupo: {CupoDisponible} - Edad minima: {EdadMinima} - Costo: {esGratuita()}";
        }

        #region Equals
        public override bool Equals(object? obj)
        {
            return obj is ActividadPropia propia &&
                   Nombre == propia.Nombre &&
                   Descripcion == propia.Descripcion &&
                   Fecha == propia.Fecha &&
                   CantidadMaxima == propia.CantidadMaxima &&
                   EdadMinima == propia.EdadMinima &&
                   Costo == propia.Costo &&
                   Responsable == propia.Responsable &&
                   LugarHostal == propia.LugarHostal &&
                   AlAireLibre == propia.AlAireLibre;
        }
        #endregion
    }
}
