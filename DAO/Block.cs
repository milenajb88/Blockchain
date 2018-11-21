using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class Block
    {
        public int Id { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int? IdTicket { get; set; }

        public Block()
        {

        }
    }
}
