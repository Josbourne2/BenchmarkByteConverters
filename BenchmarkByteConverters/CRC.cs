using System;

namespace Teltonika.NetStandard.Codec8
{
    // Token: 0x02000004 RID: 4
    public sealed class CRC
    {
        // Token: 0x06000010 RID: 16 RVA: 0x00002574 File Offset: 0x00000774
        public CRC(int polynom)
        {
            this._polynom = polynom;
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002583 File Offset: 0x00000783
        public int CalcCrc16(byte[] buffer)
        {
            return CRC.CalcCrc16(buffer, 0, buffer.Length, this._polynom, 0);
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002598 File Offset: 0x00000798
        public static int CalcCrc16(byte[] buffer, int offset, int bufLen, int polynom, int preset)
        {
            preset &= 65535;
            polynom &= 65535;
            int crc = preset;
            for (int i = 0; i < bufLen; i++)
            {
                int data = (int)(buffer[(i + offset) % buffer.Length] & byte.MaxValue);
                crc ^= data;
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (crc >> 1 ^ polynom);
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc & 65535;
        }

        // Token: 0x04000003 RID: 3
        private readonly int _polynom;

        // Token: 0x04000004 RID: 4
        public static readonly CRC Default = new CRC(40961);
    }
}