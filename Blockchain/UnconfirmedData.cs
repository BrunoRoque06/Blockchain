using System.Collections.Generic;

namespace Blockchain
{
    public class UnconfirmedData
    {
        private List<string> _datas;

        public UnconfirmedData()
        {
            _datas = new List<string>();
        }

        public void AddData(string data)
        {
            _datas.Add(data);
        }

        public string GetData()
        {
            string data = null;

            if (_datas.Count > 0)
            {
                data = _datas[0];
                _datas.RemoveAt(0);
            }

            return data;
        }
    }
}
