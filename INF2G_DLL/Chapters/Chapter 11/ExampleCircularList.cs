using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_11
{
    /// <summary>
    ///     CircularList test
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    internal class ExampleCircularList
    {
        private static CircularList<string> myList;

        /// <summary>
        ///     Main execution.
        /// </summary>
        /// <param name="args"></param>
        public static void Run()
        {
            CreateList();
            ListProgram();
        }

        /// <summary>
        ///     Create new list
        /// </summary>
        private static void CreateList()
        {
            myList = new CircularList<string>();
            //Add names in front
            myList.InsertAtFront("Marcel");
            myList.InsertAtFront("Ferdi");
            myList.InsertAtFront("Martijn");
            myList.InsertAtFront("Selami");
            myList.InsertAtFront("Xing");
        }

        /// <summary>
        ///     Linked list testing program.
        /// </summary>
        public static void ListProgram()
        {
            var runAgain = true;

            //Create strings.
            string value1, value2;

            try
            {
                //Show menu
                Console.Clear();
                Console.WriteLine("*************************");
                Console.WriteLine("****CircularList Test****");
                Console.WriteLine("*************************");
                Console.WriteLine("(A) Insert item at front");
                Console.WriteLine("(B) Insert item at back");
                Console.WriteLine("(C) Remove item from front");
                Console.WriteLine("(D) Remove item from back");
                Console.WriteLine("(E) Remove given item from list");
                Console.WriteLine("(F) Update an old item with a new item");
                Console.WriteLine("(G) Check if item exists in the list");
                Console.WriteLine("(H) Clears the list");
                Console.WriteLine("(I) Show the list");
                Console.WriteLine("(X) Back");
                Console.Write("\nSelect:");

                //input
                var choice = Console.ReadKey(true);
                Console.WriteLine();

                //Check input
                switch (choice.Key)
                {
                    //Enter name at front
                    case ConsoleKey.A:
                        Console.Write("\nEnter a name to insert: ");
                        value1 = Console.ReadLine();
                        myList.InsertAtFront(value1);
                        Console.WriteLine("\nItem {0} added", value1);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Enter name at back
                    case ConsoleKey.B:
                        Console.Write("\nEnter a name to insert: ");
                        value1 = Console.ReadLine();
                        myList.InsertAtBack(value1);
                        Console.WriteLine("\nItem {0} added", value1);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Remove from front
                    case ConsoleKey.C:
                        if (!(myList.IsEmpty))
                        {
                            myList.RemoveFromFront();
                        }
                        else
                        {
                            Console.WriteLine("\nNo items to delete");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Remove from back
                    case ConsoleKey.D:
                        if (!(myList.IsEmpty))
                        {
                            myList.RemoveFromBack();
                        }
                        else
                        {
                            Console.WriteLine("\nNo items to delete");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Remove given name
                    case ConsoleKey.E:
                        Console.Write("\nEnter a name to remove: ");
                        value1 = Console.ReadLine();
                        myList.Remove(value1);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Update item
                    case ConsoleKey.F:
                        Console.WriteLine("\nEnter a old item to update: ");
                        value1 = Console.ReadLine();
                        Console.Write("\nEnter a new item to update the old item: ");
                        value2 = Console.ReadLine();
                        myList.Update(value1, value2);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Search for item
                    case ConsoleKey.G:
                        Console.Write("\nEnter a item to search for: ");
                        value1 = Console.ReadLine();
                        if (myList.Contains(value1))
                        {
                            Console.WriteLine("\nItem {0} found in list!", value1);
                        }
                        else
                        {
                            Console.WriteLine("\nItem {0} not found", value1);
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Clear list
                    case ConsoleKey.H:
                        if (!(myList.IsEmpty))
                        {
                            myList.Clear();
                            Console.WriteLine("\nList cleared.");
                        }
                        else
                        {
                            Console.WriteLine("\nThe list is already empty");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Print list
                    case ConsoleKey.I:
                        if (!(myList.IsEmpty))
                        {
                            myList.ShowList();
                        }
                        else
                        {
                            Console.WriteLine("\nList is empty");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;
                    //Exit
                    case ConsoleKey.X:
                        runAgain = false;
                        break;
                    case ConsoleKey.Backspace:
                        runAgain = false;
                        break;
                }
                if (runAgain)
                {
                    ListProgram();
                }
            }
                //Catch if error   
            catch (InsertBeforeHeaderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}