using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.SB.Cliente
{
    class Program
    {
        static void Main(string[] args)
        {            
            // string de conexao service bus
            var conn = "Endpoint=sb://wcpm2017.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=p8P0AVQQQDSOenIu1m8ZIaqgr4ljF8W8DmBlVeRUPSU=";
            
            //fila criada dentro do service bus
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);
            server.OnMessage(msg => {
                Console.WriteLine("", msg.MessageId);
                var produtos = JsonConvert.DeserializeObject<List<ProdutoVM>>(msg.GetBody<string>());
                
                foreach (var prod in produtos)
                {
                    Console.WriteLine("Nome: {0} - Preço = {1:C2}", prod.Nome, prod.Preco);
                }
            });

            Console.ReadLine();
            
        }
    }

    class ProdutoVM
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
