using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Newtonsoft.Json;
using EntityNode2;
using Blockchain;


namespace NodeClient
{
    public class ClientN2
    {
        public ClientN2()
        {

        }


        public DAO.Ticket createTicket(DAO.Ticket ticket)
        {
            try
            {
                using (var context = new Node2Context())
                {
                    var ticketModel = new EntityNode2.Ticket()
                    {
                        AccountId = ticket.AccountId,
                        CreateDate = ticket.CreateDate,
                        CustomerName = ticket.CustomerName,
                        Id = ticket.Id,
                        ProblemDescription = ticket.ProblemDescription
                    };
                    context.Ticket.Add(ticketModel);
                    context.SaveChanges();
                    ticket.Id = ticketModel.Id;
                    return ticket;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Ticket not saved");
                throw;
            }

        }

        public DAO.Ticket getTicket(int id)
        {
            try
            {
                using (var context = new Node2Context())
                {
                    var ticketModel = context.Ticket.Where(x => x.Id == id).FirstOrDefault();
                    var daoTicket = new DAO.Ticket(ticketModel.Id, ticketModel.CustomerName, ticketModel.AccountId.Value, ticketModel.CreateDate.Value, ticketModel.ProblemDescription);
                    return daoTicket;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load ticket");
                throw;
            }

        }

        public Blockchain.Block getBlock(int id)
        {
            try
            {
                using (var context = new Node2Context())
                {
                    var blockModel = context.Block.Where(x => x.Id == id).FirstOrDefault();
                    var ticketModel = getTicket(blockModel.IdTicket.Value);
                    var daoTicket = new DAO.Ticket(ticketModel.Id, ticketModel.CustomerName, ticketModel.AccountId, ticketModel.CreateDate, ticketModel.ProblemDescription);
                    var block = new Blockchain.Block(blockModel.Id, blockModel.PreviousHash, daoTicket, blockModel.Hash);
                    return block;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load ticket");
                throw;
            }

        }


        public void createBlock(DAO.Block Block)
        {
            try
            {
                using (var context = new Node2Context())
                {
                    var blockModel = new EntityNode2.Block()
                    {
                        Id = Block.Id,
                        Hash = Block.Hash,
                        IdTicket = Block.IdTicket,
                        PreviousHash = Block.PreviousHash,
                    };
                    context.Block.Add(blockModel);
                    context.SaveChanges();
                    Block.Id = blockModel.Id;
                };

            }
            catch (Exception e)
            {
                Console.WriteLine("Ticket not saved");
                throw;
            }

        }

        private List<EntityNode2.Block> GetBlocks()
        {
            try
            {
                using (var context = new Node2Context())
                {
                    var blockList = context.Block.ToList();
                    return blockList;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load chain");
                throw;
            }

        }

        public List<Blockchain.Block> getBlockChain()
        {
            try
            {
                var listaBlocks = GetBlocks();
                List<Blockchain.Block> BlockList = new List<Blockchain.Block>();
                foreach (EntityNode2.Block block in listaBlocks)
                {
                    var daoTicket = getTicket(block.IdTicket.Value);
                    Blockchain.Block bcBlock = new Blockchain.Block() { Index = block.Id, Hash = block.Hash, PreviousHash = block.PreviousHash, Ticket = daoTicket };
                    BlockList.Add(bcBlock);
                }

                return BlockList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't load chain");
                throw;
            }

        }


    }
}
