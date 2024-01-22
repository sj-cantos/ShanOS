using System;
using System.Collections.Generic;
using Cosmos.System;

namespace ShanOS.Commands
{
    internal class MemoryManager
    {
        private List<MemoryBlock> allocatedMemoryBlocks = new List<MemoryBlock>();

        public void AllocateMemory(ulong size)
        {
            allocatedMemoryBlocks.Add(new MemoryBlock(size));
        }

        public void DeallocateMemory(ulong size)
        {
            // In a real system, you would need to implement logic to find and deallocate the specific memory block.
            // For simplicity, let's remove the first allocated block regardless of size.
            var blockToRemove = allocatedMemoryBlocks.Find(b => b.Size == size);
            if (blockToRemove != null)
            {
                allocatedMemoryBlocks.Remove(blockToRemove);
            }
        }

        public ulong GetUsedMemory()
        {
            ulong usedMemory = 0;

            foreach (var block in allocatedMemoryBlocks)
            {
                usedMemory += block.Size;
            }

            return usedMemory;
        }

        private class MemoryBlock
        {
            public ulong Size { get; }

            public MemoryBlock(ulong size)
            {
                Size = size;
            }
        }
    }
}
