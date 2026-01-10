using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Modelos;

namespace WorkerService1.Servicio
{
    public interface IEmailCleaner
    {

        bool Soporta(string proveedor);
        Task Limpiarasync(CredencialesCorreos cuenta, List<listaNegracorreos> listaNegra);
    }
}
