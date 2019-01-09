using System;

namespace DataStructures.Heap
{
    public class MinHeap
    {
        public static int capacity = 10;
        private int size = 0;

        public int[] items = new int[capacity];
        private int GetLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int GetRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int GetParentindex(int childIndex) { return (childIndex - 1) / 2; }

        private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < size; }
        private bool HasRightChild(int index) { return GetRightChildIndex(index) < size; }
        private bool HasParent(int index) { return GetParentindex(index) >= 0; }

        private int GetLeftChild(int index) { return items[GetLeftChildIndex(index)]; }
        private int GetRightChild(int index) { return items[GetRightChildIndex(index)]; }
        private int GetParent(int index) { return items[GetParentindex(index)]; }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (size == capacity)
            {
                int[] temp = new int[capacity*2];
                // Array.Copy(items, temp, capacity);
                temp = items;
                capacity = capacity * 2;
            }
        }
        public int Peek()
        {
            if (size == 0) throw new Exception();
            return items[0];
        }
        public int Poll()
        {
            if (size == 0) throw new Exception();
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }
        public void Add(int item)
        {
            EnsureExtraCapacity();
            size++;
            items[size] = item;
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            int index = size - 1;
            while (HasParent(index) && GetParent(index)> items[index])
            {
                Swap(GetParentindex(index),index);
                index = GetParentindex(index);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChildIndex(index)< GetLeftChildIndex(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (items[index] <items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }
}
