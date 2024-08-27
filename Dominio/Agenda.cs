using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda : IValidable, IComparable<Agenda>
    {
        #region Atributos AGENDA
        public int Id { get; set; }
        public static int LastId { get; set; } = 1;
        public DateTime FechaAgenda { get; set; }
        public Huesped HuespedAgenda { get; set; }
        public Actividad ActAgenda { get; set; }
        public double Costo { get; set; }
        public string Estado { get; set; }
        #endregion

        #region Constructores
        public Agenda()
        {
            Id = LastId;
            LastId++;
            CerrarCosto();
            ActAgenda.BajarCupo();
        }

        public Agenda(Huesped unHuesped, Actividad unaAct)
        {
            Id = LastId;
            LastId++;
            FechaAgenda = DateTime.Now;
            ActAgenda = unaAct;
            HuespedAgenda = unHuesped;
            CerrarCosto();
            ActAgenda.BajarCupo();
            Estado = GetEstado();
        }
        #endregion


        public string MostrarLugar()
        {
            string lugar = "";
            if (ActAgenda.GetTipo() == "Propia")
            {
                ActividadPropia aux = ActAgenda as ActividadPropia;
                lugar = aux.LugarHostal;
            }
            else
            {
                ActividadTercerizada auxTerc = ActAgenda as ActividadTercerizada;
                lugar = $"Oficinas de {auxTerc.ProveedorActividad.Nombre}";
            }
            return lugar;
        }


        public string MostrarNombreProv()
        {
            string nombre = "";
            if (ActAgenda.GetTipo() == "Tercerizada")
            {
                ActividadTercerizada aux = ActAgenda as ActividadTercerizada;
                nombre = aux.ProveedorActividad.Nombre;
            }
            return nombre;
        }

        public string MostrarGratuita()
        {
            string ret = Convert.ToString(Costo) + "USD";
            if (Costo == 0)
            {
                ret = "Actividad gratuita";
            }
            return ret;
        }



        public void CerrarCosto()
        {
            try
            {
                if (Costo == 0)
                {
                    Costo = Math.Ceiling(ActAgenda.GetDescuentoPrecio(HuespedAgenda));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Si la actividad es gratuita, el estado sera "Confirmada", sino, aparecera "Pendiente_Pago"
        /// </summary>
        /// <returns></returns>
        public string GetEstado()
        {
            string retorno = "";
            if(Costo == 0)
            {
                retorno = "CONFIRMADA";
            }
            else if(Costo >  0)
            {
                retorno = "PENDIENTE_PAGO";
            }

            return retorno;
        }

        #region BLOQUE VALIDAR AGENDA.
        public void Validar()
        {
            try
            {
                ValidarNombre();
                ValidarApellido();
                ValidarNombreActividad();
                //ValidarFechaActividad();

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(HuespedAgenda.Nombre))
            {
                throw new Exception("El nombre no puede estar vacio.");
            }
        }
        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(HuespedAgenda.Apellido))
            {
                throw new Exception("El apellido no puede estar vacio.");
            }
        }
        private void ValidarNombreActividad()
        {
            if (string.IsNullOrEmpty(ActAgenda.Nombre))
            {
                throw new Exception("El nombre de la actividad no puede estar vacio.");
            }
        }
        /*
        private void ValidarFechaActividad()
        {
            if(FechaActividad < DateTime.Now)
            {
                throw new Exception("La fecha de la actividad ya sucedio.");
            }
        }*/
        #endregion


        public override string ToString()
        {
            return $"{FechaAgenda.ToShortDateString()} - {HuespedAgenda.Nombre} {HuespedAgenda.Apellido} - {ActAgenda.Nombre} - {ActAgenda.Fecha.ToShortDateString()} - Lugar: {MostrarLugar()} - Costo: {MostrarGratuita()} - {GetEstado()} | {MostrarNombreProv()}";
        }

        #region Equals
        /*
        public override bool Equals(object? obj)
        {
            return obj is Agenda agenda &&
                   FechaAgenda == agenda.FechaAgenda &&
                   Nombre == agenda.Nombre &&
                   Apellido == agenda.Apellido &&
                   NombreActividad == agenda.NombreActividad &&
                   FechaActividad == agenda.FechaActividad &&
                   Lugar == agenda.Lugar &&
                   Costo == agenda.Costo &&
                   Estado == agenda.Estado &&
                   NombreProveedor == agenda.NombreProveedor;
        }*/
        #endregion




        public int CompareTo(Agenda? other)
        {
            if (ActAgenda.Fecha.CompareTo(other.ActAgenda.Fecha) > 0)
            {
                return 1;
            }
            else if (ActAgenda.Fecha.CompareTo(other.ActAgenda.Fecha) < 0)
            {
                return -1;
            }
            else
            {
                if (ActAgenda.Nombre.CompareTo(other.ActAgenda.Nombre) > 0)
                {
                    return 1;
                }
                else if (ActAgenda.Nombre.CompareTo(other.ActAgenda.Nombre) < 0)
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
}
