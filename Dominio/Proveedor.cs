using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor : IValidable, IComparable<Proveedor>
    {
        #region Atributos PROVEEDOR
        public int Id { get; }
        public static int LastId { get; set; } = 1;
        public string Nombre { get; set; }
        public string NumeroContacto { get; set; }
        public string Direccion { get; set; }
        public double Descuento { get; set; }
        public bool Activo { get; set; }
        #endregion

        #region Constructores
        public Proveedor()
        {
            Id = LastId;
            LastId++;
            Activo = true;
        }

        public Proveedor(string nombre, string numeroContacto, string direccion, int descuento)
        {
            Id = LastId;
            LastId++;
            Nombre = nombre;
            NumeroContacto = numeroContacto;
            Direccion = direccion;
            Descuento = descuento;
            Activo = true;
        }
        #endregion

        #region Validar
        public void Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(NumeroContacto) || string.IsNullOrEmpty(Direccion))
                {
                    throw new Exception("Los campos requeridos no pueden ser vacios.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// Asigna directamente el descuento pasado por parametro a la propiedad del proveedor.
        /// </summary>
        /// <param name="descuento"></param>
        public void EstablecerPromocion(double descuento)
        {
            if (descuento > 0 && descuento <= 100)
            {
                Descuento = descuento;
            }
            else
            {
                throw new Exception("Debe ser un porcentaje, de 1 a 100.");
            }
        }


        public override string ToString()
        {
            return $"{Id} {Nombre} - Telefono: {NumeroContacto} - Direccion: {Direccion} - Descuento: {Descuento}%";
        }

        #region Equals y CompareTo
        public int CompareTo(Proveedor? other)
        {
            if (Nombre.CompareTo(other.Nombre) > 0)
            {
                return 1;
            }
            else if (Nombre.CompareTo(other.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Proveedor proveedor &&
                   Nombre == proveedor.Nombre;
        }
        #endregion
    }
}
