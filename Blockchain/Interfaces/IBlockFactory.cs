namespace Blockchain
{
    public interface IBlockFactory
    {
        Block GenerateGenesisBlock();
        Block GenerateNextBlock(Block lastBlock, object dataNewBlock, int nonce);
    }
}