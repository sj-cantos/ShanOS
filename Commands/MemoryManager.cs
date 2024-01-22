// Assuming the CosmosMemoryManagement namespace is used
using Cosmos.Core.Memory;
using Cosmos.Core;
using System;

namespace ShanOS.CosmosMemoryManagement
{
    public class MemoryManager
    {
        public static void InitializeMemory()
        {
            GCImplementation.Init();
        }

        public static IntPtr AllocateMemory(uint size)
        {
            return (IntPtr)GCImplementation.AllocNewObject(size);  // Explicit cast to IntPtr
        }

        public static void FreeMemory(IntPtr address)
        {
            unsafe
            {
                Heap.Free(address.ToPointer());
            }
        }

        public static int CollectGarbage()
        {
            return Heap.Collect();
        }

        public static ulong GetAvailableRAM()
        {
            return GCImplementation.GetAvailableRAM();
        }

        public static ulong GetUsedMemory()
        {
            return GCImplementation.GetUsedRAM();
        }

        public static int GetAllocatedObjectCount()
        {
            return HeapSmall.GetAllocatedObjectCount();
        }
    }
}
