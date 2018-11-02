using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Blockchain;
using DAO;

namespace BockchainTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain.Blockchain chain = new Blockchain.Blockchain();
            chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "John Smith", AccountId = 001, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));
            chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "Jane Doe", AccountId = 002, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));
            chain.AddBlock(new Block(DateTime.Now, null, new Ticket { CustomerName = "Tina Smith", AccountId = 003, CreateDate = DateTime.Now, ProblemDescription = "Service stop working" }));

            Console.WriteLine(JsonConvert.SerializeObject(chain, Newtonsoft.Json.Formatting.Indented));


           ;
            Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");

            Console.WriteLine($"Changing problem description of second block ");
            chain.Chain[2].Data.ProblemDescription = "Some other problem";
            chain.Chain[2].Hash = chain.Chain[2].CalculateHash();


            Console.WriteLine($"Is Chain Valid: {chain.IsValid()}");
            Console.WriteLine(JsonConvert.SerializeObject(chain, Newtonsoft.Json.Formatting.Indented));


            Console.ReadKey();
        }
    }
}
