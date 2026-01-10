using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Repositorio;

namespace WorkerService1.Servicio
{
    public class SpamCleanerService : ISpamCleanerService
    {

        private readonly CredencialesRepository _repo;
        private readonly IEnumerable<IEmailCleaner> _cleaners;

        public SpamCleanerService(CredencialesRepository credencialesRepository, IEnumerable<IEmailCleaner> emailCleaners) {
            _repo = credencialesRepository;
            _cleaners = emailCleaners;
        }


        public async Task ProcesarCorreosAsync()
        {
            var cuentas = await _repo.ObtenerClientesActivosAsync();
            foreach (var cuenta in cuentas)
            {
                var listaNegra = await _repo.ObtenerListaNegraAsync(cuenta.Credecod);
                var cleaner = _cleaners.First( c => c.Soporta(cuenta.proveedor));

                await cleaner.Limpiarasync(cuenta, listaNegra);
            }
        }
    }
}
