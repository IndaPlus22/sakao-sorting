using System;
using System.Collections.Generic;
using System.Linq;

namespace cool_sharp
{
    public class Sorts
    {
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = x;
            }
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1) return arr;

            int[] left = new int[arr.Length / 2];
            int[] right = new int[arr.Length - arr.Length / 2];

            for (int i = 0; i < left.Length; i++)
                left[i] = arr[i];

            for (int i = 0; i < right.Length; i++)
                right[i] = arr[arr.Length / 2 + i];

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left.ToList(), right.ToList());
        }

        public static int[] Merge(List<int> leftArr, List<int> rightArr)
        {
            int size = leftArr.Count + rightArr.Count;
            List<int> arr = new List<int>();
            
            while (leftArr.Count > 0 && rightArr.Count > 0)
            {
                if (leftArr[0] > rightArr[0])
                {
                    arr.Add(rightArr[0]);
                    rightArr.RemoveAt(0);
                }
                else
                {
                    arr.Add(leftArr[0]);
                    leftArr.RemoveAt(0);
                }
            }

            while (leftArr.Count > 0)
            {
                arr.Add(leftArr[0]);
                leftArr.RemoveAt(0);
            }
            while (rightArr.Count > 0)
            {
                arr.Add(rightArr[0]);
                rightArr.RemoveAt(0);
            }

            return arr.ToArray();
        }
    }
}
