using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class Ticket
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ProblemDescription { get; set; }

    }
}
