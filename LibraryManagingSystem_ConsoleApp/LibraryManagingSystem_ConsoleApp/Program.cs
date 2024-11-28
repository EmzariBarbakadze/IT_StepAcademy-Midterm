namespace LibraryManagingSystem_ConsoleApp
{
    using System;
    using System.Collections.Generic;

    namespace BookManagementApp
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }

            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }

            public override string ToString()
            {
                return $"Title: {Title},  Author: {Author},  Year: {Year}";
            }
        }

        public class BookManager
        {
            private List<Book> books = new List<Book>();

            public void AddBook(Book book)
            {
                books.Add(book);
            }

            public void DisplayBooks()
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No books available.");
                    return;
                }

                Console.WriteLine("Book List:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }

            public void SearchBookByTitle(string title)
            {
                var foundBooks = books.FindAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

                if (foundBooks.Count == 0)
                {
                    Console.WriteLine("No books found with the given title.");
                    return;
                }

                Console.WriteLine("Search Results:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine(book);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                BookManager bookManager = new BookManager();

                while (true)
                {
                    Console.WriteLine("\nBook Management Console Application");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. View All Books");
                    Console.WriteLine("3. Search Book by Title");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();

                            Console.Write("Enter book author: ");
                            string author = Console.ReadLine();

                            int year;
                            Console.Write("Enter book publication year: ");
                            while (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
                            {
                                Console.Write("Invalid year. Please enter a valid positive number: ");
                            }

                            Book book = new Book(title, author, year);
                            bookManager.AddBook(book);
                            Console.WriteLine("Book added successfully!");
                            break;

                        case "2":
                            bookManager.DisplayBooks();
                            break;

                        case "3":
                            Console.Write("Enter book title to search: ");
                            string searchTitle = Console.ReadLine();
                            bookManager.SearchBookByTitle(searchTitle);
                            break;

                        case "4":
                            Console.WriteLine("Exiting the application. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
        }
    }

}

// gadaakete search funqcia 
