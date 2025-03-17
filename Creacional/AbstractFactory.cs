using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Creacional
{
    public class AbstractFactory : IDesignPattern
    {
        
        public void ExecutePattern()
        {
            string dbType = "SqlServer"; // o "SqlServer"

            IDatabaseFactory factory;

            if (dbType == "Oracle")
            {
                factory = new OracleDatabaseFactory();
            }
            else
            {
                factory = new SqlServerDatabaseFactory();
            }

            IClienteDao clienteActions = factory.CrearClienteDao();
            IProductoDao productoActions = factory.CrearProductoDao();

            // Ejemplo de uso
            Console.WriteLine(clienteActions.GuardarCliente("Juan Pérez"));
            Console.WriteLine(clienteActions.GetClientes(50));
            Console.WriteLine(productoActions.ActualizarInventario(1, 10));
        }
    }

    #region interfaces
    public interface IClienteDao
    {
        string GuardarCliente(string nombre);
        string GetClientes(int idCliente);
    }

    public interface IProductoDao
    {
        string ActualizarInventario(int idProducto, int cantidad);
    }
    
    public interface IDatabaseFactory
    {
        IClienteDao CrearClienteDao();
        IProductoDao CrearProductoDao();
    }
    #endregion

    #region Oracle
    public class OracleClienteDao : IClienteDao
    {
        public string GuardarCliente(string nombre)
        {
            return $"GUARDAR CLIENTE ORACLE";
        }

        public string GetClientes(int idCliente)
        {
            return "SELECT GET CLIENTES ORACLE";
        }
    }

    public class OracleProductoDao : IProductoDao
    {
        public string ActualizarInventario(int idProducto, int cantidad)
        {
            return $"UPDATE INVENTARIO ORACLE";
        }
    }

    public class OracleDatabaseFactory : IDatabaseFactory
    {
        public IClienteDao CrearClienteDao()
        {
            return new OracleClienteDao();
        }

        public IProductoDao CrearProductoDao()
        {
            return new OracleProductoDao();
        }
    }
    #endregion

    #region sql server
    public class SqlServerClienteDao : IClienteDao
    {
        public string GetClientes(int idCliente)
        {
            return "SELECT GET CLIENTE SQL SERVER";
        }

        public string GuardarCliente(string nombre)
        {
            return "INSERT INTO CLIENTE SQL SERVER";
        }
    }

    public class SqlServerProductoDao : IProductoDao
    {
        public string ActualizarInventario(int idProducto, int cantidad)
        {
            return "UPDATE PRODUCTO SQL SERVER";
        }
    }

    public class SqlServerDatabaseFactory : IDatabaseFactory
    {
        public IClienteDao CrearClienteDao()
        {
            return new SqlServerClienteDao();
        }

        
        public IProductoDao CrearProductoDao()
        {
            return new SqlServerProductoDao();
        }
    }
    #endregion
}
