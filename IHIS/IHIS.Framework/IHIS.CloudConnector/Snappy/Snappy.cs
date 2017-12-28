using System;
using System.Linq;
using System.IO;

namespace Snappy.Sharp
{
    public static class Snappy
    {
        internal const int LITERAL = 0;
        internal const int COPY_1_BYTE_OFFSET = 1; // 3 bit length + 3 bits of offset in opcode
        internal const int COPY_2_BYTE_OFFSET = 2;
        internal const int COPY_4_BYTE_OFFSET = 3;

        public static int MaxCompressedLength(int sourceLength)
        {
            SnappyCompressor compressor = new SnappyCompressor();
            return compressor.MaxCompressedLength(sourceLength);
        }

        public static byte[] Compress(byte[] uncompressed)
        {
            SnappyCompressor target = new SnappyCompressor();
            byte[] result = new byte[target.MaxCompressedLength(uncompressed.Length)];
            int count = target.Compress(uncompressed, 0, uncompressed.Length, result);
            byte[] ret = new byte[count];
            for (int i = 0; i < count; i++) ret[i] = result[i];
                return ret;
        }

        public static int GetUncompressedLength(byte[] compressed, int offset)
        {
            SnappyDecompressor decompressor = new SnappyDecompressor();
            return decompressor.ReadUncompressedLength(compressed, offset)[0];
        }

        public static byte[] Uncompress(byte[] compressed)
        {
            SnappyDecompressor decompressor = new SnappyDecompressor();
            return decompressor.Decompress(compressed, 0, compressed.Length);
            
        }

        public static void Uncompress(SnappyStream compressed, StreamWriter uncompressed)
        {
            throw new NotImplementedException();
        }
    }
}
