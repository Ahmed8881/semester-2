
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MUser> users = new List<MUser>();
            List<Flight_Details> flight_details = new List<Flight_Details>();
            string path = "textfile.txt";
            int option;
            bool check = ReadData(path, users);
            // bool check1 = ReadData(path, flight_details);
            if (check)
            {
                Console.WriteLine("Data Loaded");
            }
            else
                Console.WriteLine("Data not loaded");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                option = Mainmenu();
                Console.Clear();
                if (option == 1)
                {
                    MUser user = TakeiputsWithoutRole();
                    if (user != null)
                    {
                        user = SignIn(user, users);
                        if (user == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (user.isAdmin())
                        {
                            string op = "0";
                            while (op != "5")
                            {
                                Console.WriteLine("Admin menu");
                                AdminMenu();
                                op = TakeInputforAdmin();
                                if (op == "1")
                                {
                                    Console.Clear();

                                    Add_Flight(flight_details);
                                }
                                else if (op == "2")
                                {
                                    Console.Clear();
                                    DeleteFlight(flight_details);
                                }
                                else if (op == "3") { Console.Clear(); UpdateFlight(flight_details); }
                                else if (op == "4") { Console.Clear(); DisplayFlight(flight_details); }
                                else
                                {
                                    Console.Write("Invalid option....");
                                }
                            }
                        }
                        else
                            Console.WriteLine("User menu");
                    }
                }
                else if (option == 2)
                {
                    MUser user = TakeInputsWithRole();
                    if (user != null)
                    {
                        storeDataInFile(path, user);
                        storeDtaInList(users, user);
                    }
                }
                Console.ReadKey();
            }
        }
        static void MainHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"             _    ___ ____  _     ___ _   _ _____           __  __    _    _   _    _    ____ __  __ _____ _   _ _____  ");
            Console.WriteLine(@"            / \  |_ _|  _ \| |   |_ _| \ | | ____|         |  \/  |  / \  | \ | |  / \  / ___|  \/  | ____| \ | |_   _| ");
            Console.WriteLine(@"           / _ \  | || |_) | |    | ||  \| |  _|           | |\/| | / _ \ |  \| | / _ \| |  _| |\/| |  _| |  \| | | |   ");
            Console.WriteLine(@"          / ___ \ | ||  _ <| |___ | || |\  | |___          | |  | |/ ___ \| |\  |/ ___ \ |_| | |  | | |___| |\  | | |   ");
            Console.WriteLine(@"         /_/   \_\___|_| \_\_____|___|_| \_|_____          |_|  |_/_/   \_\_| \_/_/   \_\____|_|  |_|_____|_| \_| |_|   ");
            Console.WriteLine(@"                                ______   ______ _____ _____ __  __                                                      ");
            Console.WriteLine(@"                               / ___\ \ / / ___|_   _| ____|  \/  |                                                     ");
            Console.WriteLine(@"                               \___ \\ V /\___ \ | | |  _| | |\/| |                                                     ");
            Console.WriteLine(@"                                ___) || |  ___) || | | |___| |  | |                                                     ");
            Console.WriteLine(@"                               |____/ |_| |____/ |_| |_____|_|  |_|                                                     ");
            Console.ResetColor();
        }
        static int Mainmenu()
        {
            int option;
            MainHeader();           
            Console.WriteLine("1-Sign In");
            Console.WriteLine("2-Sign Up");
            Console.WriteLine("3-Exit");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static MUser TakeiputsWithoutRole()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;

        }
        static MUser TakeInputsWithRole()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }
        static void storeDtaInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }
        static MUser SignIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.username == storedUser.username && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;

        }
        static void storeDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.username + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();

        }
        static void storeDataInFile(string path, Flight_Details flight)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(flight.Route + "," + flight.Price + "," + flight.seat_Num + "," + flight.time);
            file.Flush();
            file.Close();
        }
        static void storeDtaInList(List<Flight_Details> flight_Details, Flight_Details flight)
        {
            flight_Details.Add(flight);
        }
        static bool ReadData(string path, List<Flight_Details> flight_Details)
        {
            if (File.Exists(path))
            {
                StreamReader fileVaraible = new StreamReader(path);
                string record;
                while ((record = fileVaraible.ReadLine()) != null)
                {
                    string route = parseData(record, 1);
                    int price = int.Parse(parseData(record, 2));
                    int seat = int.Parse(parseData(record, 3));
                    string time = parseData(record, 4);
                    Flight_Details flight = new Flight_Details(route, price, seat, time);
                    storeDtaInList(flight_Details, flight);
                }
                fileVaraible.Close();
                return true;

            }
            return false;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record;
                }
            }
            return item;

        }
        static bool ReadData(string path, List<MUser> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVaraible = new StreamReader(path);
                string record;
                while ((record = fileVaraible.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    storeDtaInList(users, user);
                }
                fileVaraible.Close();
                return true;

            }
            return false;
        }
        static void AdminMenu()
        {
            ClearScreen();
            Console.WriteLine(".......................ADMIN PAGE........................");
            Console.WriteLine("1-ADD FLIGHT");
            Console.WriteLine("2-DELETE FLIGHT");
            Console.WriteLine("3-UPDATE FLIGHT");
            Console.WriteLine("4-DISPLAY FLIGHT");
            Console.Write("Enter your Choice: ");


        }
        static void ClearScreen()
        {
            Console.Clear();
        }
        static string TakeInputforAdmin()
        {
            string choice = Console.ReadLine();
            return choice;
        }
        static Flight_Details Add_Flight(List<Flight_Details> flight_details)
        {
        Again:
            ClearScreen();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("                                                                                     ");
            Console.WriteLine("    _    ____  ____    _____ _     ___ ____ _   _ _____   _   _ _____ ____  _____    ");
            Console.WriteLine("   / \\  |  _ \\|  _ \\  |  ___| |   |_ _/ ___| | | |_   _| | | | | ____|  _ \\| ____|   ");
            Console.WriteLine("  / _ \\ | | | | | | | | |_  | |    | | |  _| |_| | | |   | |_| |  _| | |_) |  _|     ");
            Console.WriteLine(" / ___ \\| |_| | |_| | |  _| | |___ | | |_| |  _  | | |   |  _  | |___|  _ <| |___    ");
            Console.WriteLine("/_/   \\_\\____/|____/  |_|   |_____|___\\____|_| |_| |_|   |_| |_|_____|_| \\_\\_____|   ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the route for the ticket: ");
            string route = Console.ReadLine();
            Console.Write("Enter price of the ticket: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of seats: ");
            int seat = int.Parse(Console.ReadLine());
            Console.Write("Enter the time of flight:");
            string time = Console.ReadLine();
            Flight_Details f1 = new Flight_Details(route, price, seat, time);
            flight_details.Add(f1);
            Console.WriteLine("Enter 1 to add an other flight: ");
            string choice = Console.ReadLine();
            if (choice == "1") { goto Again; }
            else
            {

                return f1;
            }


        }
        static void DeleteFlight(List<Flight_Details> flight_Details)
        {
            Console.WriteLine(@"    ____  _____ _     _____ _____ _____   _____ _     ___ ____ _   _ _____   _   _ _____ ____  _____   ");
            Console.WriteLine(@"   |  _ \| ____| |   | ____|_   _| ____| |  ___| |   |_ _/ ___| | | |_   _| | | | | ____|  _ \| ____   ");
            Console.WriteLine(@"   | | | |  _| | |   |  _|   | | |  _|   | |_  | |    | | |  _| |_| | | |   | |_| |  _| | |_) |  _|    ");
            Console.WriteLine(@"   | |_| | |___| |___| |___  | | | |___  |  _| | |___ | | |_| |  _  | | |   |  _  | |___|  _ <| |___   ");
            Console.WriteLine(@"   |____/|_____|_____|_____| |_| |_____| |_|   |_____|___\____|_| |_| |_|   |_| |_|_____|_| \_\_____  ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("Flight Number        Route       Price       Total seats     Time");
            Console.WriteLine("                                                                                                         ");
            for (int i = 0; i < flight_Details.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + flight_Details[i].Route + "\t\t" + flight_Details[i].Price + "\t\t" + flight_Details[i].seat_Num + "\t\t" + flight_Details[i].time);
            }

            Console.Write("Enter the flight number to delete: ");
            int flightNumber = int.Parse(Console.ReadLine());

            if (flightNumber > 0 && flightNumber <= flight_Details.Count)
            {
                flight_Details.RemoveAt(flightNumber - 1);
                Console.WriteLine("Flight deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid flight number.");
            }

        }
        static void UpdateFlight(List<Flight_Details> flight_Details)
        {
            MainHeader();
            Console.Write("Enter the flight number to update: ");
            int flightNumber = int.Parse(Console.ReadLine());

            if (flightNumber > 0 && flightNumber <= flight_Details.Count)
            {
                Console.Write("Enter the new route: ");
                string newRoute = Console.ReadLine();

                Console.Write("Enter the new price: ");
                int newPrice = int.Parse(Console.ReadLine());

                Console.Write("Enter the new total seats: ");
                int newTotalSeats = int.Parse(Console.ReadLine());

                Flight_Details flight = flight_Details[flightNumber - 1];
                flight.Route = newRoute;
                flight.Price = newPrice;
                flight.seat_Num = newTotalSeats;

                Console.WriteLine("Flight updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid flight number.");
            }
        }
        static void DisplayFlight(List<Flight_Details> flight_Details)
        {
            MainHeader();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight Number        Route       Price       Total seats     Time");
            Console.ForegroundColor=ConsoleColor.Blue;
            for (int i = 0; i < flight_Details.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + flight_Details[i].Route + "\t\t" + flight_Details[i].Price + "\t\t" + flight_Details[i].seat_Num + "\t\t" + flight_Details[i].time);
            }
            Console.WriteLine("");
            Console.ReadKey ();
             
            
        }
    }
}

