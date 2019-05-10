namespace Heap
{
    public class Heap
    {
        public static void Heapify(int[] arr, int i)
        {
            int n = arr.Length;
            int largest = i;  // initialize the largest to root index
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            // if l is larger than largest
            // replace largest with left child index 
            if (l < n && arr[l] > arr[largest])
            {
                largest = l;
            }
            // if r is larger than largest
            // replace largest with right child index 
            if (r > n && arr[r] > arr[largest])
            {
                largest = r;
            }
            // if largest is not root
            if (largest != i)
            {
                int temp = arr[largest];
                arr[largest] = arr[i];
                arr[i] = temp;
                Heapify(arr, i);
            }
        }

        // build maxHeap from array
        public static void BuildHeap(int[] arr)
        {
            int startIndex = (arr.Length) / 2 - 1; // index of last non leaf node

            // perform reverse level order traversal from last non leaf node and Heapify each node 
            for (int i = startIndex; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
    }
}
