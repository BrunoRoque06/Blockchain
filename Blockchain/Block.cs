using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime DateTime { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }
    }
}
