namespace Blockchain
{
    public class Individual
    {
        public Ledger Ledger { get; }
        private IBlockFactory _blockFactory;

        public Individual(IBlockFactory blockFactory)
        {
            
            _blockFactory = blockFactory;
            var genesisBlock = _blockFactory.GenerateGenesisBlock();

            Ledger = new Ledger(genesisBlock);
        }

        public void AddBlock(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(Ledger.GetLastBlock(), data);
            Ledger.AddBlock(newBlock);
        }
    }
}
