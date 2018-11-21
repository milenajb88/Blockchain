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
        public string insertTicket(DAO.Ticket newT)
        {
            Boolean validateBool;
            Boolean resultBool;
            string result = "";
            var blockChain1 = getBlocksClient1(client1);
            var blockChain2 = getBlocksClient2(client2);
            var blockChain3 = getBlocksClient3(client3);

            Blockchain.Ticket newTicket = new Blockchain.Ticket { Id = newT.Id, CustomerName = newT.CustomerName, AccountId = newT.AccountId, CreateDate = DateTime.Now, ProblemDescription = newT.ProblemDescription };

            //Este if es en caso de que los nodos estén vacios
            if ((blockChain1.Count == 0) & (blockChain2.Count == 0) & (blockChain3.Count == 0))
            {
                createGenesisBlock(1);
                log.Debug("Creating Genesis Block for Node 1");
                createGenesisBlock(2);
                log.Debug("Creating Genesis Block for Node 2");
                createGenesisBlock(3);
                log.Debug("Creating Genesis Block for Node 3");
            }
            else
            {
                //Para verificar que todos los nodos tienen el mismo tamaño
                validateBool = nodesValidation.sizeValidate(blockChain1, blockChain2, blockChain3);
                if (validateBool == true)
                {
                    //Verificar que la cadena del nodo1 es consistente
                    resultBool = nodesValidation.isValid(blockChain1,1);
                    if (resultBool == true)
                    {
                        //Verificar que la cadena del nodo2 es consistente
                        resultBool = nodesValidation.isValid(blockChain2,2);
                        if (resultBool == true)
                        {
                            //Verificar que la cadena del nodo3 es consistente
                            resultBool = nodesValidation.isValid(blockChain3,3);
                            if (resultBool == true)
                            {
                                // Verificar que los tres nodos son iguales entonces
                                resultBool = nodesValidation.nodesValidate(blockChain1, blockChain2, blockChain3);
                                if (resultBool == true)
                                {
                                    createBlock(1, blockChain1[blockChain1.Count], newT);
                                    log.Debug("Adding Block to Node 1");
                                    createBlock(2, blockChain1[blockChain1.Count], newT);
                                    log2.Debug("Adding Block to Node 2");
                                    createBlock(3, blockChain1[blockChain1.Count], newT);
                                    log3.Debug("Adding Block to Node 3");
                                }
                                else
                                {
                                    return result;
                                }
                            }
                            else
                            {
                                return result + "en el nodo1";
                            }

                        }
                        else
                        {
                            return result + "en el nodo2";
                        }
                    }
                    else
                    {
                        return result + "en el nodo1";
                    }
                }
                else
                {
                    return result;
                }
            }
            return result;
        }

        private List<Blockchain.Block> getBlocksClient1(ClientN1 client)
        {
            var task = client.getChainAsync();
            task.Wait();
            List<Blockchain.Block> chain = new List<Blockchain.Block>();
            return task.Result;
        }

        private List<Blockchain.Block> getBlocksClient2(ClientN2 client)
        {
            var task = client.getChainAsync();
            task.Wait();
            List<Blockchain.Block> chain = new List<Blockchain.Block>();
            return task.Result;
        }

        private List<Blockchain.Block> getBlocksClient3(ClientN3 client)
        {
            var task = client.getChainAsync();
            task.Wait();
            List<Blockchain.Block> chain = new List<Blockchain.Block>();
            return task.Result;
        }


        private void createGenesisBlock(int type)
        {
            string uri = "";
            switch (type)
            {
                case 1:
                    uri = "http://localhost:51241";
                    break;
                case 2:
                    uri = "http://localhost:53259";
                    break;
                case 3:
                    uri = "http://localhost:53473";
                    break;
                default:
                    break;
            }

            ClientN1 client = new ClientN1(uri);
            DAO.Ticket t1 = new DAO.Ticket(0, null, 0, DateTime.Now, null);
            var task = client.createTicket(t1);
            task.Wait();
            t1 = task.Result;
            Block block1 = new Block() { PreviousHash = null, Ticket = t1 };
            DAO.Block dBlock1 = new DAO.Block() { PreviousHash = block1.PreviousHash, Hash = block1.Hash, Id = 0, IdTicket = block1.Ticket.Id };
            var task2 = client.createBlock(dBlock1);
            task.Wait();

        }

        private void createBlock(int type, Block previous, DAO.Ticket ticket)
        {
            string uri = "";
            switch (type)
            {
                case 1:
                    uri = "http://localhost:51241";
                    break;
                case 2:
                    uri = "http://localhost:53259";
                    break;
                case 3:
                    uri = "http://localhost:53473";
                    break;
                default:
                    break;
            }

            ClientN1 client = new ClientN1(uri);
            DAO.Ticket t1 = new DAO.Ticket(ticket.Id, ticket.CustomerName, ticket.AccountId.Value, DateTime.Now, ticket.ProblemDescription);
            var task = client.createTicket(t1);
            task.Wait();
            t1 = task.Result;
            Block block1 = new Block() { PreviousHash = previous.Hash , Ticket = t1 };
            DAO.Block dBlock1 = new DAO.Block() { PreviousHash = block1.PreviousHash, Hash = block1.Hash, Id = 0, IdTicket = block1.Ticket.Id };
            var task2 = client.createBlock(dBlock1);
            task.Wait();

        }
    }
}
