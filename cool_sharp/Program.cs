using Raylib_cs;
using cool_sharp;

namespace cool_sharp
{
    static class Program
    {
        const int WIDTH = 800;
        const int HEIGHT = 480;
        const int BOX_HEIGHT = 10;
        const int BOX_WIDTH = 10;
        public static void Main()
        {
            int[] arr = { 3, 2, 4, 54, 1, 2 };

            int[] inited = Sorts.InitArray(50);
            // int[] ok = inited.Clone();
            // int[] ok = Sorts.CocktailSort(arr);
            // for (int i = 0; i < arr.Length; i++)
            // {
            //     Console.Write(ok[i] + ",");
            //     // Console.WriteLine($"position ({ok[i]}, {ok[i]})");
            // }

            Console.WriteLine();

            Raylib.InitWindow(WIDTH, HEIGHT, "sort");

            while (!Raylib.WindowShouldClose())
            {
                // Sorts.InsertionSort(inited);
                // Sorts.SelectionSort(inited);
                Sorts.MergeSort(inited);
                // Sorts.CocktailSort(inited);

                Raylib.CloseWindow();
            }
        }
    }
}