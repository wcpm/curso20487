using FN.Store.Data.EF.Repository;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProdutoVM> produtos;
            using (var repo = new ProdutoRepository())
            {
                produtos = repo.Obter().Select(p => new ProdutoVM { Nome=p.Nome, Preco = p.Preco});
            }

            var conn = "Endpoint=sb://wcpm2017.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=p8P0AVQQQDSOenIu1m8ZIaqgr4ljF8W8DmBlVeRUPSU=";
            //fila criada dentro do service bus
            var queue = "produtos";
            var server = QueueClient.CreateFromConnectionString(conn, queue);
            var message = JsonConvert.SerializeObject(produtos);

            server.Send(new BrokeredMessage(message));
            Console.WriteLine("Mensagem Enviada");
            Console.ReadLine();


        }
    }

    class ProdutoVM 
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
