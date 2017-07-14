namespace Blockchain.Interfaces
{
    public interface IFifoStack
    {
        void AddData(object data);
        object GetData();
    }
}
