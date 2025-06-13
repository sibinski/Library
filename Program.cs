using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        string[] books = new string[5]; // Books array 

        int choice = 0; // Will ensure that choice is read from user input  


        while (choice != 4)
        {
            Console.WriteLine("Please choose an option: \n");
            Console.WriteLine(" - choose 1 to enter book titles for 5 books;\n");
            Console.WriteLine(" - choose 2 to delete a book title for a chosen book;\n");
            Console.WriteLine(" - choose 3 to display current list of book tiitles\n");
            Console.WriteLine(" - choose 4 to exit program;\n");


            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.\n");
                continue;
            }


            switch (choice)
            {
                case 1:
                    bool hasEmptySlots = false;
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (string.IsNullOrEmpty(books[i]))
                        {
                            hasEmptySlots = true;
                            break;
                        }
                    }

                    if (!hasEmptySlots)
                    {
                        Console.WriteLine("There are no empty slots\n");
                        break;
                    }
                    Console.WriteLine("Please enter titles for 5 books.\n");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (string.IsNullOrEmpty(books[i]))
                        {
                            Console.Write($"Enter title for book {i + 1}: \n");
                            string? title = Console.ReadLine();
                            books[i] = title ?? string.Empty; // Use null-coalescing operator to handle null input  
                        }
                        else
                        {
                            Console.WriteLine("No slots for new book titles are available, please remove any book titles...\n");
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Please enter a title of a book you wish to be removed from a list.\n");
                    string? input = Console.ReadLine();
                    bool found = false;

                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] != null && books[i].Equals(input, StringComparison.OrdinalIgnoreCase))
                        {
                            books[i] = string.Empty;
                            found = true;
                            Console.WriteLine($"Book \"{input}\" has been removed.\n");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Book \"{input}\" not found.\n");
                    }

                    Console.WriteLine("Remaining books: \n");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (!books[i].Equals(string.Empty))
                        {
                            Console.WriteLine(books[i]);
                        }
                        else
                        {
                            Console.WriteLine("The is no books in the list!\n");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("List of book titles: \n");
                    for ( int i =0; i < books.Length; i++)
                    {
                        Console.WriteLine(books[i].ToString());
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting program.\n");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}