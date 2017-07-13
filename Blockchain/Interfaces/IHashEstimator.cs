namespace Blockchain
{
    public interface IHashEstimator
    {
        string Estimate(Block block);
    }
}
