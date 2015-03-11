using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_3
{
    internal class Sort
    {
        public static void Run(string[] args)
        {
            SortingProgram();
        }

        public static void SortingProgram()
        {
            // String met letters en cijfers
            const string strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            // Lege string
            var emptyString = "";

            // De orginele array met strings
            var stringArray = new string[10];

            // Array waar de orginele array naar toe wordt gekopieerd
            var sortedArray = new string[10];

            // Random wordt gebruikt om random strings te kunnen maken
            var random = new Random(100);

            // De sorting class wordt gebruikt om de arrays te sorteren
            var sort = new Sorting<string>(stringArray);

            // Een dubbele loop om 10 random strings automatisch te genereren
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j <= 8; j++)
                {
                    emptyString += strings[random.Next(strings.Length)];
                }
                stringArray.SetValue(emptyString, i);
                emptyString = "";
            }

            // Kopie van de orginele array
            stringArray.CopyTo(sortedArray, 0);

            // Zolang het programma true is (dus het programma is draaiende) laat dan het volgende zien
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter a key from the list: ");
                Console.WriteLine("(p) Print a unsorted list.");
                Console.WriteLine("(b) Print a list sorted with the BubbleSort.");
                Console.WriteLine("(i) Print a list sorted with the InsertionSort.");
                Console.WriteLine("(c) Clear console");
                Console.WriteLine("(x) Exit program");
                Console.WriteLine();
                Console.WriteLine();

                // Het lezen van invoer
                var choice = Console.ReadLine();

                // De invoer omzetten naar kleine letter
                if (choice != null)
                {
                    choice = choice.ToLower();

                    // De kleine letters in een char array toevoegen
                    var oneChar = choice.ToCharArray();

                    // Switch statement voor het uitvoeren van de verschillende codes
                    switch (oneChar[0])
                    {
                        // Printen van de orginele array
                        case 'p':
                            Console.WriteLine();
                            Console.WriteLine("An unsorted list");
                            Console.WriteLine();
                            foreach (var singleString in stringArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Sorteren van de gekopieerde array met de BubbleSort()
                        case 'b':
                            Console.WriteLine();
                            Console.WriteLine("List sorted by the BubbleSort");
                            Console.WriteLine();
                            sort.BubbleSort(sortedArray);
                            foreach (var singleString in sortedArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Sorteren van de gekopieerde array met de InsertionSort()
                        case 'i':
                            Console.WriteLine();
                            Console.WriteLine("List sorted by the InsertionSort");
                            Console.WriteLine();
                            sort.InsertionSort(sortedArray);
                            foreach (var singleString in sortedArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Leegmaken van de console op de codes na
                        case 'c':
                            Console.Clear();
                            break;

                        // Afsluiten van het programma
                        case 'x':
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}