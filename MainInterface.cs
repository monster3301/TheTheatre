using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTheatre;
using System.Threading;

namespace TheTheatre
{
    class MainInterface
    {
        static void Main(string[] args)
        {   
            BoxOffice boxOffice = new BoxOffice();

            boxOffice.AddTickets(new Performance("Miss Saigon", "Claude-Michel Schönberg", "Epic", 1989), Convert.ToDateTime("20-05-2021 21:00"), 100, 15);
            boxOffice.AddTickets(new Performance("Mary Poppins", "P.L. Travers", "Comedy", 1964), Convert.ToDateTime("30-05-2021 20:00"), 100, 15);
            boxOffice.AddTickets(new Performance("Mary Poppins", "P.L. Travers", "Comedy", 1964), Convert.ToDateTime("30-05-2021 21:00"), 100, 15);
            boxOffice.AddTickets(new Performance("Mary Poppins", "P.L. Travers", "Comedy", 1964), Convert.ToDateTime("30-05-2021 22:00"), 100, 15);
            boxOffice.AddTickets(new Performance("Beauty and the Beast", "Alan Menken", "Comedy", 1991), Convert.ToDateTime("11-06-2021 19:30"), 250, 15);
            boxOffice.AddTickets(new Performance("Measure for Measure", " William Shakespeare", "Tragedy", 1604), Convert.ToDateTime("15-06-2021 20:00"), 250, 15);
            boxOffice.AddTickets(new Performance("The Tempest", "William Shakespeare", "Tragedy", 1623), Convert.ToDateTime("17-06-2021 21:30"), 300, 20);
            boxOffice.AddTickets(new Performance("Hernani", "Victor Hugo", "Drama", 1829), Convert.ToDateTime("19-06-2021 21:30"), 300, 20);
            boxOffice.AddTickets(new Performance("Cromwell", "Victor Hugo", "Drama", 1827), Convert.ToDateTime("23-06-2021 18:00"), 350, 30);
            boxOffice.AddTickets(new Performance("Cromwell", "Victor Hugo", "Drama", 1827), Convert.ToDateTime("23-06-2021 19:00"), 350, 30);
            boxOffice.AddTickets(new Performance("Cromwell", "Victor Hugo", "Drama", 1827), Convert.ToDateTime("23-06-2021 20:00"), 350, 30);



            
            Affiche affiche = new Affiche(boxOffice.Performances());
            Console.WriteLine("                                      Available performances in our theater ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            int counter = 0;
            int choice;
            Console.WriteLine();

            foreach (Performance performance in affiche.Performances)
            {
                counter++;
                Console.WriteLine($"{performance} - {counter}");
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine(" T:   Action to buy a ticket");
            Console.WriteLine(" F:   Page with criteria");
            Console.WriteLine(" E:   Exit");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.Write(" Your choice: ");

            char menuButt = Convert.ToChar(Console.ReadLine());
            if (menuButt == 'F')
            {
                Console.Clear();
                Console.WriteLine("Search criteria: ");
                Console.WriteLine("By author - 1");
                Console.WriteLine("By name - 2");
                Console.WriteLine("By genre - 3");
                Console.Write("Your choice: ");
                int crit = Convert.ToInt32(Console.ReadLine());

                string tempRead;
                while (true)
                {
                    if (crit == 1)
                    {

                        Console.Write("Choose the author you want: ");
                        tempRead = Console.ReadLine();
                        List<Performance> temp;
                        temp = affiche.GetByAuthor(tempRead);
                        foreach (Performance perf in temp) Console.WriteLine(perf);

                    }
                    else if (crit == 2)
                    {
                        Console.Write("Choose the name you want: ");
                        tempRead = Console.ReadLine();
                        List<Performance> temp;
                        temp = affiche.GetByName(tempRead);
                        foreach (Performance perf in temp) Console.WriteLine(perf);
                    }
                    else if (crit == 3)
                    {
                        Console.Write("Choose the genre you want: ");
                        tempRead = Console.ReadLine();
                        List<Performance> temp;
                        temp = affiche.GetByGenre(tempRead);
                        foreach (Performance perf in temp) Console.WriteLine(perf);

                    }
                    else
                    {
                        Console.WriteLine("Incorrect value");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    break;

                }
            }
            else if (menuButt == 'T')
            {
                Console.WriteLine();
                Console.WriteLine("Select the show you are interested in: ");
                choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose the right time for you: ");
                List<DateTime> times = boxOffice.GetTimes(affiche[choice - 1]);
                counter = 0;
                foreach (DateTime time in times)
                {
                    counter++;
                    Console.WriteLine($"{time:t} - {counter}");
                }
                int choice2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do you want to buy a ticket right now(4) or order(5)?");
                int choice3 = Convert.ToInt32(Console.ReadLine());
                if (choice3 == 4)
                {

                    if (boxOffice.BuyTicket(affiche[choice - 1], times[choice2 - 1])) 
                    {
                        Console.WriteLine("Congratulations! You bought a ticket!");

                    }
                }
                else if (choice3 == 5)
                {
                    if (boxOffice.BookTicket(affiche[choice - 1], times[choice2 - 1])) 
                    {
                        Console.WriteLine("Congratulations! You booked a ticket!");

                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else if(menuButt == 'E')
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Incorrect value");
                Thread.Sleep(2000);
                Console.Clear();
            }

            Console.ReadKey();


            
        }
    }
}