namespace Blockchain
{
    public class Individual
    {
        public Ledger Ledger { get; }
        private IBlockFactory _blockFactory;

        public Individual(IBlockFactory blockFactory)
        {
            Ledger = new Ledger();
            _blockFactory = blockFactory;

            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            Ledger.AddBlock(genesisBlock);
        }

        public void AddBlock(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(Ledger.GetLastBlock(), data);
            Ledger.AddBlock(newBlock);
        }
    }
}
