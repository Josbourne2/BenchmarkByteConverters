using System;

namespace BenchmarkByteConverters
{
    // Token: 0x02000003 RID: 3
    public class BytesSwapper
    {
        // Token: 0x06000009 RID: 9 RVA: 0x000023E3 File Offset: 0x000005E3
        public static short Swap(short value)
        {
            return (short)((value >> 8 & 255) | (int)(value & 255) << 8);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x000023F9 File Offset: 0x000005F9
        public static ushort Swap(ushort value)
        {
            return (ushort)((value >> 8 & 255) | (int)(value & 255) << 8);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x0000240F File Offset: 0x0000060F
        public static int Swap(int value)
        {
            return (value >> 24 & 255) | (value >> 16 & 255) << 8 | (value >> 8 & 255) << 16 | (value & 255) << 24;
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002440 File Offset: 0x00000640
        public static uint Swap(uint value)
        {
            return (value >> 24 & 255U) | (value >> 16 & 255U) << 8 | (value >> 8 & 255U) << 16 | (value & 255U) << 24;
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002474 File Offset: 0x00000674
        public static long Swap(long value)
        {
            return (value >> 56 & 255L) | (value >> 48 & 255L) << 8 | (value >> 40 & 255L) << 16 | (value >> 32 & 255L) << 24 | (value >> 24 & 255L) << 32 | (value >> 16 & 255L) << 40 | (value >> 8 & 255L) << 48 | (value & 255L) << 56;
        }

        // Token: 0x0600000E RID: 14 RVA: 0x000024F0 File Offset: 0x000006F0
        public static ulong Swap(ulong value)
        {
            return (value >> 56 & 255UL) | (value >> 48 & 255UL) << 8 | (value >> 40 & 255UL) << 16 | (value >> 32 & 255UL) << 24 | (value >> 24 & 255UL) << 32 | (value >> 16 & 255UL) << 40 | (value >> 8 & 255UL) << 48 | (value & 255UL) << 56;
        }
    }
}