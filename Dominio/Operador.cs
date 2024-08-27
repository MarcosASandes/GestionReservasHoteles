using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador : Usuario
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaInicio { get; set; }


        public Operador() : base()
        {

        }

        public Operador(string nombre, string apellido, DateTime fechaInicio, string email, string contrasenia) : base(email, contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaInicio = fechaInicio;
            Email = email;
            Contrasenia = contrasenia;
        }


        #region VALIDAR
        public void Validar()
        {
            try
            {
                base.Validar();
                ValidarNombre();
                ValidarApellido();
                ValidarFecha();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio.");
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede ser vacio.");
            }
        }

        private void ValidarFecha()
        {
            if (DateTime.Now < FechaInicio)
            {
                throw new Exception("Fecha de nacimiento incorrecta.");
            }
        }
        #endregion


        public override string GetTipo()
        {
            return "Operador";
        }
    }
}
