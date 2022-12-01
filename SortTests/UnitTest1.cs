using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raylib_cs;
using cool_sharp;

namespace TestSorting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestInsertionSort()
    {
        Raylib.InitWindow(800, 480, "sort");

        // int[] unsort = Sorts.InitArray(50);
        int[] unsort = { 3, 2, 4, 54, 1, 2 };
        int[] sorted = (int[])unsort.Clone();
        Array.Sort(sorted);

        while (!Raylib.WindowShouldClose())
        {
            unsort = Sorts.InsertionSort(unsort);

            Raylib.CloseWindow();
        }

        CollectionAssert.AreEqual(sorted, unsort);
    }

    [TestMethod]
    public void TestSelectionSort()
    {
        Raylib.InitWindow(800, 480, "sort");

        int[] unsort = { 3, 2, 4, 54, 1, 2 };
        // int[] unsort = Sorts.InitArray(50);
        int[] sorted = (int[])unsort.Clone();
        Array.Sort(sorted);

        while (!Raylib.WindowShouldClose())
        {
            unsort = Sorts.SelectionSort(unsort);

            Raylib.CloseWindow();
        }

        CollectionAssert.AreEqual(sorted, unsort);
    }

    [TestMethod]
    public void TestMergeSort()
    {
        Raylib.InitWindow(800, 480, "sort");
        
        int[] unsort = { 3, 2, 4, 54, 1, 2 };
        // int[] unsort = Sorts.InitArray(50);
        int[] sorted = (int[])unsort.Clone();
        Array.Sort(sorted);

        while (!Raylib.WindowShouldClose())
        {
            unsort = Sorts.MergeSort(unsort);

            Raylib.CloseWindow();
        }

        CollectionAssert.AreEqual(sorted, unsort);
    }

    [TestMethod]
    public void TestCocktailSort()
    {
        Raylib.InitWindow(800, 480, "sort");

        int[] unsort = { 3, 2, 4, 54, 1, 2 };
        int[] sorted = (int[])unsort.Clone();
        Array.Sort(sorted);

        while (!Raylib.WindowShouldClose())
        {
            unsort = Sorts.CocktailSort(unsort);

            Raylib.CloseWindow();
        }

        CollectionAssert.AreEqual(sorted, unsort);
    }
}