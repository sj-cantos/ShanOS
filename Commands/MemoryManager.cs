using System;

namespace ShanOS.CosmosMemoryManagement
{
    public class MemoryManager
    {
        private const uint PageSize = 4096; // Size of a page in bytes
        private const uint MemorySize = 1024 * 1024 * 32; // Total memory size in bytes (32 MB in this example)
        private static byte[] MemoryPool; // The entire memory pool
        private static bool[] MemoryMap; // Memory allocation map

        public static void InitializeMemory()
        {
            MemoryPool = new byte[MemorySize];
            MemoryMap = new bool[MemorySize / PageSize];

            // Mark all pages as unallocated initially
            for (int i = 0; i < MemoryMap.Length; i++)
            {
                MemoryMap[i] = false;
            }
        }

        public static IntPtr AllocateMemory(uint size)
        {
            uint pageCount = (size + PageSize - 1) / PageSize; // Calculate the number of pages needed

            for (int i = 0; i < MemoryMap.Length; i++)
            {
                if (IsBlockFree(i, pageCount))
                {
                    MarkBlockAllocated(i, pageCount);
                    return new IntPtr((uint)i * PageSize);
                }
            }

            // Memory allocation failed
            return IntPtr.Zero;
        }

        public static void FreeMemory(IntPtr address, uint size)
        {
            uint pageIndex = (uint)address.ToInt32() / PageSize;
            uint pageCount = (size + PageSize - 1) / PageSize;

            for (uint i = pageIndex; i < pageIndex + pageCount; i++)
            {
                MemoryMap[i] = false;
            }
        }

        public static ulong GetUsedMemory()
        {
            ulong usedMemory = 0;

            for (int i = 0; i < MemoryMap.Length; i++)
            {
                if (MemoryMap[i])
                {
                    usedMemory += PageSize;
                }
            }

            return usedMemory;
        }

        private static bool IsBlockFree(int startIndex, uint pageCount)
        {
            for (int i = startIndex; i < startIndex + pageCount && i < MemoryMap.Length; i++)
            {
                if (MemoryMap[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static void MarkBlockAllocated(int startIndex, uint pageCount)
        {
            for (int i = startIndex; i < startIndex + pageCount && i < MemoryMap.Length; i++)
            {
                MemoryMap[i] = true;
            }
        }
    }
}
