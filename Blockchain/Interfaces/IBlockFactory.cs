using Blockchain.Interfaces;

namespace Blockchain
{
    public interface IBlockFactory
    {
        IBlock GenerateGenesisBlock();
        IBlock GenerateNextBlock(IBlock lastBlock, object dataNewBlock, int nonce);
        string GetBlockHash(IBlock block);
    }
}