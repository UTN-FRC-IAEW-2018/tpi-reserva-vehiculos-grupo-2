using System;
using SOAP_Serv;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clases
{
    public class Lugar
    {
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
    }
}
