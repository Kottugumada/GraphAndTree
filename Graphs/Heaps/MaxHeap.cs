using System;

namespace Heaps
{
    public class MaxHeap
    {
        private static int capacity = 10;
        private static int size = 0;
        static int[] items = new int[capacity];

        private static int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private static int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private static int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private static int getLeftChild(int parentIndex) { return items[getLeftChildIndex(parentIndex)]; }
        private static int getRightChild(int parentIndex) { return items[getRightChildIndex(parentIndex)]; }
        private static int getParent(int childIndex) { return items[getParentIndex(childIndex)]; }

        private static bool hasLeftChild(int parentIndex) { return getLeftChildIndex(parentIndex) < size; }
        private static bool hasRightChild(int parentIndex) { return getRightChildIndex(parentIndex) < size; }
        private static bool hasParent(int childIndex) { return getLeftChildIndex(childIndex) > 0; }

        private static void swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private static void hasEnoughCapacity()
        {
            if (size == capacity)
            {
                Array.Resize(ref items, capacity * 2);
                capacity *= 2;
            }
        }

        public static void Add(int item)
        {
            hasEnoughCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        public static int Remove()
        {
            int item = items[0];
            items[0] = items[size - 1];
            items[size - 1] = 0;
            size--;
            heapifyDown();
            return item;
        }

        private static void heapifyUp()
        {
            int index = size - 1;
            while (hasParent(index) && items[index] > getParent(index))
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        private static void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int bigChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && getLeftChild(index) < getRightChild(index))
                {
                    bigChildIndex = getRightChildIndex(index);
                }

                if (items[bigChildIndex] < items[index])
                {
                    break;
                }
                else
                {
                    swap(bigChildIndex, index);
                    index = bigChildIndex;
                }
            }
        }
    }
}

/*
Calling Code:
    MaxHeap mh = new MaxHeap();
    mh.Add(10);
    mh.Add(5);
    mh.Add(2);
    mh.Add(1);
    mh.Add(50);
    int maxVal  = mh.Remove();
    int newMaxVal = mh.Remove();
*/
