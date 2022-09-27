using Library_Data;
using Library_Data.Migrations;
using Library_Domin;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Library_MainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
;
            init();
            bool check = false;
            Console.Write("Enter username : ");
            string  userdb = Console.ReadLine();
            Console.Write("Enter password : ");
            string passdb = Console.ReadLine();
            CheckLog(userdb, passdb);
            if (CheckLog(userdb, passdb))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------------dhab--------------------");
                Console.ForegroundColor = ConsoleColor.White;

                AddBooks();
                Console.Write("what is your name : ");
                string userName = Console.ReadLine();


                Console.WriteLine("-----------------------------------------\nHi  " + userName);
                Console.Write("-----------------------------------------\nNumber of eniqe Books in Library : ");
                GetNumberOfBooks();
                Console.Write("\nLets make travel in our Library \n-----------------------------------------\n");
                string cp = "";
                //GetBooks();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("What I Can do for U :\n#1 Enter 1 to get quick seen " +
                                            "\n#2 Enter 2 to see more details about specific book " +
                                            "\n#3 Enter 3 to modify name and price for specific book " +
                                            "\n#4 Enter 4 to Delete book " +
                                            "\n Enter 0 to exit" +
                                            "\nEnter --h for help", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;

                while (cp != "0")
                {
                    Console.WriteLine("-----------------------------------------\n What U want to Do ? ");
                    cp = Console.ReadLine();
                    switch (cp)
                    {
                        case "1":
                            Console.WriteLine("   ID   |   Name  ");
                            GetBooks();
                            break;
                        case "2":
                            Console.Write("in what id we talk about : ");
                            int id2 = Convert.ToInt32(Console.ReadLine());
                            getInfoBookById(2);
                            break;
                        case "3":
                            Console.Write("in what id we talk about : ");
                            int id3 = Convert.ToInt32(Console.ReadLine());
                            UpdateNamePrice(id3);
                            break;
                        case "4":
                            Console.Write("in what id we talk about : ");
                            int id4 = Convert.ToInt32(Console.ReadLine());
                            RemoveBook(id4);
                            break;
                        case "--h":
                            Console.WriteLine("What I Can do for U :\n#1 Enter 1 to get quick seen " +
                                                                    "\n#2 Enter 2 to see more details about specific book " +
                                                                    "\n#3 Enter 3 to modify name and price for specific book " +
                                                                    "\n#4 Enter 4 to Delete book " +
                                                                    "\n Enter 0 to exit" +
                                                                    "Enter --h for help");
                            break;
                        default:
                            Console.WriteLine("THX for visiting");
                            break;
                    }
                }


                using (var context = new LibraryDbContext())
                {
                    context.Database.EnsureCreated();



                }
            }
           
        }

        private static bool CheckLog(string userdb, string userpass)
        {
            using (var context = new LibraryDbContext())
            {
                var count = context.uspwds.Count();
                for (int i = 1; i <= count; i++)
                {
                    var uspw = context.uspwds.Where(e => e.id == i).ToList();
                    
                    foreach (var item in uspw)
                    {

                        var localu = item.username;
                        var localp= item.password;
                        if (userdb.Equals(localu) && userpass.Equals(localp))
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
            
        }

        private static void init()
        {
            bool flag = false;
            using (var context = new LibraryDbContext())
            {
                var test = context.uspwds.ToList();
                if (test.Count > 0)
                {
                    flag = true;
                }

            }
            if (!flag)
            {
                string jsonfile = File.ReadAllText("uspwd.json");
                var root = JsonSerializer.Deserialize<List<uspwd>>(jsonfile);

                using (var context = new LibraryDbContext())
                {
                    context.uspwds.AddRange(root);
                    context.SaveChanges();
                }

            }
        }

        private static void RemoveBook(int id)
        {
            using (var context = new LibraryDbContext())
            {
                var book = context.Books.
                    FirstOrDefault(e => e.id == id);
                book.isDeleted = true;
                context.Books.Update(book);
                context.SaveChanges();
                GetBooks();
            }
        }

        private static void UpdateNamePrice(int id)
        {
            using (var context = new LibraryDbContext())
            {
                var book = context.Books.
                    FirstOrDefault(e => e.id == id);
                Console.Write("Enter new name : ");
                string newName = Console.ReadLine();
                Console.Write("\nEnter new Price : ");
                double newPrice = Convert.ToDouble(Console.ReadLine());

                book.name = newName;
                book.price = newPrice;

                context.Books.Update(book);
                context.SaveChanges();
 
            }
        }

        private static void GetNumberOfBooks()
        {
            using (var context = new LibraryDbContext())
            {
                var count = context.Books.Count();
                Console.WriteLine(count);
            }
        }

        private static void getInfoBookById(int id) 
        {
            using (var context = new LibraryDbContext())
            {
                var book = context.Books.
                    FirstOrDefault(e => e.id == id);
                    

                    Console.WriteLine("Book Name     : "+book.name);
                    Console.WriteLine("Book Auther   : " + book.auther);
                    Console.WriteLine("Book Price    : " + book.price);
                    Console.WriteLine("Book Copies   : " + book.copies);
                    Console.WriteLine("Book Avilable : " + !book.isDeleted);


            } 
        }

        private static void AddBooks()
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                var books1 = new Book() { name = "Quran", auther = "god", copies = 100, price = 100 };

                context.Books.Add(books1);

                context.SaveChanges();
            }
        }

        private static void GetBooks()
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                var books = context.
                    Books.
                    Where(e => e.isDeleted !=true).
                    ToList();

                foreach (var book in books)
                {

                        Console.WriteLine("  " + book.id + "  |  " + book.name + "  |  " + book.auther + "  |  " + book.price + "  |  " + book.copies);

                }
            }
        }
    }
}