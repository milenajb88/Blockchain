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

        Blockchain.NodesValidation nodesValidation = new Blockchain.NodesValidation();
        public string insertTicket(DAO.Ticket newT, List<Blockchain.Block> nodo1, List<Blockchain.Block> nodo2, List<Blockchain.Block> nodo3)
        {
            string result = "";
            Blockchain.Ticket newTicket = new Blockchain.Ticket { Id = newT.Id, CustomerName = newT.CustomerName, AccountId = newT.AccountId, CreateDate = DateTime.Now, ProblemDescription = newT.ProblemDescription };

            //Este if es en caso de que los nodos estén vacios
            if ((nodo1.Count == 0) & (nodo2.Count == 0) & (nodo3.Count == 0))
            {
                // Se repite con cada uno de los nodos
                /**
                DAO.Ticket t1 = client1.createTicket(newT);

                Blockchain.Block b = new Blockchain.Block { PreviousHash = "none", Ticket = newTicket };
                DAO.Block block = new DAO.Block { PreviousHash = "none", Hash = b.Hash, IdTicket = t1.Id };

                DAO.Block blockClient1 = client1.createBlock(block);
                */
            }
            else
            {
                //Para verificar que todos los nodos tienen el mismo tamaño
                result = nodesValidation.sizeValidate(nodo1, nodo2, nodo3);
                if (result == "Iguales")
                {
                    //Verificar que la cadena del nodo1 es consistente
                    result = nodesValidation.isValid(nodo1);
                    if (result == "true")
                    {
                        //Verificar que la cadena del nodo2 es consistente
                        result = nodesValidation.isValid(nodo2);
                        if (result == "true")
                        {
                            //Verificar que la cadena del nodo3 es consistente
                            result = nodesValidation.isValid(nodo3);
                            if (result == "true")
                            {
                                // Verificar que los tres nodos son iguales entonces
                                result = nodesValidation.nodesValidate(nodo1, nodo2, nodo3);
                                if (result == "Iguales")
                                {
                                    //Todos los nodos tienen el mismo tamaño, la cadena de cada uno es consistente y los tres nodos
                                    // son iguales entonces se procede a insertar el  tiquet
                                    /**
                                     * Aca va el codigo para insertar los tiquetes
                                     */
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
    }
}
