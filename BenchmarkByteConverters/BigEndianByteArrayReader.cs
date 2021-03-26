using System;
using System.IO;
using System.Buffers.Binary;

namespace BenchmarkByteConverters
{
    public class BigEndianByteArrayReader : ITeltonikaDataReader
    {
        private long _position;
        private readonly byte[] _input;

        public long Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public BigEndianByteArrayReader(byte[] input)
        {
            _input = input;
            _position = 0;
        }

        public ushort ReadUInt16()
        {
            UInt16 value = BitConverter.ToUInt16(_input, (int)_position);
            _position += 2;
            return BytesSwapper.Swap(value);
        }

        public ushort ReadUInt16_2()
        {
            ReadOnlySpan<byte> source = new ReadOnlySpan<byte>(_input, (int)_position, 2);
            UInt16 adf = BinaryPrimitives.ReadUInt16BigEndian(source);
            UInt16 value = BitConverter.ToUInt16(_input, (int)_position);
            _position += 2;
            return BytesSwapper.Swap(value);
        }

        public short ReadInt16()
        {
            //TODO: nagaan of gebruik van readonlyspan op deze manier handig is
            //https://www.stevejgordon.co.uk/an-introduction-to-optimising-code-using-span-t
            ReadOnlySpan<byte> source = new ReadOnlySpan<byte>(_input, (int)_position, 4);
            Int16 adf = BinaryPrimitives.ReadInt16BigEndian(source);
            Int16 value = BitConverter.ToInt16(_input, (int)_position);
            _position += 2;
            return BytesSwapper.Swap(value);
        }

        public int ReadInt32()
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 4);
            Int32 value = BinaryPrimitives.ReadInt32BigEndian(span);
            _position += 4;
            return value;
        }

        public uint ReadUInt32()
        {
            UInt32 value = BitConverter.ToUInt32(_input, (int)_position);
            _position += 4;
            return BytesSwapper.Swap(value);
        }

        public long ReadInt64()
        {
            Int64 value = BitConverter.ToInt64(_input, (int)_position);
            _position += 8;
            return BytesSwapper.Swap(value);
        }

        public ulong ReadUInt64()
        {
            var value = BitConverter.ToUInt64(_input, (int)_position);
            _position += 8;
            return BytesSwapper.Swap(value);
        }

        public byte ReadByte()
        {
            var value = _input[_position];
            _position += 1;
            return value;
        }

        public byte[] ReadBytes(int count)
        {
            byte[] output = new byte[count];
            Array.Copy(_input, (int)_position, output, 0, count);
            _position += count;
            return output;
        }

        public sbyte ReadSByte()
        {
            var value = Convert.ToSByte(_input[_position]);
            _position += 1;
            return value;
        }
    }
}