using System;
using System.IO;

namespace BenchmarkByteConverters
{
    // Token: 0x0200000D RID: 13
    public class ReverseBinaryStreamReader : BinaryReader, ITeltonikaDataReader
    {
        public long Position
        {
            get { return BaseStream.Position; }
            set { BaseStream.Position = value; }
        }

        // Token: 0x06000057 RID: 87 RVA: 0x0000298C File Offset: 0x00000B8C
        public ReverseBinaryStreamReader(Stream input) : base(input)
        {
        }

        // Token: 0x06000058 RID: 88 RVA: 0x00002995 File Offset: 0x00000B95
        public override ushort ReadUInt16()
        {
            return BytesSwapper.Swap(base.ReadUInt16());
        }

        // Token: 0x06000059 RID: 89 RVA: 0x000029A2 File Offset: 0x00000BA2
        public override short ReadInt16()
        {
            return BytesSwapper.Swap(base.ReadInt16());
        }

        // Token: 0x0600005A RID: 90 RVA: 0x000029AF File Offset: 0x00000BAF
        public override int ReadInt32()
        {
            return BytesSwapper.Swap(base.ReadInt32());
        }

        // Token: 0x0600005B RID: 91 RVA: 0x000029BC File Offset: 0x00000BBC
        public override uint ReadUInt32()
        {
            return BytesSwapper.Swap(base.ReadUInt32());
        }

        // Token: 0x0600005C RID: 92 RVA: 0x000029C9 File Offset: 0x00000BC9
        public override long ReadInt64()
        {
            return BytesSwapper.Swap(base.ReadInt64());
        }

        // Token: 0x0600005D RID: 93 RVA: 0x000029D6 File Offset: 0x00000BD6
        public override ulong ReadUInt64()
        {
            return BytesSwapper.Swap(base.ReadUInt64());
        }

        public override byte ReadByte()
        {
            return base.ReadByte();
        }

        public override byte[] ReadBytes(int count)
        {
            return base.ReadBytes(count);
        }

        public override sbyte ReadSByte()
        {
            return base.ReadSByte();
        }
    }
}