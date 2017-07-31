using Blockchain.Interfaces;

namespace Blockchain
{
    public interface IHashEstimator
    {
        string Estimate(IBlock block);
    }
}
