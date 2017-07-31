namespace Blockchain.Interfaces
{
    public interface IFifoQueue
    {
        void AddData(object data);
        object GetData();
    }
}
