using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Heaps
// bugs! does not work
{
    public class Top_K_Frequent_Elements
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            PriorityQueue pq = new PriorityQueue(k);
            Dictionary<int, NumberCount> dict = new Dictionary<int, NumberCount>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] = new NumberCount();
                    dict[num].value = num;
                }
                else
                {
                    dict[num].count++;
                }
                pq.AddOrUpdate(dict[num]);
            }
            return pq.GetAns();

        }
    }
   public class PriorityQueue
    {
        NumberCount[] heap; int heapSize;
        public PriorityQueue(int k)
        {
            heap = new NumberCount[k];
            heapSize = 0;
        }

        public void AddOrUpdate(NumberCount n)
        {
            if (n.count >= 0)
            {
                Heapify(n.count);
            }
            else
            {
                if (heapSize != heap.Length)
                {
                    n.count = heapSize;
                    heap[heapSize] = n;
                    heapSize++;
                    Heapify(heapSize - 1);
                }
                else if (n.CompareTo(heap[0]) < 0)
                {
                    heap[0].count = -1;
                    heap[0] = n;
                    heap[0].count = 0;
                    Heapify(0);
                }
            }
        }
        private void Heapify(int i)
        {
            int parent = (i - 1) / 2;
            if (i != 0 && heap[parent].CompareTo(heap[i]) < 0)
            {
                SwapInHeap(parent, i);
                Heapify(parent);
                return;
            }

            int lc = (i * 2) + 1, rc = lc + 1;
            int selectedChild = lc;
            if (rc < heapSize && heap[lc].CompareTo(heap[rc]) < 0)
            {
                selectedChild = rc;
            }

            if (lc < heapSize && heap[i].CompareTo(heap[selectedChild]) < 0)
            {
                SwapInHeap(i, selectedChild);
                Heapify(selectedChild);
                return;
            }
        }
        private void SwapInHeap(int i, int j)
        {
            NumberCount t = heap[i];
            heap[i] = heap[j];
            heap[j] = t;

            heap[i].count = i;
            heap[j].count = j;
        }

        public List<int> GetAns()
        {
            Array.Sort(heap);
            return heap.OrderByDescending(y=>y).Select(x => x.value).ToList();
        }
    }
    public class NumberCount: IComparable<NumberCount>
    {
        public int value;
        public int count;

        //public NumberCount(int v, int c)
        //{
        //    value = v;
        //    count = c;
        //}
        public int CompareTo(NumberCount n)
        {
            if (count>n.count)
            {
                return -1;
            }
            else if (count < n.count)
            {
                return 1;
            }
            return 0;
        }
    }
}
