using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_11
{ 
    class ExampleSingleLinkedList
    {
        public static void Run(string[] args)
        {
            
        }

        public static void LinkedListProgram()
        {
            SinglyLinkedList<string> myList = new SinglyLinkedList<string>();
            string choice, value;
            try
            {
                myList.InsertAtFront("Marcel");
                myList.InsertAtFront("Ferdi");
                myList.InsertAtFront("Martijn");
                myList.InsertAtFront("Selami");
                myList.InsertAtFront("Xing");
                while (true)
                {
                    Console.WriteLine("(IF) Insert item at front");
                    Console.WriteLine("(IB) Insert item at back");
                    Console.WriteLine("(RF) Remove item from front");
                    Console.WriteLine("(RB) Remove item from back");
                    Console.WriteLine("(IA) Insert at given index");
                    Console.WriteLine("(RA) Remove from given index");
                    Console.WriteLine("(R) Remove given item from list");
                    Console.WriteLine("(U) Update an old item with new item");
                    Console.WriteLine("(CO) Shows true if item is in list and false otherwise");
                    Console.WriteLine("(C) Clears the list");
                    Console.WriteLine("(S) Show the list");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();
                    choice = choice.ToLower();
                    char[] onechar = choice.ToCharArray();
                    switch (onechar[0])
                    {
                        case 'P':
                            if (!(myList.IsEmpty))
                            {
                                myList.ShowList();
                            }
                            else
                            {
                                Console.WriteLine("List is empty");
                            }
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
