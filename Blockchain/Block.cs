using DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
  public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public Ticket  Ticket { get; set; }

        public Block(string previousHash, Ticket ticket)
        {
            Index = 0;
            PreviousHash = previousHash;
            Ticket = ticket;
            Hash = CalculateHash();
        }

        public Block(int index, string previousHash, Ticket ticket, string hash)
        {
            this.Index = index;
            this.PreviousHash = previousHash;
            this.Ticket = ticket;
            this.Hash = hash;
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Ticket, Formatting.Indented));
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
