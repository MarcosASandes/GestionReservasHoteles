using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Actividad : IValidable, IComparable<Actividad>
    {
        #region Atributos ACTIVIDAD
        public int Id { get; }
        public static int LastId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadMaxima { get; set; }
        public int EdadMinima { get; set; }
        public int Costo { get; set; }
        public int CupoDisponible { get; set; }
        public bool Activo { get; set; }
        #endregion

        #region Constructores
        public Actividad()
        {
            Id = LastId;
            LastId++;
            CupoDisponible = CantidadMaxima;
            Activo = true;
        }

        public Actividad(string nombreActividad, string descripcionActividad, DateTime fechaActividad, int cantMaxActividad, int edadMinActividad, int costoActividad)
        {
            Id = LastId;
            LastId++;
            Nombre = nombreActividad;
            Descripcion = descripcionActividad;
            Fecha = fechaActividad;
            CantidadMaxima = cantMaxActividad;
            EdadMinima = edadMinActividad;
            Costo = costoActividad;
            CupoDisponible = CantidadMaxima;
            Activo = true;
        }
        #endregion

        public virtual void BajarCupo()
        {
            CupoDisponible--;
        }

        #region VALIDAR
        public virtual void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            //ValidarFecha();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre) || Nombre.Length > 25)
            {
                throw new Exception("Nombre incorrecto.");
            }
        }

        private void ValidarDescripcion()
        {
           if (string.IsNullOrEmpty(Descripcion))
           {
               throw new Exception("Descripcion incorrecto: no puede ser nula.");
           }
            
        }

        /*private void ValidarFecha()
        {
            if (Fecha < DateTime.Now)
            {
                throw new Exception("Fecha incorrecta.");
            }
        }*/
        #endregion

        public abstract string GetTipo();

        public abstract double GetDescuentoPrecio(Huesped h);

        public abstract string esGratuita();

        public override string ToString()
        {
            return $"{Id} - {Nombre} - {Descripcion} - {Fecha} - {CantidadMaxima} - {EdadMinima}";
        }

        public int CompareTo(Actividad? other)
        {
            if (Costo.CompareTo(other.Costo) > 0)
            {
                return 1;
            }
            else if (Costo.CompareTo(other.Costo) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
