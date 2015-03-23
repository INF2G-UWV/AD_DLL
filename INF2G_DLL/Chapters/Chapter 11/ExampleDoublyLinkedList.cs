using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_11
{
    class ExampleDoubleLinkedList
    {
        public static void Run(string[] args)
        {
            LinkedListProgram();
        }

        public static void LinkedListProgram()
        {
            DoublyLinkedList<string> myList = new DoublyLinkedList<string>();
            string choice, value1, value2;
            try
            {
                myList.InsertAtFront("Marcel");
                myList.InsertAtFront("Ferdi");
                myList.InsertAtFront("Martijn");
                myList.InsertAtFront("Selami");
                myList.InsertAtFront("Xing");
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
                    choice = Console.ReadLine();
                    choice = choice.ToLower();
                    char[] onechar = choice.ToCharArray();
                    switch (onechar[0])
                    {
                        case 'a':
                            Console.WriteLine();
                            Console.Write("Enter a name to insert: ");
                            value1 = Console.ReadLine();
                            myList.InsertAtFront(value1);
                            break;
                        case 'b':
                            Console.WriteLine();
                            Console.Write("Enter a name to insert: ");
                            value1 = Console.ReadLine();
                            myList.InsertAtBack(value1);
                            break;
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
                        case 'f':
                            Console.WriteLine();
                            Console.Write("Enter a index to remove the item: ");
                            value1 = Console.ReadLine();
                            int value4 = Int32.Parse(value1);
                            myList.RemoveAt(value4);
                            break;
                        case 'g':
                            Console.WriteLine();
                            Console.Write("Enter a name to remove: ");
                            value1 = Console.ReadLine();
                            myList.Remove(value1);
                            break;
                        case 'h':
                            Console.WriteLine();
                            Console.WriteLine("Enter a old item to update: ");
                            value1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter a new item to update the old item: ");
                            value2 = Console.ReadLine();
                            myList.Update(value1, value2);
                            break;
                        case 'i':
                            Console.WriteLine();
                            Console.Write("Enter a item to search for: ");
                            value1 = Console.ReadLine();
                            myList.Contains(value1);
                            break;
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
            catch (InsertBeforeHeaderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
