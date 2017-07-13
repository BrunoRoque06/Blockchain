namespace Blockchain.Interfaces
{
    public interface IFifoStack
    {
        void AddData(string data);
        string GetData();
    }
}
