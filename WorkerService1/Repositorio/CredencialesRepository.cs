using Dapper;
using WorkerService1.Data;
using WorkerService1.Modelos;

namespace WorkerService1.Repositorio
{
    public class CredencialesRepository
    {
        private readonly ISqlConnectFactory _SqlConnect;

        public CredencialesRepository(ISqlConnectFactory sqlConnectFactory) { 
            _SqlConnect = sqlConnectFactory;
        }


        public async Task<List<CredencialesCorreos>> ObtenerClientesActivosAsync() {

            const string sql = @"select  Credecod,
                nombre,
                email,
                pass_encryp,
                host,
                puerto,
                usassl,
                proveedor,
                intervaloMinutos,
                ultimoChequeo,
                access_token,
                refresh_token,
                token_expira
                from CredencialesCorreos  
                where estado = 1";

            using var conn = _SqlConnect.CreateConnection();
            var resultado = await conn.QueryAsync<CredencialesCorreos>(sql);

            return resultado.ToList();
        }


        public async Task<List<listaNegracorreos>> ObtenerListaNegraAsync(int credecod) {

            const string sql = @"select Correocod, corrsempresas, Credecod
                from listaNegracorreos
                where Credecod = @Credecod";


            using var conn = _SqlConnect.CreateConnection();

            var resultado = await conn.QueryAsync<listaNegracorreos>(sql, new { Credecod = credecod });

            return resultado.ToList();
        
        }

    }
}
