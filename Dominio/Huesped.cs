using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Huesped : Usuario
    {
        #region Atributos HUESPED
        public TipoDoc TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Habitacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int NivelFidelizacion { get; set; }
        #endregion

        #region Constructores
        public Huesped() : base()
        {
            NivelFidelizacion = 1;
        }

        public Huesped(TipoDoc tipoDocumento, int numeroDocumento, string nombre, string apellido, string habitacion, DateTime fechaNacimiento, int nivelFidelizacion, string email, string contrasenia) : base(email, contrasenia)
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Nombre = nombre;
            Apellido = apellido;
            Habitacion = habitacion;
            FechaNacimiento = fechaNacimiento;
            NivelFidelizacion = nivelFidelizacion;
        }
        #endregion

        #region Bloque Validar
        public void Validar()
        {
            try
            {
                base.Validar();
                ValidarCedula();
                ValidarTipoDoc();
                ValidarNombre();
                ValidarApellido();
                ValidarHabitacion();
                ValidarFecha();
                ValidarNivelF();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarCedula()
        {
            if(TipoDocumento == TipoDoc.CI)
            {
                string cedula = Convert.ToString(NumeroDocumento);
                if (cedula.Length == 8)
                {
                    int primerNum = Int32.Parse(cedula.Substring(0, 1));
                    int segundoNum = Int32.Parse(cedula.Substring(1, 1));
                    int tercerNum = Int32.Parse(cedula.Substring(2, 1));
                    int cuartoNum = Int32.Parse(cedula.Substring(3, 1));
                    int quintoNum = Int32.Parse(cedula.Substring(4, 1));
                    int sextoNum = Int32.Parse(cedula.Substring(5, 1));
                    int septimoNum = Int32.Parse(cedula.Substring(6, 1));

                    int verificador = Int32.Parse(cedula.Substring(7, 1));

                    int sumaTotal = (primerNum * 2) + (segundoNum * 9) + (tercerNum * 8) + (cuartoNum * 7) + (quintoNum * 6) + (sextoNum * 3) + (septimoNum * 4);
                    int verificadorCalculado = (10 - (sumaTotal % 10)) % 10;

                    if (verificador != verificadorCalculado)
                    {
                        throw new Exception("La cedula no es correcta.");
                    }
                }
                else
                {
                    throw new Exception("La cedula no tiene ocho caracteres.");
                }
            }
        }

        private void ValidarTipoDoc()
        {
            if(TipoDocumento == TipoDoc.Defecto)
            {
                throw new Exception("Seleccione un tipo de documento correcto(CI, Pasaporte, Otros).");
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

        private void ValidarHabitacion()
        {
            if (string.IsNullOrEmpty(Habitacion))
            {
                throw new Exception("La habitacion no puede ser vacio.");
            }
        }

        private void ValidarFecha()
        {
            if (DateTime.Now < FechaNacimiento)
            {
                throw new Exception("Fecha de nacimiento incorrecta.");
            }
        }

        private void ValidarNivelF()
        {
            if (NivelFidelizacion < 1 || NivelFidelizacion > 4)
            {
                throw new Exception("Hubo un error con su nivel de fidelizacion.");
            }
        }
        #endregion


        public override string GetTipo()
        {
            return "Huesped";
        }

        public override string ToString()
        {
            return $"{Id} - {Apellido}, {Nombre} - {TipoDocumento} {NumeroDocumento} - Habitacion: {Habitacion} - Fecha de nacimiento: {FechaNacimiento.ToShortDateString()} - Categoria: {NivelFidelizacion}";
        }


        public int GetEdad()
        {
            int edad = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;
            return edad;
        }


        #region Equals
        public override bool Equals(object? obj)
        {
            return obj is Huesped huesped &&
                   TipoDocumento == huesped.TipoDocumento &&
                   NumeroDocumento == huesped.NumeroDocumento;
        }
        #endregion
    }
}
