using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_Blockchain;

namespace Run_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the blockchain and add the genesis block
            List<Block> blockchain = new List<Block>();
            Block genesisBlock = createGenesisBlock();
            blockchain.Add(genesisBlock);
            Block previousBlock = blockchain[0];
            
            // How many blocks should we add to the chain
            // after the genesis block
            int num_of_blocks_to_add = 20;

            // Add blocks to the chain
            for (int i = 0; i < num_of_blocks_to_add; i++)
            {
                Block blockToAdd = previousBlock.nextBlock(previousBlock);
                blockchain.Add(blockToAdd);
                previousBlock = blockToAdd;
                // Tell everyone about it!
                Console.WriteLine("Block #" + blockToAdd.index + " has been added to the blockchain!");
                Console.WriteLine("Hash: " + blockToAdd.hash);
            }

            Console.ReadLine();
        }

        // The first Block of the Blockchain
        static Block createGenesisBlock()
        {
            return new Block(0, DateTime.Now, "Genesis Block", "0");
        }

    }
}
