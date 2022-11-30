using Raylib_cs;
using cool_sharp;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            int[] arr = {3, 2, 4, 54, 1, 2};
            arr = Sorts.MergeSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i] + ",");
            }

            System.Console.WriteLine();

            Raylib.InitWindow(800, 480, "Hello World");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}