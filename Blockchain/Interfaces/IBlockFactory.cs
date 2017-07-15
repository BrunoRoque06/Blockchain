namespace Blockchain
{
    public interface IBlockFactory
    {
        Block GenerateGenesisBlock();
        Block GenerateNextBlock(Block lastBlock, string dataNewBlock, int nonce);
    }
}