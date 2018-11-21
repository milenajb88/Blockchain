using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class NodesValidation
    {
        //Este metodos se llama cuando la cadena es != null
        public string nodesValidate(List<Block> nodo1, List<Block> nodo2, List<Block> nodo3)
        {
            string result = "Nodos vacios";

            for (int i = 0; i <= nodo1.Count; i++)
            {
                if ((nodo1[i].CalculateHash() == nodo2[i].CalculateHash()) & (nodo2[i].CalculateHash() == nodo3[i].CalculateHash()))
                {
                    result = "Iguales";
                }
                else
                {
                    if (nodo1[i].CalculateHash() == nodo2[i].CalculateHash())
                    {
                        if (nodo1[i].CalculateHash() != nodo3[i].CalculateHash())
                        {
                            result = "El nodo3 está corrupto";
                        }
                    }
                    else
                    {
                        if (nodo1[i].CalculateHash() == nodo3[i].CalculateHash())
                        {
                            result = "El nodo2 está corrupto";
                        }
                        else
                        {
                            if (nodo2[i].CalculateHash() == nodo3[i].CalculateHash())
                            {
                                result = "El nodo1 está corrupto";
                            }
                        }
                    }
                }
            }
            return result;
        }

        public string sizeValidate(List<Block> nodo1, List<Block> nodo2, List<Block> nodo3)
        {
            string result = "";
            if ((nodo1.Count == nodo2.Count) & (nodo2.Count == nodo3.Count))
            {
                result = "Iguales";
            }
            else
            {
                if (nodo1.Count == nodo2.Count)
                {
                    if (nodo1.Count != nodo3.Count)
                    {
                        result = "El nodo3 tiene diferente tamaño";
                    }
                }
                else
                {
                    if (nodo1.Count == nodo3.Count)
                    {
                        result = "El nodo2 tiene diferente tamaño";
                    }
                    else
                    {
                        if (nodo2.Count == nodo3.Count)
                        {
                            result = "El nodo1 tiene diferente tamaño";
                        }
                    }
                }
            }
            return result;
        }

        public string isValid(List<Block> nodo)
        {
            for (int i = 0; i < nodo.Count; i++)
            {
                Block currentBlock = nodo[i];
                Block previousBlock = nodo[i - 1];
                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return "Bloque # " + currentBlock.Index + "corrupto";
                }
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return "Bloque # " + (currentBlock.Index - 1) + "corrupto";
                }
            }
            return "true";
        }
    }
}
