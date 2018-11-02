using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
   public class Blockchain
    {
        public IList<Block> Chain { set; get; }

        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }


        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, null, null);
        }

        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }

        /// <summary>
        /// Double check the data integrity by checking if the hash has changed in the current block both on itself and the next one (in that case checking previous hash) 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];
                //it calculates the hash with the data if the data has been altered the hash will be different
                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    Console.WriteLine($"Corrupted block id " + currentBlock.Index);
                    return false;
                }
                //When it iterates over the next block it checks if the hash of the altered block is the same  
                //This is needed in case of hash had been recalculated and changed on the altered block (the previous one)
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    Console.WriteLine($"Corrupted block id " + currentBlock.Index);
                    return false;
                }
            }
            return true;
        }

    }
}
