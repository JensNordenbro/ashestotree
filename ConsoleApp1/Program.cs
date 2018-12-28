using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ashes =
            {
                "APA_FRUKT_BANAN_LENGTH",
                "APA_FRUKT_BANAN_TASTE",
                "MONKEY_FRUKT_BANAN_LENGTH"
            };
            var nodes = AshesToTree.AshesToTree.GetTree(ashes, '_');
        }
    }
}
