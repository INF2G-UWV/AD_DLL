using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_2
{
    /// <summary>
    ///     ArrayList Test
    ///     Author: Marcel Schoeber/Ferdi Smit - INF2G
    /// </summary>
    internal class ArrayListTest<T>
    {
        private static ArrayList<string> myList;

        /// <summary>
        ///     Main Execution
        /// </summary>
        public static void Run()
        {
            CreateList();
            ArrayListProgram();
        }

        /// <summary>
        ///     Create new list
        /// </summary>
        private static void CreateList()
        {
            myList = new ArrayList<string>();
            //Add names in front
            myList.Add("Marcel");
            myList.Add("Ferdi");
            myList.Add("Martijn");
            myList.Add("Selami");
            myList.Add("Xing");
        }

        /// <summary>
        ///     Linked list testing program.
        /// </summary>
        public static void ArrayListProgram()
        {
            var runAgain = true;

            //Create strings.
            string value1, value2;

            try
            {
                //Show menu
                Console.Clear();
                Console.WriteLine("**********************");
                Console.WriteLine("****ArrayList Test****");
                Console.WriteLine("**********************");
                Console.WriteLine("(A) Add item");
                Console.WriteLine("(B) Insert at given index");
                Console.WriteLine("(C) Remove from given index");
                Console.WriteLine("(D) Remove given item from list");
                Console.WriteLine("(E) Update an old item with a new item");
                Console.WriteLine("(F) Check if item exists in the list");
                Console.WriteLine("(G) Clears the list");
                Console.WriteLine("(H) Show the list");
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
                        Console.Write("\nEnter a name to add: ");
                        value1 = Console.ReadLine();
                        myList.Add(value1);
                        Console.WriteLine("\nItem {0} added", value1);
                        break;

                    //Insert name at index
                    case ConsoleKey.B:
                        Console.Write("\nEnter a name to insert: ");
                        value1 = Console.ReadLine();
                        Console.Write("\nEnter a index to at item: ");
                        value2 = Console.ReadLine();
                        int value3;
                        if (int.TryParse(value2, out value3))
                        {
                            if (myList.Length() - 1 >= value3 && value3 >= 0)
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
                        break;

                    //Remove item at index
                    case ConsoleKey.C:
                        Console.Write("\nEnter a index to remove the item: ");
                        value1 = Console.ReadLine();
                        int value4;
                        if (int.TryParse(value1, out value4))
                        {
                            if (myList.Length() - 1 >= value4 && value4 >= 0)
                            {
                                myList.RemoveAt(value4);
                                Console.WriteLine("\nItem removed");
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
                        break;

                    //Remove given name
                    case ConsoleKey.D:
                        Console.Write("\nEnter a name to remove: ");
                        value1 = Console.ReadLine();
                        myList.Remove(value1);
                        break;

                    //Update item
                    case ConsoleKey.E:
                        Console.WriteLine("\nEnter a old item to update: ");
                        value1 = Console.ReadLine();
                        Console.Write("\nEnter a new item to update the old item: ");
                        value2 = Console.ReadLine();
                        myList.Update(value1, value2);
                        break;

                    //Search for item
                    case ConsoleKey.F:
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
                        break;

                    //Clear list
                    case ConsoleKey.G:
                        if (!(myList.IsEmpty()))
                        {
                            myList.Clear();
                            Console.WriteLine("\nList cleared.");
                        }
                        else
                        {
                            Console.WriteLine("\nThe list is already empty");
                        }
                        break;

                    //Print list
                    case ConsoleKey.H:
                        if (!(myList.IsEmpty()))
                        {
                            myList.ShowList();
                        }
                        else
                        {
                            Console.WriteLine("\nList is empty");
                        }
                        break;
                    case ConsoleKey.X:
                        runAgain = false;
                        break;

                    default:
                        Console.WriteLine("\nUnrecognized input!");
                        break;
                }
                if (runAgain)
                {
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey(true);
                    ArrayListProgram();
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