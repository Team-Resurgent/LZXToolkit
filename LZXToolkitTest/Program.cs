namespace LZXToolkitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sampleData = new byte[65536];
            for (int i = 0; i < sampleData.Length; i++)
            {
                sampleData[i] = (byte)(i % 64);
            }

            if (LZXToolkit.LZXPacker.Compress(sampleData, out var compressed) == false)
            {
                Console.WriteLine("Test Failed");
                return;
            }

            if (LZXToolkit.LZXPacker.Decompress(compressed, out var decompressed) == false)
            {
                Console.WriteLine("Test Failed");
                return;
            }

            for (int i = 0; i < sampleData.Length; i++)
            {
                if (decompressed[i] != sampleData[i])
                {
                    Console.WriteLine("Test Failed");
                    return;
                }
            }
            Console.WriteLine("Test OK");
        }
    }
}
