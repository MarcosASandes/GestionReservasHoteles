using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        #region Atributos USUARIO
        public int Id { get; }
        public static int LastId { get; set; } = 1;
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
        #endregion

        #region Constructores
        public Usuario()
        {
            Id = LastId;
            LastId++;
            Activo = true;
        }
        public Usuario(string email, string contrasenia)
        {
            Id = LastId;
            LastId++;
            Email = email;
            Contrasenia = contrasenia;
            Activo = true;
        }
        #endregion

        #region Bloque Validar
        public virtual void Validar()
        {
            try
            {
                ValidarEmail();
                ValidarPass();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ValidarEmail()
        {
            char arroba = '@';
            if(string.IsNullOrEmpty(Email))
            {
                throw new Exception("El email no puede ser vacio.");
            }

            if(Email.Contains(arroba) != true) 
            {
                throw new Exception("El correo no contiene @.");
            }
            else
            {
                for (int i = 0; i < Email.Length; i++)
                {
                    if (Email[0] == arroba || Email[Email.Length-1] == arroba)
                    {
                        throw new Exception("El @ no puede estar al principio ni al final del correo.");
                    }
                }
            }
        }
        private void ValidarPass()
        {
            if(Contrasenia.Length < 8)
            {
                throw new Exception("La clave debe tener al menos ocho caracteres.");
            }
        }
        #endregion

        public abstract string GetTipo();

    }
}
