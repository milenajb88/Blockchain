using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class NodesValidation
    {
        Logger1 log1 = Logger1.getInstance();
        Logger2 log2 = Logger2.getInstance();
        Logger3 log3 = Logger3.getInstance();

        /// <summary>
        /// This method is called if the original chain is not null.
        /// </summary>
        /// <param name="node1">First blockchain to compare</param>
        /// <param name="node2">Second blockchain to compare</param>
        /// <param name="node3">Third blockchain to compare</param>
        /// <returns></returns>
        public Boolean nodesValidate(List<Block> node1, List<Block> node2, List<Block> node3)
        {
            Boolean result = false;
            for (int i = 0; i < node1.Count; i++)
            {
                if ((node1[i].CalculateHash() == node2[i].CalculateHash()) & (node2[i].CalculateHash() == node3[i].CalculateHash()))
                {
                    log1.Debug(String.Format("The block # {0} is valid in every chain", i + 1));
                    log2.Debug(String.Format("The block # {0} is valid in every chain", i + 1));
                    log3.Debug(String.Format("The block # {0} is valid in every chain", i + 1));
                    result = true;
                }
                else
                {
                    if (node1[i].CalculateHash() == node2[i].CalculateHash())
                    {
                        log1.Debug(String.Format("The block # {0} is corrupted at chain 3", i + 1));
                        log2.Debug(String.Format("The block # {0} is corrupted at chain 3", i + 1));
                        log3.Debug(String.Format("My block # {0} is corrupted", i + 1));
                    }
                    else
                    {
                        if (node1[i].CalculateHash() == node3[i].CalculateHash())
                        {
                            log1.Debug(String.Format("The block # {0} is corrupted at chain 2", i + 1));
                            log2.Debug(String.Format("My block # {0} is corrupted", i + 1));
                            log3.Debug(String.Format("The block # {0} is corrupted at chain 2", i + 1));
                        }
                        else
                        {
                            if (node2[i].CalculateHash() == node3[i].CalculateHash())
                            {
                                log1.Debug(String.Format("My block # {0} is corrupted", i + 1));
                                log2.Debug(String.Format("The block # {0} is corrupted at chain 1", i + 1));
                                log3.Debug(String.Format("The block # {0} is corrupted at chain 1", i + 1));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Boolean sizeValidate(List<Block> nodo1, List<Block> nodo2, List<Block> nodo3)
        {
            Boolean returnValue = false;
            string result = "";
            if ((nodo1.Count == nodo2.Count) && (nodo2.Count == nodo3.Count))
            {
                returnValue = true;
                log1.Debug("We have the same number of blocks");
                log2.Debug("We have the same number of blocks");
                log3.Debug("We have the same number of blocks");
            }
            else
            {
                if (nodo1.Count == nodo2.Count)
                {
                    if (nodo1.Count != nodo3.Count)
                    {
                        result = "The node 3 has a different size";
                        log1.Debug(result);
                        log2.Debug(result);
                        log3.Debug("I have a different size");
                    }
                }
                else
                {
                    if (nodo1.Count == nodo3.Count)
                    {
                        result = "The node 2 has a different size";
                        log1.Debug(result);
                        log2.Debug("I have a different size");
                        log3.Debug(result);
                    }
                    else
                    {
                        if (nodo2.Count == nodo3.Count)
                        {
                            result = "The node 1 has a different size";
                            log1.Debug("I have a different size");
                            log2.Debug(result);
                            log3.Debug(result);
                        }
                    }
                }
            }
            return returnValue;
        }

        public Boolean isValid(List<Block> nodo, int chain)
        {
            for (int i = 0; i < nodo.Count; i++)
            {
                Block currentBlock = nodo[i];
                Block previousBlock = new Block();
                if (i > 0)
                {
                    previousBlock = nodo[i - 1];
                }
                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    log1.Debug(String.Format("Block # {0} from block chain {1} is corrupted", i + 1, chain));
                    log2.Debug(String.Format("Block # {0} from block chain {1} is corrupted", i + 1, chain));
                    log3.Debug(String.Format("Block # {0} from block chain {1} is corrupted", i + 1, chain));
                    return false;
                }
                if (i > 0)
                {
                    if (currentBlock.PreviousHash != previousBlock.Hash)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
