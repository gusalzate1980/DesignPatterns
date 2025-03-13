using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Estructural
{
    public static class Decorator
    {
        public static void ExecuteDecorator()
        {
            IClienteReportado reportado = new ClienteReportadoDataCredito();
            reportado = new DecoratorTransUnion(reportado);
            reportado = new DecoratorProcredito(reportado);

            Console.WriteLine("el cliente 94151786 " + (reportado.ClienteEstaReportado(94151784) ? " Esta reportado" : " No es esta reportado"));

        }
    }

    public interface IClienteReportado
    {
        public bool ClienteEstaReportado(long cedula);
    }

    public class ClienteReportadoDataCredito : IClienteReportado
    {
        public bool ClienteEstaReportado(long cedula)
        {
            if (cedula % 2 == 0)
            {
                Console.WriteLine("reportado en data credito");
                return true;
            }

            return false;
        }
    }

    public class DecoratorTransUnion : IClienteReportado
    {
        IClienteReportado cliente;

        public DecoratorTransUnion(IClienteReportado iCliente)
        {
            cliente = iCliente;
        }
        public bool ClienteEstaReportado(long cedula)
        {
            bool result = cliente.ClienteEstaReportado(cedula);

            string ultimoCaracter = cedula.ToString().ElementAt(cedula.ToString().Length - 1).ToString();
            List<string> lista = new List<string>() { "0", "1", "2", "3", "4" };
            if (lista.Contains(ultimoCaracter))
            {
                Console.WriteLine("reportado en Transunion");
                return true;
            }

            return false || result;
        }
    }

    public class DecoratorProcredito : IClienteReportado
    {
        IClienteReportado cliente;
        public DecoratorProcredito(IClienteReportado iCliente)
        {
            cliente = iCliente;
        }
        public bool ClienteEstaReportado(long cedula)
        {
            bool result = cliente.ClienteEstaReportado(cedula);
            if (cedula == 94151785)
            {
                Console.WriteLine("reportado en Procredito");
                return true;
            }

            return false || result;
        }
    }
}
