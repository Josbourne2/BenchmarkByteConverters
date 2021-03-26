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
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 2);
            UInt16 value = BinaryPrimitives.ReadUInt16BigEndian(span);
            _position += 2;
            return value;
        }

        public short ReadInt16()
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 2);
            Int16 value = BinaryPrimitives.ReadInt16BigEndian(span);
            _position += 2;
            return value;
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
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 4);
            UInt32 value = BinaryPrimitives.ReadUInt32BigEndian(span);
            _position += 4;
            return value;
        }

        public long ReadInt64()
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 8);
            Int64 value = BinaryPrimitives.ReadInt64BigEndian(span);
            _position += 8;
            return value;
        }

        public ulong ReadUInt64()
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_input, (int)_position, 8);
            UInt64 value = BinaryPrimitives.ReadUInt64BigEndian(span);
            _position += 8;
            return value;
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