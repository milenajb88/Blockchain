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
        public DAO.Ticket Ticket { get; set; }

        public Block()
        {

        }

        public Block(string previousHash, DAO.Ticket ticket)
        {
            Index = 0;
            PreviousHash = previousHash;
            Ticket = ticket;
            Hash = CalculateHash();
        }

        public Block(int index, string previousHash, DAO.Ticket ticket, string hash)
        {
            this.Index = index;
            this.PreviousHash = previousHash;
            this.Ticket = ticket;
            this.Hash = hash;
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            //byte[] inputBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Ticket, Formatting.Indented));
            byte[] inputBytes = Encoding.ASCII.GetBytes(string.Format("{0},{1},{2},{3},{4}", Ticket.Id, Ticket.CustomerName, Ticket.CreateDate, Ticket.AccountId, Ticket.ProblemDescription));
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
