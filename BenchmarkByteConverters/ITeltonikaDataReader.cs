using System.IO;

namespace BenchmarkByteConverters
{
    public interface ITeltonikaDataReader
    {
        long Position { get; set; }

        ushort ReadUInt16();

        short ReadInt16();

        int ReadInt32();

        uint ReadUInt32();

        long ReadInt64();

        ulong ReadUInt64();

        byte ReadByte();

        byte[] ReadBytes(int count);

        sbyte ReadSByte();
    }
}