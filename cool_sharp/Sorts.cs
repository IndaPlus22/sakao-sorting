using System;
using System.Collections.Generic;
using System.Linq;
using Raylib_cs;

namespace cool_sharp
{
    public class Sorts
    {
        const int WIDTH = 800;
        const int HEIGHT = 480;
        const int BOX_HEIGHT = 10;
        const int BOX_WIDTH = 10;

        public static int[] SelectionSort(int[] arr)
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

                UpdateArray(arr);
            }

            return arr;
        }

        public static int[] InsertionSort(int[] arr)
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

                UpdateArray(arr);
            }

            return arr;
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

            return Merge(left.ToList(), right.ToList(), arr);
        }

        private static int[] Merge(List<int> leftArr, List<int> rightArr, int[] arr)
        {
            int size = leftArr.Count + rightArr.Count;
            int i = 0;
            while (leftArr.Count > 0 && rightArr.Count > 0)
            {
                if (leftArr[0] > rightArr[0])
                {
                    arr[i] = rightArr[0];
                    rightArr.RemoveAt(0);
                }
                else
                {
                    arr[i] = leftArr[0];
                    leftArr.RemoveAt(0);
                }

                UpdateArray(arr);
                i++;
            }

            while (leftArr.Count > 0)
            {
                arr[i] = leftArr[0];
                leftArr.RemoveAt(0);

                UpdateArray(arr);
                i++;
            }
            while (rightArr.Count > 0)
            {
                arr[i] = rightArr[0];
                rightArr.RemoveAt(0);

                UpdateArray(arr);
                i++;
            }
            
            return arr;
        }

        // https://www.geeksforgeeks.org/cocktail-sort/
        public static int[] CocktailSort(int[] arr)
        {
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;

                        swapped = true;
                        UpdateArray(arr);
                    }
                }

                if (!swapped) break;
                swapped = false;

                for (int i = arr.Length - 1; i > 0; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;

                        swapped = true;
                        UpdateArray(arr);
                    }
                }
            }
            return arr;
        }

        private static void UpdateArray(int[] arr)
        {
            (float, float)[] positions = PositionizeArray(arr);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            // Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
            DrawArray(positions);

            // waiting so i can see
            Raylib.WaitTime(0.005);

            Raylib.EndDrawing();

            
        }

        private static void DrawArray((float, float)[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Raylib.DrawRectangle((int)array[i].Item1, (int)array[i].Item2, BOX_WIDTH, BOX_HEIGHT, Color.BLACK);
            }
        }

        private static (float, float)[] PositionizeArray(int[] arr)
        {
            (float, float)[] res = new (float, float)[50];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = (i * (float)WIDTH / 50.0f, HEIGHT - ((float)arr[i] / arr.Max() * HEIGHT) - 1);
            }

            return res;
        }

        public static int[] InitArray(int size)
        {
            int[] arr = new int[size];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            return arr;
        }
    }
}
