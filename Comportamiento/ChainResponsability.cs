using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Comportamiento
{
    public class ChainResponsability:IDesignPattern
    {
        public void ExecutePattern()
        {
            IValidarLogin login = new ValidarLoginCredenciales(new ValidarLoginClientePago(new ValidarLoginUsuariosConectados()));
            Console.WriteLine("Pudo Acceder ?: " + (login.UsuarioPuedeAcceder("gusalzate1980@gmail.com", "123") ? "Si" : "Nop"));
        }
    }

    public interface IValidarLogin
    {
        public bool UsuarioPuedeAcceder(string email, string password);
    }

    public class ValidarLoginCredenciales : IValidarLogin
    {
        public IValidarLogin next;
        public ValidarLoginCredenciales(IValidarLogin pNext)
        {
            next = pNext;
        }
        public bool UsuarioPuedeAcceder(string email, string password)
        {
            if (!email.Equals("gusalzate1980@gmail.com") || !password.Equals("123"))
            {
                return false;
            }

            return next.UsuarioPuedeAcceder(email, password);
        }
    }

    public class ValidarLoginClientePago : IValidarLogin
    {
        public IValidarLogin next;
        public ValidarLoginClientePago(IValidarLogin pNext)
        {
            next = pNext;
        }
        public bool UsuarioPuedeAcceder(string email, string password)
        {
            bool clientePago = true;
            if (!clientePago)
            {
                return false;
            }

            return next.UsuarioPuedeAcceder(email, password);
        }
    }

    public class ValidarLoginUsuariosConectados : IValidarLogin
    {
        public IValidarLogin next;
        public bool UsuarioPuedeAcceder(string email, string password)
        {
            int usuariosConectados = 4;
            int usuairosPermitidos = 5;
            if (usuariosConectados < usuairosPermitidos)
            {
                return true;
            }

            return false;
        }
    }
}
