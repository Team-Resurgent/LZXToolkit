using System.Runtime.InteropServices;

namespace LZXToolkit.Internal
{
    internal unsafe static class LZXAPI
    {
        [DllImport("libLZX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe int CalcDecompressedSize(byte* src, uint src_size, out uint decompressed_size);

        [DllImport("libLZX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe int Decompress(byte* src, uint src_size, byte* dest, out uint decompressed_size);

        [DllImport("libLZX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe int Compress(byte* src, uint src_size, byte* dest, out uint compressed_size);
    }
}
