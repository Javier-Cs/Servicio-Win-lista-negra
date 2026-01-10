using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Modelos;

namespace WorkerService1.Servicio.ServicTipoCuenta
{
    public class ImapEmailCleaner : IEmailCleaner
    {
        public async Task Limpiarasync(CredencialesCorreos cuenta, List<listaNegracorreos> listaNegra)
        {
            using var client = new ImapClient();
            await client.ConnectAsync(cuenta.host, cuenta.puerto, cuenta.usassl);

            //var pass = CryptoHelper.Descrypt(cuenta.pass_encryp);
            var pass = cuenta.pass_encryp;
            await client.AuthenticateAsync(cuenta.email, pass);

            var inbox = client.Inbox;
            await inbox.OpenAsync(MailKit.FolderAccess.ReadWrite);

            foreach (var uid in inbox.Search(SearchQuery.All)) 
            {
                var msg = await inbox.GetMessageAsync(uid);
                var from = msg.From.Mailboxes.First().Address;

                if (listaNegra.Any(x => from.Contains(x.corrsempresas)))
                {
                    await inbox.MoveToAsync(uid, client.GetFolder(MailKit.SpecialFolder.Trash));
                    
                }
            }
            await client.DisconnectAsync(true);
        }

        public bool Soporta(string proveedor)
            => proveedor == "IMAP";
        
    }
}
