using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Blockchain;
using DAO;
using NodeClient;

namespace BockchainTesting
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                MainAsync(args).GetAwaiter().GetResult();

            }
            catch (Exception)
            {

            }


        }

        static async Task MainAsync(string[] args)
        {
            // Blockchain.Blockchain chain = new Blockchain.Blockchain();
            // chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "John Smith", AccountId = 001, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));
            // chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "Jane Doe", AccountId = 002, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));
            // chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "Tina Smith", AccountId = 003, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));

            // Console.WriteLine(JsonConvert.SerializeObject(chain, Newtonsoft.Json.Formatting.Indented));


            //;
            // //Testing chain validation before the block had been corrupted 
            // Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");
            // Console.WriteLine("\n");
            // //Testing validation after data corruotpion
            // Console.WriteLine($"Changing problem description of second block ");
            // chain.Chain[2].Ticket.ProblemDescription = "Some other problem";
            // chain.Chain[2].Hash = chain.Chain[2].CalculateHash();
            // Console.WriteLine("\n");
            // Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");
            // Console.WriteLine("\n");
            // Console.WriteLine(JsonConvert.SerializeObject(chain, Newtonsoft.Json.Formatting.Indented));

            //Cliente del nodo 1
            ClientN1 client = new ClientN1();

            //Insertando ticket
            DAO.Ticket t = await client.createTicket(new DAO.Ticket { CustomerName = "Jane Doe", AccountId = 002, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" });
            Console.WriteLine("New ticket " + t.Id);


            //Insertando Block
            DAO.Block b = await client.createBlock(new DAO.Block { PreviousHash = "none", Hash = "none", IdTicket = t.Id });
            Console.WriteLine("New block " + b.Id);


            //consultando ticket ->poner id existente
            DAO.Ticket t2 = await client.getTicket(14);
            Console.WriteLine("get customer "+ t2.CustomerName+ " from ticket " + t2.Id);

            //consultando Block
            DAO.Block b2 = await client.getBlock(4);
            Console.WriteLine("get ticket from block " + b2.IdTicket);

            //trayendo cadena de blocks
            List<Blockchain.Block> chain = new List<Blockchain.Block>();
            chain = await client.getChainAsync();

            foreach (Blockchain.Block b3 in chain)
            {
                Console.WriteLine("Im block " + b3.Index + " my ticket is " + b3.Ticket.Id + " from customer " + b3.Ticket.CustomerName);
            }


            Console.ReadKey();
        }
    }
}