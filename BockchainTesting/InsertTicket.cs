using Blockchain;
using Helpers;
using NodeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BockchainTesting
{
    public class InsertTicket
    {
        NodeClient.ClientN1 client1 = new NodeClient.ClientN1();
        NodeClient.ClientN2 client2 = new NodeClient.ClientN2();
        NodeClient.ClientN3 client3 = new NodeClient.ClientN3();
        Logger1 log = Logger1.getInstance();
        Logger2 log2 = Logger2.getInstance();
        Logger3 log3 = Logger3.getInstance();

        Blockchain.NodesValidation nodesValidation = new Blockchain.NodesValidation();
        public void insertTicket(DAO.Ticket newT)
        {
            Boolean validateBool;
            Boolean resultBool;
            var blockChain1 = getBlocksClient1(client1);
            var blockChain2 = getBlocksClient2(client2);
            var blockChain3 = getBlocksClient3(client3);

            Blockchain.Ticket newTicket = new Blockchain.Ticket { Id = newT.Id, CustomerName = newT.CustomerName, AccountId = newT.AccountId, CreateDate = newT.CreateDate, ProblemDescription = newT.ProblemDescription };

            //In case the nodes are empty
            if ((blockChain1.Count == 0) & (blockChain2.Count == 0) & (blockChain3.Count == 0))
            {
                var block = new DAO.Block();
                var date = DateTime.Now;
                var ticket = new DAO.Ticket(0, null, 0, date, null);
                createGenesisBlock1(client1, ticket, block);
                createGenesisBlock2(client2, ticket, block);
                createGenesisBlock3(client3, ticket, block);
            }
            blockChain1 = getBlocksClient1(client1);
            blockChain2 = getBlocksClient2(client2);
            blockChain3 = getBlocksClient3(client3);
            //To verify that all nodes are the same size
            validateBool = nodesValidation.sizeValidate(blockChain1, blockChain2, blockChain3);
            if (validateBool == true)
            {
                //Verify that the chain of blockChain1 is consistent
                resultBool = nodesValidation.isValid(blockChain1, 1);
                if (resultBool == true)
                {
                    //Verify that the chain of blockChain2 is consistent
                    resultBool = nodesValidation.isValid(blockChain2, 2);
                    if (resultBool == true)
                    {
                        //Verify that the chain of blockChain3 is consistent
                        resultBool = nodesValidation.isValid(blockChain3, 3);
                        if (resultBool == true)
                        {
                            //Verify that the three nodes are equal 
                            resultBool = nodesValidation.nodesValidate(blockChain1, blockChain2, blockChain3);
                            if (resultBool == true)
                            {
                                createBlock1(client1, blockChain1[blockChain1.Count-1], newT);
                                createBlock2(client2, blockChain1[blockChain1.Count-1], newT);
                                createBlock3(client3, blockChain1[blockChain1.Count-1], newT);
                            }
                        }
                    }
                }
            }
        }

        private List<Block> getBlocksClient1(ClientN1 client)
        {
            return client.getBlockChain();
        }

        private List<Block> getBlocksClient2(ClientN2 client)
        {
            return client.getBlockChain();
        }

        private List<Block> getBlocksClient3(ClientN3 client)
        {
            return client.getBlockChain();
        }

        private void createGenesisBlock1(ClientN1 client, DAO.Ticket daoTicket, DAO.Block daoBlock)
        {
            log.Debug("Creating Genesis Block for Node 1");
            DAO.Ticket t1 = daoTicket;
            var reTicket = client.createTicket(t1);
            Block block1 = new Block(null,t1);
            daoBlock.PreviousHash = block1.PreviousHash;
            daoBlock.Hash = block1.Hash;
            daoBlock.Id = 0;
            daoBlock.IdTicket = block1.Ticket.Id;
            client.createBlock(daoBlock);
        }

        private void createGenesisBlock2(ClientN2 client, DAO.Ticket daoTicket, DAO.Block daoBlock)
        {
            log2.Debug("Creating Genesis Block for Node 2");
            DAO.Ticket t1 = daoTicket;
            var reTicket = client.createTicket(t1);
            Block block1 = new Block(null, t1);
            daoBlock.PreviousHash = block1.PreviousHash;
            daoBlock.Hash = block1.Hash;
            daoBlock.Id = 0;
            daoBlock.IdTicket = block1.Ticket.Id;
            client.createBlock(daoBlock);
        }

        private void createGenesisBlock3(ClientN3 client, DAO.Ticket daoTicket, DAO.Block daoBlock)
        {
            log3.Debug("Creating Genesis Block for Node 3");
            DAO.Ticket t1 = daoTicket;
            var reTicket = client.createTicket(t1);
            Block block1 = new Block(null, t1);
            daoBlock.PreviousHash = block1.PreviousHash;
            daoBlock.Hash = block1.Hash;
            daoBlock.Id = 0;
            daoBlock.IdTicket = block1.Ticket.Id;
            client.createBlock(daoBlock);
        }

        private void createBlock1(ClientN1 client, Block previous, DAO.Ticket ticket)
        {
            log.Debug("Adding Block to Node 1");
            var reTicket = client.createTicket(ticket);
            Block block1 = new Block(previous.Hash,reTicket);
            log.Debug(string.Format("Adding ticket from user {0}", reTicket.CustomerName));
            DAO.Block dBlock1 = new DAO.Block() { PreviousHash = block1.PreviousHash, Hash = block1.Hash, Id = 0, IdTicket = block1.Ticket.Id };
            client.createBlock(dBlock1);
        }

        private void createBlock2(ClientN2 client, Block previous, DAO.Ticket ticket)
        {
            log2.Debug("Adding Block to Node 2");
            var reTicket = client.createTicket(ticket);
            Block block1 = new Block(previous.Hash, reTicket);
            log2.Debug(string.Format("Adding ticket from user {0}", reTicket.CustomerName));
            DAO.Block dBlock1 = new DAO.Block() { PreviousHash = block1.PreviousHash, Hash = block1.Hash, Id = 0, IdTicket = block1.Ticket.Id };
            client.createBlock(dBlock1);
        }

        private void createBlock3(ClientN3 client, Block previous, DAO.Ticket ticket)
        {
            log3.Debug("Adding Block to Node 3");
            var reTicket = client.createTicket(ticket);
            Block block1 = new Block(previous.Hash, reTicket);
            log3.Debug(string.Format("Adding ticket from user {0}", reTicket.CustomerName));
            DAO.Block dBlock1 = new DAO.Block() { PreviousHash = block1.PreviousHash, Hash = block1.Hash, Id = 0, IdTicket = block1.Ticket.Id };
            client.createBlock(dBlock1);
        }
    }
}
