using System;
using SOAP_Serv;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clases
{
    public class Lugar
    {
        private static List<Lugar> values;
        public static List<Lugar> getList()
        {
            if (values == null)
                setLugares();
            return values;
        }


        private static void setLugares()
        {
            values = new List<Lugar>()
                {
                    new Lugar(){ Id = "H", Nombre = "Hotel" },
                    new Lugar(){ Id = "A", Nombre = "Aeropuerto"},
                    new Lugar(){ Id = "T", Nombre = "TerminalBus"}
                };
        }
        

        public String Id { get; set; }
        public String Nombre { get; set; }


        public static LugarRetiroDevolucion getWSLugar(string id)
        {
            switch (id)
            {
                case "H":
                    return LugarRetiroDevolucion.Hotel;
                case "A":
                    return LugarRetiroDevolucion.Aeropuerto;
                case "T":
                    return LugarRetiroDevolucion.TerminalBuses;
            }
            return LugarRetiroDevolucion.TerminalBuses;
        }


        public static string GetId(LugarRetiroDevolucion l)
        {
            switch (l)
            {
                case LugarRetiroDevolucion.Aeropuerto:
                    return "A";
                case LugarRetiroDevolucion.Hotel:
                    return "H";
                case LugarRetiroDevolucion.TerminalBuses:
                    return "T";
            }
            return "N";
        }


    }
}
