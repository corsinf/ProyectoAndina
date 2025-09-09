// Controllers/LoginController.cs
using ProyectoAndina.Data;
using ProyectoAndina.Models;
// Controllers/PersonaController.cs
using System.Collections.Generic;


namespace ProyectoAndina.Controllers
{
    public class LoginController
    {
        private readonly PersonaController _PersonaController;

        public LoginController()
        {
            _PersonaController = new PersonaController();
        }

        public PersonaM Autenticar(string cedula, string password)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(password))
            {
                return new PersonaM { EsValido = false };
            }

            return _PersonaController.ValidarUsuario(cedula, password);
        }
    }
}


