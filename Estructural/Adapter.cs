using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Estructural
{
    public static class Adapter
    {
        public static void ExecuteAdapter()
        { 
            Asterisk asterisk = new Asterisk();
            Plivo plivo = new Plivo();
            Avaya avaya = new Avaya();

            AdapterAsterisk adapterAsterisk = new AdapterAsterisk(asterisk);
            AdapterPlivo adapterPlivo = new AdapterPlivo(plivo);
            AdapterAvaya adapterAvaya = new AdapterAvaya(avaya);

            foreach (var call in adapterAsterisk.GetRealTimeCalls())
            {
                Console.WriteLine("Asterisk ->"+call);
            }

            foreach (var call in adapterPlivo.GetRealTimeCalls())
            {
                Console.WriteLine("Plivo ->" + call);
            }

            foreach (var call in adapterAvaya.GetRealTimeCalls())
            {
                Console.WriteLine("Avaya ->" + call);
            }
        }
    }

    public interface IRealtimeCalling
    {
        public List<string> GetRealTimeCalls();
    }

    public class AdapterAsterisk : IRealtimeCalling
    {
        private Asterisk _asterisk;
        public AdapterAsterisk(Asterisk asterisk) 
        {
            _asterisk = asterisk;
        }
        public List<string> GetRealTimeCalls()
        {
            return _asterisk.GetCallsRunning();
        }
    }

    public class AdapterPlivo : IRealtimeCalling
    {
        private Plivo _plivo;
        public AdapterPlivo(Plivo plivo)
        {
            _plivo = plivo;
        }
        public List<string> GetRealTimeCalls()
        {
            return _plivo.GetLiveCalls().ToList();
        }
    }

    public class AdapterAvaya : IRealtimeCalling
    {
        private Avaya _avaya;
        public AdapterAvaya(Avaya avaya)
        {
            _avaya = avaya;
        }
        public List<string> GetRealTimeCalls()
        {
            List<string> calls = new List<string>();

            foreach (var call in _avaya.GetPeopleAreTalking())
            {
                calls.Add(call.Name+" "+call.LastName);
            }

            return calls;
        }
    }

    public class Asterisk
    {
        public List<string> GetCallsRunning()
        {
            return new List<string>() { "Gustavo","Cristina","Santiago"};
        }
    }

    public class Plivo
    {
        public string[] GetLiveCalls()
        {
            return new string[] { "Jaime", "Cecilia", "Olga" };
        }
    }

    public class Avaya
    {
        public List<CallAvaya> GetPeopleAreTalking() 
        {
            return new List<CallAvaya>() { new CallAvaya() { LastName="Perez",Name="Pepito"}, new CallAvaya() { LastName="Quintero", Name="Lorena"}, new CallAvaya() { LastName ="Jaramillo", Name="Pedrito"} };
        }
    }

    public class CallAvaya
    {
        public string Name { set; get; }
        public string LastName { set; get; }
    }
}