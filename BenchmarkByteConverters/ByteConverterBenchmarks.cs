using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BenchmarkByteConverters
{
    [ShortRunJob]
    [NativeMemoryProfiler]
    [MemoryDiagnoser]
    public class ByteConverterBenchmarks
    {
        private const int N = 10;
        private readonly byte[] data;
        private ReverseBinaryStreamReader streamReader;
        private ReverseByteArrayReader byteReader;
        private BigEndianByteArrayReader beByteReader;

        public ByteConverterBenchmarks()
        {
            string input = "00000000000000A7080400000113fc208dff000f14f650209cca80006f00d60400040004030101150316030001460000015d0000000113fc17610b000f14ffe0209cc580006e00c00500010004030101150316010001460000015e0000000113fc284945000f150f00209cd200009501080400000004030101150016030001460000015d0000000113fc267c5b000f150a50209cccc0009300680400000004030101150016030001460000015b000400007949";
            data = StringToBytes(input);
            streamReader = new ReverseBinaryStreamReader(new MemoryStream(data));
            byteReader = new ReverseByteArrayReader(data);
            beByteReader = new BigEndianByteArrayReader(data);
            //DataDecoder codec = new DataDecoder(new NetStandard.Codec8.ReverseBinaryStreamReader(dataStream));
        }

        [Benchmark]
        public Int32 ReadIntFromByteStreamAndReverse()
        {
            streamReader.Position = 4L;
            return streamReader.ReadInt32();
        }

        [Benchmark]
        public Int32 ReadIntFromByteArrayAndReverse()
        {
            byteReader.Position = 4L;
            return byteReader.ReadInt32();
        }

        [Benchmark]
        public Int32 ReadIntFromByteArrayBinaryPrimitivesMethod()
        {
            beByteReader.Position = 4L;
            return beByteReader.ReadInt32();
        }

        private static byte[] StringToBytes(string data)
        {
            byte[] array = new byte[data.Length / 2];
            int substring = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = byte.Parse(data.Substring(substring, 2), NumberStyles.AllowHexSpecifier);
                substring += 2;
            }
            return array;
        }
    }
}