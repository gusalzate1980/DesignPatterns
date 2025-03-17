using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Comportamiento
{
    public class Command : IDesignPattern
    {
        public void ExecutePattern()
        {
            Insignia insignia = new Insignia("Juanchito Salazar");
            Publicacion publicacion = new Publicacion();

            ComandoInsignia comandoInsignia = new ComandoInsignia(insignia);
            ComandoPublicacion comandoPublicacion = new ComandoPublicacion(publicacion, "contendio del post");

            comandoInsignia.Execute();
            comandoPublicacion.Execute();
           
        }

        public interface ICommand
        {
            void Execute();
        }

        #region clases concretas
        public class Insignia
        {
            private string _destinatario;

            public Insignia(string destinatario)
            {
                _destinatario = destinatario;
            }

            public void EnviarInsignia()
            {
                Console.WriteLine("Enviar una insignia a "+_destinatario);
            }
        }

        public class Publicacion
        {
            public bool Publicar(string texto)
            {
                Console.WriteLine("Publica un texto->" + texto);
                return true;
            }
        }
        #endregion

        #region Comandos
        public class ComandoInsignia : ICommand
        {
            private Insignia _insignia;
            public ComandoInsignia(Insignia insignia)
            {
                _insignia = insignia;
            }
            public void Execute()
            {
                _insignia.EnviarInsignia();
            }
        }

        public class ComandoPublicacion : ICommand
        {
            private Publicacion _publicacion;
            private string _texto;
            public ComandoPublicacion(Publicacion publicacion,string texto)
            {
                _publicacion = publicacion;
                _texto = texto;
            }
            public void Execute()
            {
                _publicacion.Publicar(_texto);
            }
        }
        #endregion
    }
}
