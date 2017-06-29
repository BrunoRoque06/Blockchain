namespace Blockchain
{
    public interface IHashEstimator
    {
        string EstimateHash(Block block);
    }
}
