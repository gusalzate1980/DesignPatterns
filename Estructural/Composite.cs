using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Estructural
{
    public static class Composite
    {
        public static void ExecuteComposite() 
        {
            Funda f1 = new Funda(5000);
            Funda f2 = new Funda(6000);
            Cargador c1 =   new Cargador(80000);
            Cargador c2 = new Cargador(120000);
            Telefono t1 = new Telefono(2500000);
            t1.AddSubProducto(f1);
            t1.AddSubProducto(f2);
            t1.AddSubProducto(c1);
            t1.AddSubProducto(c2);

            Separador s1 = new Separador(2500);
            Separador s2 = new Separador(3500);
            Sello e1 = new Sello(45000);
            Sello e2 = new Sello(30000);
            Libro l1 = new Libro(85000);
            l1.AddSubProducto(s1);
            l1.AddSubProducto(s2);
            l1.AddSubProducto(e1);
            l1.AddSubProducto(e2);

            SprayOlor o1 = new SprayOlor(20000);
            SprayOlor o2 = new SprayOlor(20000);
            QuitaMotas q1 = new QuitaMotas(5000);
            QuitaMotas q2 = new QuitaMotas(5000);
            Ropa r1 = new Ropa(280000);
            r1.AddSubProducto(o1);
            r1.AddSubProducto(o2);
            r1.AddSubProducto(q1);
            r1.AddSubProducto(q2);

            CarroVirtual carro = new CarroVirtual();
            carro.AddSubProducto(t1);
            carro.AddSubProducto(l1);
            carro.AddSubProducto(r1);

            Console.WriteLine("El precio total de todo es: " + carro.GetPrecio());
        }

        public abstract class Producto
        {
            private int _precio { set; get; }

            public void SetPrecio(int precio)
            {
                this._precio = precio;
            }

            public abstract int GetPrecio();
            public abstract void AddSubProducto(Producto producto);
        }

        public class Telefono : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Telefono(int precio)
            { 
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }
            
            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Cargador : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Cargador(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Funda : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Funda(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Libro : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Libro(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Separador : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Separador(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Sello : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Sello(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class Ropa : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public Ropa(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class SprayOlor : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public SprayOlor(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class QuitaMotas : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public QuitaMotas(int precio)
            {
                _precio = precio;
            }

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }

        public class CarroVirtual : Producto
        {
            private int _precio;
            private List<Producto> _subProductos = new List<Producto>();

            public override void AddSubProducto(Producto producto)
            {
                _subProductos.Add(producto);
            }

            public override int GetPrecio()
            {
                int total = _precio;

                foreach (var sub in _subProductos)
                {
                    total += sub.GetPrecio();
                }

                return total;
            }
        }
    }
}
