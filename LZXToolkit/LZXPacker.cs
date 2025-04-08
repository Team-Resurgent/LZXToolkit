using LZXToolkit.Internal;
using System;

namespace LZXToolkit
{
    public static class LZXPacker
    {
        public unsafe static bool Decompress(byte[] input, out byte[] output)
        {
            bool result = false;
            fixed (byte* inputArray = input)
            {
                LZXAPI.CalcDecompressedSize(inputArray, (uint)input.Length, out var output_size);
                output = new byte[output_size];

                fixed (byte* outputArray = output)
                {
                    int temp = LZXAPI.Decompress(inputArray, (uint)input.Length, outputArray, out var decompressed_size);
                    if (temp == 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    
        public unsafe static bool Compress(byte[] input, out byte[] output)
        {
            fixed (byte* inputArray = input)
            {
                var tempOutput = new byte[input.Length];
                fixed (byte* tempOutputArray = tempOutput)
                {
                    int temp = LZXAPI.Compress(inputArray, (uint)input.Length, tempOutputArray, out var compressed_size);
                    if (temp == 0)
                    {
                        output = new byte[compressed_size];
                        Array.Copy(tempOutput, output, output.Length);
                        return true;
                    }
                }
            }
            output = new byte[0];
            return false;
        }
    }
}
