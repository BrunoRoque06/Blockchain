namespace Blockchain
{
    public class Miner
    {
        public Blockchain Blockchain { get; }
        private IBlockFactory _blockFactory;

        public Miner(IBlockFactory blockFactory)
        {
            
            _blockFactory = blockFactory;
            var genesisBlock = _blockFactory.GenerateGenesisBlock();

            Blockchain = new Blockchain(genesisBlock);
        }

        public void AddBlock(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(Blockchain.GetLastBlock(), data);
            Blockchain.AddBlock(newBlock);
        }
    }
}
