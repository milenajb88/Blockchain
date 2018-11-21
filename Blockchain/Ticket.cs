using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ProblemDescription { get; set; }

        public Ticket(int id, string customerName, int accountId, DateTime  createDate, string ProblemDescription)
        {
            this.Id = id;
            this.CustomerName = customerName;
            this.AccountId = accountId;
            this.CreateDate = createDate;
            this.ProblemDescription = ProblemDescription;

        }

        public Ticket()
        {

        }

        public Ticket(DAO.Ticket ticket)
        {
            this.Id = ticket.Id;
            this.CustomerName = ticket.CustomerName;
            this.AccountId = ticket.AccountId;
            this.CreateDate = ticket.CreateDate;
            this.ProblemDescription = ticket.ProblemDescription;
        }

    }
}
