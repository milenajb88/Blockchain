using Blockchain;
using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BockchainTesting;

namespace UI
{
    public partial class TicketSystem : Form
    {
        public TicketSystem()
        {
            InitializeComponent();
        }

        private void BT_SendTicket_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxT_Username.Text) || String.IsNullOrEmpty(TxT_AcctID.Text) || String.IsNullOrEmpty(TxT_Desc.Text))
            {
                LB_FormError.Visible = true;
            }
            else
            {
                LB_FormError.Visible = false;
                var userName = TxT_Username.Text;
                var acctId = Convert.ToInt32(TxT_AcctID.Text);
                var description = TxT_Desc.Text;

                DAO.Ticket ticket = new DAO.Ticket(1, userName, acctId, DateTime.Now, description);
                InsertTicket insert = new InsertTicket();
                insert.insertTicket(ticket);
                FillLogs();
            }
        }
    

        private void FillLogs()
        {
            string text1;
            string text2;
            string text3;
            var fileStreamNode1 = new FileStream(@"C:\Users\MILENA\Desktop\logs\Log1.txt", FileMode.Open, FileAccess.Read);
            var fileStreamNode2 = new FileStream(@"C:\Users\MILENA\Desktop\logs\Log2.txt", FileMode.Open, FileAccess.Read);
            var fileStreamNode3 = new FileStream(@"C:\Users\MILENA\Desktop\logs\Log3.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader1 = new StreamReader(fileStreamNode1, Encoding.UTF8))
            {
                text1 = streamReader1.ReadToEnd();
            }
            using (var streamReader2 = new StreamReader(fileStreamNode2, Encoding.UTF8))
            {
                text2 = streamReader2.ReadToEnd();
            }
            using (var streamReader3 = new StreamReader(fileStreamNode3, Encoding.UTF8))
            {
                text3 = streamReader3.ReadToEnd();
            }

            TxT_Node1.Text = text1;
            TxT_Node2.Text = text2;
            TxT_Node3.Text = text3;
        }
    }
}
