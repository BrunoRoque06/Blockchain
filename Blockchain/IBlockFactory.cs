namespace Blockchain
{
    public interface IBlockFactory
    {
        Block GenerateNextBlock(Block lastBlock, string dataNewBlock);
    }
}