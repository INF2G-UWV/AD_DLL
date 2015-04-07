using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_11
{
    /// <summary>
    ///     DoublyLinkedList test
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    internal class ExampleDoubleLinkedList
    {
        /// <summary>
        ///     Main execution
        /// </summary>
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
            LinkedListProgram();
        }

        /// <summary>
        ///     Main test
        /// </summary>
        public static void LinkedListProgram()
        {
            //Create new DoubleLinkedList (of string)
            var myList = new DoublyLinkedList<string>();
            
            //Add strings
            string choice, value1, value2;

            try
            {
                //Add names in front
                myList.InsertAtFront("Marcel");
                myList.InsertAtFront("Ferdi");
                myList.InsertAtFront("Martijn");
                myList.InsertAtFront("Selami");
                myList.InsertAtFront("Xing");
                //While application is active, show the following output on console
                while (true)
                {
                    Console.WriteLine("(A) Insert item at front");
                    Console.WriteLine("(B) Insert item at back");
                    Console.WriteLine("(C) Remove item from front");
                    Console.WriteLine("(D) Remove item from back");
                    Console.WriteLine("(E) Insert at given index");
                    Console.WriteLine("(F) Remove from given index");
                    Console.WriteLine("(G) Remove given item from list");
                    Console.WriteLine("(H) Update an old item with new item");
                    Console.WriteLine("(I) Shows true if item is in list and false otherwise");
                    Console.WriteLine("(J) Clears the list");
                    Console.WriteLine("(K) Show the list");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");

                    //Read input
                    choice = Console.ReadLine();

                    //Convert input to lowercase
                    choice = choice.ToLower();

                    //Convert to chararray
                    var onechar = choice.ToCharArray();

                    //Check input
                    switch (onechar[0])
                    {
                        //Enter name at front
                        case 'a':
                            Console.WriteLine();
                            Console.Write("Enter a name to insert: ");
                            value1 = Console.ReadLine();
                            myList.InsertAtFront(value1);
                            break;

                        //Enter name at back
                        case 'b':
                            Console.WriteLine();
                            Console.Write("Enter a name to insert: ");
                            value1 = Console.ReadLine();
                            myList.InsertAtBack(value1);
                            break;

                        //Remove from front
                        case 'c':
                            if (!(myList.IsEmpty))
                            {
                                myList.RemoveFromFront();
                            }
                            else
                            {
                                Console.WriteLine("No items to delete");
                            }
                            break;

                        //Remove from back
                        case 'd':
                            if (!(myList.IsEmpty))
                            {
                                myList.RemoveFromBack();
                            }
                            else
                            {
                                Console.WriteLine("No items to delete");
                            }
                            break;

                        //Insert name at index
                        case 'e':
                            Console.WriteLine();
                            Console.Write("Enter a name to insert: ");
                            value1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter a index to at item: ");
                            value2 = Console.ReadLine();
                            var value3 = Int32.Parse(value2);
                            myList.InsertAt(value3, value1);
                            break;

                        //Remove item at index
                        case 'f':
                            Console.WriteLine();
                            Console.Write("Enter a index to remove the item: ");
                            value1 = Console.ReadLine();
                            var value4 = Int32.Parse(value1);
                            myList.RemoveAt(value4);
                            break;

                        //Remove given name
                        case 'g':
                            Console.WriteLine();
                            Console.Write("Enter a name to remove: ");
                            value1 = Console.ReadLine();
                            myList.Remove(value1);
                            break;

                        //Update item
                        case 'h':
                            Console.WriteLine();
                            Console.WriteLine("Enter a old item to update: ");
                            value1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter a new item to update the old item: ");
                            value2 = Console.ReadLine();
                            myList.Update(value1, value2);
                            break;

                        //Search for item
                        case 'i':
                            Console.WriteLine();
                            Console.Write("Enter a item to search for: ");
                            value1 = Console.ReadLine();
                            myList.Contains(value1);
                            break;

                        //Clear list
                        case 'j':
                            if (!(myList.IsEmpty))
                            {
                                myList.Clear();
                            }
                            else
                            {
                                Console.WriteLine("The list is already empty");
                            }
                            break;

                        //Print list
                        case 'k':
                            if (!(myList.IsEmpty))
                            {
                                myList.ShowList();
                            }
                            else
                            {
                                Console.WriteLine("List is empty");
                            }
                            break;
                    }
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