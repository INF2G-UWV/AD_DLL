using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_11
{
    /// <summary>
    ///     SingleLinkedList test
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    internal class ExampleSingleLinkedList
    {
        private static SinglyLinkedList<string> myList;

        /// <summary>
        ///     Main execution
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
            myList = new SinglyLinkedList<string>();
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
                Console.WriteLine("*****************************");
                Console.WriteLine("****SingleLinkedList Test****");
                Console.WriteLine("*****************************");
                Console.WriteLine("(A) Insert item at front");
                Console.WriteLine("(B) Insert item at back");
                Console.WriteLine("(C) Remove item from front");
                Console.WriteLine("(D) Remove item from back");
                Console.WriteLine("(E) Insert at given index");
                Console.WriteLine("(F) Remove from given index");
                Console.WriteLine("(G) Remove given item from list");
                Console.WriteLine("(H) Update an old item with a new item");
                Console.WriteLine("(I) Check if item exists in the list");
                Console.WriteLine("(J) Clears the list");
                Console.WriteLine("(K) Show the list");
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

                    //Insert name at index
                    case ConsoleKey.E:
                        Console.Write("\nEnter a name to insert: ");
                        value1 = Console.ReadLine();
                        Console.Write("\nEnter a index to at item: ");
                        value2 = Console.ReadLine();
                        int value3;
                        if (int.TryParse(value2, out value3))
                        {
                            if (myList.Count - 1 >= value3)
                            {
                                myList.InsertAt(value3, value1);
                                Console.WriteLine("\nItem {0} added", value1);
                            }
                            else
                            {
                                Console.WriteLine("\nIndex out of range!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input!");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Remove item at index
                    case ConsoleKey.F:
                        Console.Write("\nEnter a index to remove the item: ");
                        value1 = Console.ReadLine();
                        int value4;
                        if (int.TryParse(value1, out value4))
                        {
                            if (myList.Count - 1 >= value4)
                            {
                                myList.RemoveAt(value4);
                            }
                            else
                            {
                                Console.WriteLine("\nIndex out of range!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input!");
                        }
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Remove given name
                    case ConsoleKey.G:
                        Console.Write("\nEnter a name to remove: ");
                        value1 = Console.ReadLine();
                        myList.Remove(value1);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Update item
                    case ConsoleKey.H:
                        Console.WriteLine("\nEnter a old item to update: ");
                        value1 = Console.ReadLine();
                        Console.Write("\nEnter a new item to update the old item: ");
                        value2 = Console.ReadLine();
                        myList.Update(value1, value2);
                        Console.WriteLine("\nPress a key to continue");
                        Console.ReadKey(true);
                        break;

                    //Search for item
                    case ConsoleKey.I:
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
                    case ConsoleKey.J:
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
                    case ConsoleKey.K:
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