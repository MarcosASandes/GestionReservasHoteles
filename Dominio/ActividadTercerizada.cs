using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadTercerizada : Actividad
    {
        #region Atributos ACTIVIDAD TERCERIZADA
        public Proveedor ProveedorActividad { get; set; }
        public bool EstaConfirmada { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        #endregion

        #region Constructores
        public ActividadTercerizada() : base()
        {
            
        }

        public ActividadTercerizada(Proveedor proveedorActividad, bool estaConfirmada, string nombreActividad, string descripcionActividad, DateTime fechaActividad, int cantMaxActividad, int edadMinActividad, int costoActividad) : base(nombreActividad, descripcionActividad, fechaActividad, cantMaxActividad, edadMinActividad, costoActividad)
        {
            ProveedorActividad = proveedorActividad;
            EstaConfirmada = estaConfirmada;
            actConfirmadaFecha();
        }
        #endregion

        #region Bloque validar
        public void Validar()
        {
            try
            {
                base.Validar();
                ValidarProveedor();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarProveedor()
        {
            if (ProveedorActividad == null)
            {
                throw new Exception("El proveedor es nulo");
            }
        }
        #endregion


        

        public override string GetTipo()
        {
            return "Tercerizada";
        }


        public override double GetDescuentoPrecio(Huesped h)
        {
            double descuento = 0;
            if (EstaConfirmada)
            {
                descuento = 1 - (ProveedorActividad.Descuento / 100);
            }
            else
            {
                throw new Exception("La actividad no esta confirmada aun.");
            }

            return Costo * descuento;
        }




        #region Metodos para mejorar la visualizacion en ToString
        public override string esGratuita()
        {
            string retorno = "";
            if(Costo == 0)
            {
                retorno = "Actividad gratuita";
            }
            else
            {
                retorno = Costo.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Si la fecha de confirmacion es true, en el ToString aparece como "Confirmada", sino, aparece "No confirmada" y se le agrega la fecha en que se confirmara.
        /// </summary>
        /// <returns></returns>
        public string esConfirmada()
        {
            string retorno = "";
            if (EstaConfirmada)
            {
                retorno = "Confirmada.";
            }
            else if (!EstaConfirmada)
            {
                retorno = "No confirmada";
            }
            return retorno;
        }

        private void actConfirmadaFecha()
        {
            if (EstaConfirmada)
            {
                FechaConfirmacion = DateTime.Now;
            }
            else
            {
                FechaConfirmacion = null;
            }
        }
        #endregion

        public override string ToString()
        {
            return $"{Id} - Actividad Tercerizada | Proveedor: {ProveedorActividad.Nombre} - {esConfirmada()} - {Nombre} - {Descripcion} - {Fecha.ToShortDateString()} - Capacidad: {CantidadMaxima} Cupo: {CupoDisponible} - Edad minima: {EdadMinima} - Costo: {esGratuita()}";
        }

        #region Equals
        public override bool Equals(object? obj)
        {
            return obj is ActividadTercerizada tercerizada &&
                   base.Equals(obj) &&
                   Nombre == tercerizada.Nombre &&
                   Descripcion == tercerizada.Descripcion &&
                   Fecha == tercerizada.Fecha &&
                   CantidadMaxima == tercerizada.CantidadMaxima &&
                   EdadMinima == tercerizada.EdadMinima &&
                   Costo == tercerizada.Costo &&
                   EqualityComparer<Proveedor>.Default.Equals(ProveedorActividad, tercerizada.ProveedorActividad);
        }
        #endregion
    }
}
