using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // data for login
            string name;
            int sized = 100;
            int user_controller = 0;
            string password;
            string role;
            string role_check;
            int indexCount = 0;
            int pass = 100;
            string[] namearray = new string[100];
            string[] passwordarray = new string[100];
            string[] rolearray = new string[100];

            // data to add flight
            int idx_ticket = 0;
            string[] ticket_route = new string[100];
            string[] ticket_time = new string[100];
            int[] ticket_seat_Num = new int[100];
            int[] ticket_price = new int[100];
            bool[] reserve_seat = new bool[100];
            int[] seatsused = new int[100];
            int customer = 0;

            // data for employee
            int idx_employee = 0;
            string[] employee_name = new string[100];
            string[] employee_age = new string[100];
            string[] employee_num = new string[100];
            string[] employee_salary = new string[100];

            // data add to complains
            int length = 100;
            int idx_complian = 0;
            string[] customer_name = new string[length];
            string[] complain = new string[length];
            string[] customer_number = new string[length];

            // plane information data
            int planeCount = 0;
            int planeSize = 100;
            string[] Plane_id = new string[planeSize];
            string[] Plane_Type = new string[planeSize];
            string[] Plane_Capacity = new string[planeSize];
            string[] fuel_Capacity = new string[planeSize];
            string[] Plane_Range = new string[planeSize];
            string[] Plane_status = new string[planeSize];

            // loading data of login from file
            LoadLogin(namearray, passwordarray, rolearray, indexCount);
            LoadFlight(ticket_route, ticket_price, ticket_seat_Num, ticket_time, idx_ticket);
            LoadEmployee(employee_name, employee_age, employee_num, employee_salary, idx_employee);
            LoadPlanes(Plane_id, Plane_Type, Plane_Capacity, fuel_Capacity, Plane_Range, planeCount);
            LoadCustomerComplain(customer_name, customer_number, complain, idx_complian);

            int op = 0;
            while (op != 3)
            {
                if (op == 0)
                {
                    Console.Clear();
                    TopHeader();
                    SignPage();
                    op = choiceCheck(op);
                }
                else if (op == 1)
                {
                    SignUp(name, password, role);
                    bool check = SignUp(name, password, role, namearray, passwordarray, rolearray, sized, ref indexCount);
                    if (check)
                    {
                        SignString(name, password, role, namearray, passwordarray, rolearray, indexCount);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\t\tYou Have Successfully SignedUp\n");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tSignUp failed.\n");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                    }
                    op = 0;
                }
                else if (op == 2)
                {
                    Console.Write("\t\t\tEnter your name: ");
                    name = Console.ReadLine();
                    Console.Write("\t\t\tEnter your password: ");
                    password = Console.ReadLine();

                    Login(name, password, out role_check, namearray, passwordarray, rolearray, indexCount);
                    Thread.Sleep(1000);
                    op = 0;
                    if (role_check == "admin")
                    {
                        Console.Clear();
                        TopHeader();

                        while (op != 10)
                        {
                            if (op == 0)
                            {
                                Console.Clear();
                                TopHeader();
                                PageOfAdmin();
                                op = choiceCheck(op);
                            }

                            if (op == 1)
                            {
                                Console.Clear();
                                AddFlight(ticket_route, ticket_price, ticket_seat_Num, ticket_time, ref idx_ticket, op);
                            }
                            if (op == 2)
                            {
                                Console.Clear();
                                DeleteFlight(ticket_price, ticket_route, ticket_seat_Num, ticket_time, ref idx_ticket);
                            }
                            if (op == 3)
                            {
                                Console.Clear();
                                EmployeeAdd(employee_name, employee_age, employee_num, employee_salary, ref idx_employee);
                            }
                            if (op == 4)
                            {
                                Console.Clear();
                                DeleteEmployee(employee_name, employee_age, employee_num, ref idx_employee);
                            }
                            if (op == 5)
                            {
                                Console.Clear();
                                AddPlaneInfo(Plane_id, Plane_Type, Plane_Capacity, fuel_Capacity, Plane_Range, ref planeCount, planeSize);
                            }
                            if (op == 6)
                            {
                                Console.Clear();
                                ViewCustomerComplains(customer_name, customer_number, complain, idx_complian);
                            }
                            if (op == 7)
                            {
                                Console.Clear();
                                TotalAmountEarned(ticket_price, idx_ticket);
                            }
                            if (op == 8)
                            {
                                Console.Clear();
                                ViewFlights(ticket_price, ticket_route, ticket_seat_Num, ticket_time, idx_ticket);
                            }
                            if (op == 9)
                            {
                                Console.Clear();
                                ChangeTicketPrice(ticket_price, idx_ticket, ticket_route, ticket_time, ticket_seat_Num);
                            }
                            if (op == 11)
                            {
                                op = 10;
                                role_check = "";
                                break;
                            }
                        }
                        op = 0;
                    }
                    /////////////////////////////////////////////////////////////////////////customeer///////////////////////////////////////////////////
                    if (role_check == "customer")
                    {
                        while (true)
                        {
                            int op = 0;
                            if (op == 0)
                            {
                                Console.Clear();
                               TopHeader();
                                CustomerPage();
                                op = choiceCheck(op);
                            }
                            if (op == 1)
                            {
                                Console.Clear();
                                ViewFlights(ticket_price, ticket_route, ticket_seat_Num, ticket_time, idx_ticket);
                                Console.ReadKey();
                            }
                            else if (op == 2)
                            {
                                Console.Clear();
                                ReservesSeat(ticket_route, ticket_seat_Num, idx_ticket, reserve_seat, seatsused, ticket_price);
                            }
                            else if (op == 3)
                            {
                                Console.Clear();
                                SearchFlight(ticket_route, ticket_price, ticket_seat_Num, ticket_time, idx_ticket, planeSize);
                            }
                            else if (op == 4)
                            {
                                Console.Clear();
                                ViewReservedFlights(ticket_route, ticket_seat_Num, idx_ticket, reserve_seat, seatsused);
                                Console.ReadKey();
                            }
                            else if (op == 5)
                            {
                                Console.Clear();
                                AddComplains(customer_name, customer_number, complain, ref idx_complian);
                            }
                            else if (op == 6)
                            {
                                int idx_ticket1 = 0;
                                CancelFlight(ticket_route, ticket_seat_Num, idx_ticket, reserve_seat, seatsused, ticket_price, ref idx_ticket1);
                            }
                            else if (op == 7)
                            {
                                Console.Clear();
                                ConfirmPayment(ticket_route, ticket_seat_Num, idx_ticket, reserve_seat, seatsused, ticket_price, idx_ticket);
                            }
                            else if (op == 8)
                            {
                                DisplayAllPlanes(Plane_id, Plane_Type, Plane_Capacity, fuel_Capacity, Plane_Range, Plane_status, planeCount);
                                Console.ReadKey();
                            }
                            else if (op == 9)
                            {
                                Console.Clear();
                                ChangeUserPassword(namearray, passwordarray, rolearray, indexCount, pass);
                            }
                            else if (op == 10)
                            {
                                op = 0;
                                role_check = "";
                                break;
                            }
                        }
                        op = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    op = 0;
                    System.Threading.Thread.Sleep(700);
                }
            }
            StoreLogin(namearray, passwordarray, rolearray, indexCount);
            StoreFlight(ticket_route, ticket_price, ticket_seat_Num, ticket_time, idx_ticket);
            StoreEmployee(employee_name, employee_age, employee_num, employee_salary, idx_employee);
            StorePlanes(Plane_id, Plane_Type, Plane_Capacity, fuel_Capacity, Plane_Range, planeCount);
            StoreCustomerComplain(customer_name, customer_number, complain, idx_complian);

            Console.Clear();

        }
        static bool SignUp(string name, string password, string role, string[] nameArray, string[] passwordArray, string[] roleArray, int sizeD, ref int indexCount)
        {
            bool check = true;
            for (int i = 0; i < indexCount; i++)
            {
                if (nameArray[i] == name && passwordArray[i] == password)
                {
                    check = false;
                }
            }
            if ((role != "admin") && (role != "customer"))
            {
                check = false;
            }

            if (check)
            {
                if (indexCount <= sizeD)
                {
                    nameArray[indexCount] = name;
                    passwordArray[indexCount] = password;
                    roleArray[indexCount] = role;
                    indexCount++;
                }
            }
            return check;
        }
        static int INTVALIDATION(string command)
        {
            int temp = 0;
            string input;
            Console.Write(command);
            input = Console.ReadLine();
            try
            {
                temp = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                Thread.Sleep(700);
                goto AGAIN;
            }
            return temp;
        }
        static void ChangeUserPassword(string[] username, string[] userPassword, string[] userRole, int size, ref int userCount)
        {
            string name;
            string password;
            Console.Write("   Enter Current Name:  ");
            name = Console.ReadLine();
            Console.Write("   Enter Current Password:  ");
            password = Console.ReadLine();

            bool check = true;
            for (int i = 0; i < userCount; i++)
            {
                if (username[i] == name)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose what to change:");
                    Console.WriteLine("1. Change Username");
                    Console.WriteLine("2. Change Password");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice (1 or 2 or 3): ");
                    int op;
                    op = INTVALIDATION("");
                    string newName, newPassword;
                    if (op == 1)
                    {
                        Console.Write("   Enter name:  ");
                        username[i] = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Username changed successfully.");
                        Console.ResetColor();
                    }
                    else if (op == 2)
                    {
                        Console.Write("   Enter new Password:  ");
                        userPassword[i] = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Password changed successfully.");
                        Console.ResetColor();
                    }
                    else if (op == 3)
                    {
                        // Console.WriteLine("Press any key to exit....");
                        // Console.ReadKey();
                        // return;
                        goto last;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. No changes made.");
                    }
                    check = false;
                }
            }
            if (check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("   User not found. No changes made");
                Console.ResetColor();
            }
        last:
            Console.WriteLine();
            Console.Write("   Press any key to Exit:   ");
            Console.ReadKey();
            return;
        }

        static void Login(ref string name, ref string password, ref string roleCheck, string[] nameArray, string[] passwordArray, string[] roleArray, ref int indexCount)
        {
            if (Log(name, password, nameArray, passwordArray, ref indexCount))
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Login successful!");
                int dataIndex = SearchArray(nameArray, name, ref indexCount);
                Console.WriteLine("Welcome, " + nameArray[dataIndex] + "!");
                Console.WriteLine("Your role: " + roleArray[dataIndex]);
                roleCheck = roleArray[dataIndex];
            }
            else
            {
                Console.WriteLine("Login failed. User not found or incorrect password.");
            }
        }
        static string GetData(string data, int index)
        {
            string temp = "";
            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == ',')
                {
                    count++;
                    continue;
                }
                else if (count == index)
                {
                    temp += data[i];
                }
            }
            return temp;
        }
        static void TopHeader()
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
        static void SignPage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#########################################################################################################");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#                       ##   ##  ### ###  ####      ## ##    ## ##   ##   ##  ### ###                   #");
            Console.WriteLine("#                       ##   ##   ##       ##      ##       ##   ##  # ### #   ##                       #");
            Console.WriteLine("#                       ##   ##   ##  ##   ##      ##   ##  ##   ##   ## ##    ##  ##                   #");
            Console.WriteLine("#                       ## # ##   ## ##    ##      ##       ##   ##  ## # ##   ## ##                    #");
            Console.WriteLine("#                       # ### #   ##       ##      ##       ##   ##  ##   ##   ##                       #");
            Console.WriteLine("#                        ## ##    ##  ##   ##  ##  ##   ##  ##   ##  ##   ##   ##  ##                   #");
            Console.WriteLine("#                       ##   ##  ### ###  ### ###   ## ##    ## ##   ##   ##  ### ###                   #");
            Console.WriteLine("#########################################################################################################");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#              ##              ## ##     ####    ## ##   ###  ##  ##  ###  ### ##                       #");
            Console.WriteLine("#             ###             ##   ##     ##    ##   ##    ## ##  ##   ##   ##  ##                      #");
            Console.WriteLine("#              ##             ####        ##    ##        # ## #  ##   ##   ##  ##                      #");
            Console.WriteLine("#              ##              #####      ##    ##  ###   ## ##   ##   ##   ##  ##                      #");
            Console.WriteLine("#              ##                 ###     ##    ##   ##   ##  ##  ##   ##   ## ##                       #");
            Console.WriteLine("#              ##             ##   ##     ##    ##   ##   ##  ##  ##   ##   ##                          #");
            Console.WriteLine("#             ####             ## ##     ####    ## ##   ###  ##   ## ##   ####                         #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#               ##            ####       ## ##    ## ##  ####   ###   ##                                #");
            Console.WriteLine("#             ## ##            ##       ##   ##  ##   ##   ##    ##   ##                                #");
            Console.WriteLine("#            ##  ##            ##       ##   ##  ##   ##   ##     ##  ##                                #");
            Console.WriteLine("#                ##            ##       ##   ##  ##        ##    # ##  #                                #");
            Console.WriteLine("#              ##              ##       ##   ##  ##  ###   ##    ##  ###                                #");
            Console.WriteLine("#            #   ##            ##   ##  ##   ##  ##   ##   ##    ##   ##                                #");
            Console.WriteLine("#            ######            ### ###   ## ##    ## ##  ####   ###   ##                                #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#                                                                                                       #");
            Console.WriteLine("#########################################################################################################");
            Console.ResetColor();
        }

        static int ChoiceCheck(int op) // choice validation
        {
            Console.WriteLine("Enter your choice: ");
            op = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.WriteLine("Wrong Option...");
                    Console.WriteLine("Enter Option: ");
                }
                else
                {
                    break;
                }
            }
            return op;
        }
        static void Exit()
        {
            Console.Clear();
            TopHeader();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(@"        ___________  __    __       __      _____  ___   __   ___   ________      ");
            Console.WriteLine(@"        (""     _   "")/"" |  | ""\     /""\    (\""   \|"  \ |/ "" | / "") / ""       )    ");
            Console.WriteLine(@"         )__/  \\__/(:  (__)  :)   /    \   |.\\   \    |(: |/   / (:   \___/     ");
            Console.WriteLine(@"            \\_ /    \/      \/   /' /\  \  |: \.   \\  ||    /   \_  \       ");
            Console.WriteLine(@"            |.  |    //  __  \\  //  __'  \ |.  \    \. |(// _  \    __/  \\      ");
            Console.WriteLine(@"            \:  |   (:  (  )  :)/   /  \\  \|    \    \ ||: | \  \  /"" \   :)     ");
            Console.WriteLine(@"             \__|    \__|  |__/(___/    \___)\___|\____\)(__|  \__)(_______/      ");
        }
        static void SignUp(ref string name, ref string password, ref string role)
        {
            Console.WriteLine("\t\tENTER YOUR USER NAME: ");
            name = IsAlpha(Console.ReadLine());

            Console.WriteLine("\t\tENTER YOUR PASSWORD: ");
            password = PasswordLength1(Console.ReadLine());

            Console.WriteLine("\t\tENTER ROLE(admin or customer): ");
            role = Console.ReadLine();
        }
        static int SearchArray(string[] arr, string obj, ref int indexCount)
        {
            for (int i = 0; i <= indexCount; i++)
            {
                if (arr[i] == obj)
                {
                    return i;
                }
            }
            return -1;
        }
        static bool Log(string name, string password, string[] nameArray, string[] passwordArray, ref int indexCount)
        {
            int dataIndex = SearchArray(nameArray, name, ref indexCount);
            if (dataIndex == -1)
            {
                return false;
            }
            if (name == nameArray[dataIndex] && password == passwordArray[dataIndex])
            {
                return true;
            }
            return false;
        }
        static void SignString(string name, string password, string role, string[] nameArray, string[] passwordArray, string[] roleArray, ref int indexCount)
        {
            nameArray[indexCount] = name;
            passwordArray[indexCount] = password;
            roleArray[indexCount] = role;
            indexCount++;
        }

        static void PageOfAdmin()
        {
            Console.Clear();
            TopHeader();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...................................ADMIN LOGIN PAGE.........................................");
            Console.WriteLine("|                                                                                          |");
            Console.WriteLine("|         1--To add ticket ENTER 1:                                                        |"); // ok
            Console.WriteLine("|         2--To delete ticket ENTER 2:                                                     |"); // ok
            Console.WriteLine("|         3--To add new employ  ENTER 3                                                    |"); // ok
            Console.WriteLine("|         4--To delete new employ  ENTER 4                                                 |"); // ok
            Console.WriteLine("|         5--To add info of new plane  ENTER 5                                             |"); // add
            Console.WriteLine("|         6--To Check Complains  ENTER 6                                                   |"); // ok
            Console.WriteLine("|         7--To view total amount earned ENTER 7                                           |"); // check
            Console.WriteLine("|         8--To View flight details  ENTER 8                                               |");
            Console.WriteLine("|         9--To Change price of ticket  ENTER 9                                            |"); // check
            Console.WriteLine("|         10-To                                                                            |");
            Console.WriteLine("|         11-To Logout  ENTER 11                                                           |"); // ok
            Console.WriteLine("|         Enter your option here...                                                        |");
            Console.WriteLine("|                                                                                          |");
            Console.WriteLine("|__________________________________________________________________________________________|");

            // try to take it in main and pass by reference to this function
        }
        static void DisplayAllPlanes(string[] planeId, string[] planeType, string[] planeCapacity, string[] fuelCapacity, string[] planeRange, string[] planeStatus, int planeCount)
        {
            Console.Clear();
            Console.WriteLine("All Planes Details:");
            Console.WriteLine("<-------------------------->");

            for (int i = 0; i < planeCount; i++)
            {
                Console.WriteLine("Plane ID: " + planeId[i]);
                Console.WriteLine("Plane Type: " + planeType[i]);
                Console.WriteLine("Plane Range: " + planeRange[i] + " miles");
                Console.WriteLine("Plane Status: " + planeStatus[i]);
                Console.WriteLine("<-------------------------->");
            }
        }
        static void AddFlight(string[] ticket_route, int[] ticket_price, int[] ticket_seat_Num, string[] ticket_time, ref int idx_ticket, ref int op)
        {
        again:
            Console.Clear();
            TopHeader();

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

            Console.Write("Enter the time for the ticket in (24 hours format): ");
            string time;
        time:
            time = Console.ReadLine();
            if (!int.TryParse(time, out int temp) || temp > 24)
            {
                Console.WriteLine("Invalid time");
                Console.Write("Enter a valid time: ");
                goto time;
            }

            int seats;
            seats = INTVALIDATION("Enter the total number of seats: ");

            int price;
            price = INTVALIDATION("Enter the price of the ticket: RS");

            ticket_route[idx_ticket] = route;
            ticket_time[idx_ticket] = time;
            ticket_seat_Num[idx_ticket] = seats;
            ticket_price[idx_ticket] = price;
            idx_ticket++;

            Console.WriteLine();
            Console.WriteLine();
        again1:
            Console.WriteLine();
            Console.WriteLine("Enter 1 to add another ticket");
            Console.WriteLine("Enter 2 to go back");

            string check_flight = Console.ReadLine();

            if (check_flight == "1")
            {
                Console.Clear();
                goto again;
            }
            else if (check_flight == "2")
            {
                return;
            }
            else
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Invalid option..");
                goto again1;
            }
            Console.ReadKey();
        }
        static void DeleteFlight(int[] ticket_price, string[] ticket_route, int[] ticket_seat_Num, string[] ticket_time, int idx_ticket)
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
            Console.WriteLine("Flight Number          Route                    Price                    Price                    Total seats");
            Console.WriteLine("                                                                                                         ");
            for (int i = 0; i < idx_ticket; i++)
            {
                if (!string.IsNullOrEmpty(ticket_route[i]))
                {
                    Console.WriteLine($"{i + 1,-25}{ticket_route[i],-30}${ticket_price[i],-25}{ticket_time[i],-30}{ticket_seat_Num[i],-25}");
                    Console.WriteLine("                                                                                                          ");
                }
            }
            Console.Write("Enter the flight number you want to delete: ");
            Console.WriteLine(" ");
            Console.WriteLine("press 0 to return.....");
            int flight_num = int.Parse(Console.ReadLine());

            ticket_route[flight_num - 1] = "";

            for (int i = 0; i < idx_ticket; i++)
            {
                if (!string.IsNullOrEmpty(ticket_route[i]))
                {
                    Console.WriteLine($"Flight Number {i + 1}");
                    Console.WriteLine(ticket_route[i]);
                    Console.WriteLine(ticket_price[i]);
                    Console.WriteLine(ticket_time[i]);
                    Console.WriteLine(ticket_seat_Num[i]);
                }
            }
            Console.WriteLine();
            string addMore_employee;
        again2:
            Console.WriteLine("                                         ");
            Console.WriteLine("Enter 1 to add another employee");
            Console.WriteLine("Enter 2 to go back");
            addMore_employee = Console.ReadLine();
            if (addMore_employee == "1")
            {
                goto again;
            }
            else if (addMore_employee == "2")
            {
                return;
            }
            else
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Invalid option.");
                goto again2;
            }
            Console.ReadKey();
        }


        static void EmployeeAdd(string[] employee_name, string[] employee_age, string[] employee_num, string[] employee_salary, ref int idx_employee)
        {
        again:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(@"      _    ____  ____         _____ __  __ ____  _     _____   _______ _____  ");
            Console.WriteLine(@"     / \  |  _ \|  _ \       | ____|  \/  |  _ \| |   / _ \ \ / / ____| ____| ");
            Console.WriteLine(@"    / _ \ | | | | | | |      |  _| | |\/| | |_) | |  | | | \ V /|  _| |  _|   ");
            Console.WriteLine(@"   / ___ \| |_| | |_| |      | |___| |  | |  __/| |__| |_| || | | |___| |___  ");
            Console.WriteLine(@"  /_/   \_\____/|____/       |_____|_|  |_|_|   |_____\___/ |_| |_____|_____  ");

            Console.ForegroundColor = ConsoleColor.Green;

            string name, age, contact;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter the name of employee: ");
            Console.ReadLine();
            name = IsAlpha(name); // name and city validation

            Console.Write("Enter the age of employee: ");
            age = IsNum(age); // age validation

            Console.Write("Enter the contact number of employee: ");
            contact = ContactCheck(contact); // contact validation

            Console.Write("Enter the salary of employee: Rs ");
            string salary;
            salary = IsNum1(salary); // price

            employee_name[idx_employee] = name;
            employee_age[idx_employee] = age;
            employee_num[idx_employee] = contact;
            employee_salary[idx_employee] = salary;
            idx_employee++;

            string addMore_employee;
            Console.WriteLine();
            Console.WriteLine();
        again2:
            Console.WriteLine();
            Console.WriteLine("Enter 1 to add another employee");
            Console.WriteLine("Enter 2 to go back");
            addMore_employee = Console.ReadLine();
            if (addMore_employee == "1")
            {
                goto again;
            }
            else if (addMore_employee == "2")
            {
                return;
            }
            else
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Invalid option.");
                goto again2;
                return;
            }
            Console.ReadKey();
        }
        static void DeleteEmployee(string[] employee_name, string[] employee_age, string[] employee_num, int idx_employee)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"   ____  _____ _     _____ _____ _____   _____ __  __ ____  _     _____   _______ _____   ");
            Console.WriteLine(@"  |  _ \| ____| |   | ____|_   _| ____| | ____|  \/  |  _ \| |   / _ \ \ / / ____| ____|  ");
            Console.WriteLine(@"  | | | |  _| | |   |  _|   | | |  _|   |  _| | |\/| | |_) | |  | | | \ V /|  _| |  _|    ");
            Console.WriteLine(@"  | |_| | |___| |___| |___  | | | |___  | |___| |  | |  __/| |__| |_| || | | |___| |___   ");
            Console.WriteLine(@"  |____/|_____|_____|_____| |_| |_____| |_____|_|  |_|_|   |_____\___/ |_| |_____|_____|  ");
            Console.ResetColor();

            for (int i = 0; i < idx_employee; i++)
            {
                if (!string.IsNullOrEmpty(employee_name[i]))
                {
                    Console.WriteLine(" Employee Number " + (i + 1));
                    Console.WriteLine(employee_name[i]);
                    Console.WriteLine(employee_age[i]);
                    Console.WriteLine(employee_num[i]);
                }
            }

            Console.WriteLine("Enter the Employee number you want to delete");
            int employee_num1 = Convert.ToInt32(Console.ReadLine());
            employee_name[employee_num1 - 1] = "";

            for (int i = 0; i < idx_employee; i++)
            {
                if (!string.IsNullOrEmpty(employee_name[i]))
                {
                    Console.WriteLine(" Employee Number " + (i + 1));
                    Console.WriteLine(employee_name[i]);
                    Console.WriteLine(employee_age[i]);
                    Console.WriteLine(employee_num[i]);
                }
            }
        }
        static void ViewCustomerComplains(string[] customerName, string[] customerNumber, string[] complain, int idxComplain)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"     ____ _   _ ____ _____ ___  __  __ _____ ____        ____ ___  __  __ ____  _        _    ___ _   _ ____      ");
            Console.WriteLine(@"    / ___| | | / ___|_   _/ _ \|  \/  | ____|  _ \      / ___/ _ \|  \/  |  _ \| |      / \  |_ _| \ | / ___|     ");
            Console.WriteLine(@"   | |   | | | \___ \ | || | | | |\/| |  _| | |_) |    | |  | | | | |\/| | |_) | |     / _ \  | ||  \| \___ \     ");
            Console.WriteLine(@"   | |___| |_| |___) || || |_| | |  | | |___|  _ <     | |__| |_| | |  | |  __/| |___ / ___ \ | || |\  |___) |    ");
            Console.WriteLine(@"    \____|\___/|____/ |_| \___/|_|  |_|_____|_| \_\     \____\___/|_|  |_|_|   |_____/_/   \_\___|_| \_|____/     ");
            Console.ResetColor();

            for (int i = 0; i < idxComplain; i++)
            {
                if (!string.IsNullOrEmpty(customerName[i]))
                {
                    Console.WriteLine("..............................Complain number :" + (i + 1));
                    Console.WriteLine(".Name of customer :" + customerName[i]); ///////////////not implemented yet///////////////////////
                    Console.WriteLine(".Customer mobile number: " + customerNumber[i]);
                    Console.WriteLine("..............................Complian for customer is given as.......................");
                    Console.WriteLine(complain[i]);
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }
        static void TotalAmountEarned(int[] ticket_price, int idx_ticket)
        {
            int total = 0;
            for (int i = 0; i < idx_ticket; i++)
            {
                total = total + ticket_price[i];
            }
            Console.WriteLine("Total amount earned is: " + total);
            Console.ReadKey();
        }
        static void ChangeTicketPrice(int[] ticket_price, int idx_ticket, string[] ticket_route, string[] ticket_time, int[] ticket_seat_Num)
        {
            ViewFlights(ticket_price, ticket_route, ticket_seat_Num, ticket_time, idx_ticket);

            Console.Write("Enter the flight number you want to change the price of: ");
            int flight_num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the new price: ");
            int new_price = INTVALIDATION("Enter the new price: ");
            ticket_price[flight_num - 1] = new_price;
            Console.WriteLine("Price changed successfully!");
        }
        static void AddPlaneInfo(string[] Plane_id, string[] Plane_Type, string[] Plane_Capacity, string[] fuel_Capacity, string[] Plane_Range, ref int planeCount, int planeSize)
        {
        again:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter Plane Details:- ");
            Console.WriteLine("<-------------------------->");
            Console.ResetColor();

            Console.Write("Plane ID in numbers only: ");
            string plane_id = checkNumber(Console.ReadLine());

            Console.Write("Plane Number: ");
            string planeType = checkNumber(Console.ReadLine());

            Console.Write("Plane Capacity: ");
            string planeCapacity = checkNumber(Console.ReadLine());

            Console.Write("Fuel Capacity (in litres): ");
            string fuelcapacity = checkNumber(Console.ReadLine());

            Console.Write("Plane Range (in miles): ");
            string planeRange = checkNumber(Console.ReadLine());

            bool check = AddPlane(plane_id, planeType, planeCapacity, planeRange, fuelcapacity, Plane_id, Plane_Type, Plane_Capacity, fuel_Capacity, Plane_Range, ref planeCount, planeSize);
            if (check)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Plane added Successfully");
                Console.ResetColor();
            }

            if (!check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Plane not added.");
                Console.ResetColor();
            }

            string check_flight;
            Console.WriteLine();
            Console.WriteLine();
        again1:
            Console.WriteLine();
            Console.WriteLine("Enter 1 to add another ticket");
            Console.WriteLine("Enter 2 to go back");

            check_flight = Console.ReadLine();

            if (check_flight == "1")
            {
                Console.Clear();
                goto again;
            }
            else if (check_flight == "2")
            {
                return;
            }
            else
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Invalid option..");
                goto again1;
            }
            Console.ReadKey();
        }
        static bool addPlane(string plane_id, string planeType, string planecapacity, string planeRange, string fuelcapacity, string[] Plane_id, string[] Plane_Type, string[] Plane_Capacity, string[] fuel_Capacity, string[] Plane_Range, ref int planeCount, int planeSize)
        {
            bool check = true;
            for (int i = 0; i < planeCount; i++)
            {
                if (plane_id == Plane_id[i] && planeType == Plane_Type[i])
                {
                    check = false;
                }
            }
            if (check == true)
            {
                if (planeCount < planeSize)
                {
                    Plane_id[planeCount] = plane_id;
                    Plane_Type[planeCount] = planeType;
                    Plane_Capacity[planeCount] = planecapacity;
                    fuel_Capacity[planeCount] = fuelcapacity;
                    Plane_Range[planeCount] = planeRange;

                    planeCount++;
                }
            }
            return check;
        }
        static void CustomerPage()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" __________________________________________________________________________________");
            Console.WriteLine("|                                                                                  |");
            Console.WriteLine("|    _____ _   _ _____ _____ ________  ___ ___________  ______  ___  _____  _____  |");
            Console.WriteLine("|  /  __ \\ | | /  ___|_   _|  _  |  \\/  ||  ___| ___ \\ | ___ \\/ _ \\|  __ \\|  ___|  |");
            Console.WriteLine("|  | /  \\/ | | \\ `--.  | | | | | | .  . || |__ | |_/ / | |_/ / /_\\ \\ |  \\/| |__    |");
            Console.WriteLine("|  | |   | | | |`--. \\ | | | | | | |\\/| ||  __||    /  |  __/|  _  | | __ |  __|   |");
            Console.WriteLine("|  | \\__/\\ |_| /\\__/ / | | \\ \\_/ / |  | || |___| |\\ \\  | |   | | | | |_\\ \\| |___   |");
            Console.WriteLine("|   \\____/\\___/\\____/  \\_/  \\___/\\_|  |_/\\____/\\_| \\_| \\_|   \\_| |_/\\____/\\____/   |");
            Console.WriteLine("|__________________________________________________________________________________|");
            Console.WriteLine("|                                                                                  |");
            Console.WriteLine("|            Enter option 1 to view flights..                                      |"); // ok
            Console.WriteLine("|            Enter option 2 to buy ticket                                          |"); // ok
            Console.WriteLine("|            Enter option 3 to search flight..                                     |"); // ok
            Console.WriteLine("|            Enter option 4 to view your tickets                                   |"); // ok
            Console.WriteLine("|            Enter option 5 to add complains..                                     |"); // ok
            Console.WriteLine("|            Enter option 6 to cancel flight                                       |");
            Console.WriteLine("|            Enter option 7 to..Confirm Payment                                    |"); // check
            Console.WriteLine("|            Enter option 8 to view airplanes                                      |");
            Console.WriteLine("|            Enter option 9 to chang password                                      |");
            Console.WriteLine("|            Enter option 10 to logout                                             |"); // ok
            Console.WriteLine("|                                                                                  |");
            Console.WriteLine("|__________________________________________________________________________________|");
        }
        static void ViewFlights(int[] ticket_price, string[] ticket_route, int[] ticket_seat_Num, string[] ticket_time, int idx_ticket)
        {
            Console.WriteLine("   _____ _     ___ ____ _   _ _____ ____    ____  _____ _____  _    ___ _     ____    ");
            Console.WriteLine("  |  ___| |   |_ _/ ___| | | |_   _/ ___|  |  _ \\| ____|_   _|/ \\  |_ _| |   / ___|   ");
            Console.WriteLine("  | |_  | |    | | |  _| |_| | | | \\___ \\  | | | |  _|   | | / _ \\  | || |   \\___ \\   ");
            Console.WriteLine("  |  _| | |___ | | |_| |  _  | | |  ___) | | |_| | |___  | |/ ___ \\ | || |___ ___) |  ");
            Console.WriteLine("  |_|   |_____|___\\____|_| |_| |_| |____/  |____/|_____| |_/_/   \\_\\___|_____|____/   ");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("                                                                                             ");

            Console.WriteLine("{0,20}{1,20}{2,21}{3,19}{4,20}", "Flight Number", "Route", "Price", "Time", "Seat Number");
            Console.WriteLine("                                                                                                         ");
            for (int i = 0; i < idx_ticket; i++)
            {
                if (!string.IsNullOrEmpty(ticket_route[i]))
                {
                    Console.WriteLine("{0,25}{1,30}{2,25}{3,30}{4,25}", i + 1, ticket_route[i], "$" + ticket_price[i], ticket_time[i], ticket_seat_Num[i]);
                    Console.WriteLine("                                                                                                         ");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void AddComplains(string[] customer_name, string[] customer_number, string[] complain, ref int idx_complian)
        {
        again:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
       _    ____  ____                ____ ___  __  __ ____  _        _    ___ _   _ ____  
      / \  |  _ \|  _ \              / ___/ _ \|  \/  |  _ \| |      / \  |_ _| \ | / ___| 
     / _ \ | | | | | | |            | |  | | | | |\/| | |_) | |     / _ \  | ||  \| \___ \ 
    / ___ \| |_| | |_| |            | |__| |_| | |  | |  __/| |___ / ___ \ | || |\  |___) |
   /_/   \_\____/|____/              \____\___/|_|  |_|_|   |_____/_/   \_\___|_| \_|____/ 
                                                                                             ");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your contact number: ");
            string number = Console.ReadLine(); ///////////////////////////////not implemented yet///////////////////////////
            Console.Write("Enter your complain here: ");
            string complian = Console.ReadLine();

            customer_name[idx_complian] = name;
            customer_number[idx_complian] = number;
            complain[idx_complian] = complian;
            idx_complian++;

            string check_com;
            Console.WriteLine("                                         ");
            Console.WriteLine("                                         ");
        again1:
            Console.WriteLine("                                         ");
            Console.WriteLine("Enter 1 to add another complain");
            Console.WriteLine("Enter 2 to go back");
            check_com = Console.ReadLine();

            if (check_com == "1")
            {
                goto again;
            }
            else if (check_com == "2")
            {
                return;
            }
            else
            {
                Console.Clear();
                TopHeader();
                Console.WriteLine("Invalid option. .");
                goto again1;
            }
            Console.ReadKey();
        }
        static void SearchFlight(string[] ticket_route, int[] ticket_price, int[] ticket_seat_Num, string[] ticket_time, ref int idx_ticket, int size)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" 
           ____  _____    _    ____   ____ _   _             _____ _     ___ ____ _   _ _____     
          / ___|| ____|  / \  |  _ \ / ___| | | |           |  ___| |   |_ _/ ___| | | |_   _|    
          \___ \|  _|   / _ \ | |_) | |   | |_| |           | |_  | |    | | |  _| |_| | | |      
           ___) | |___ / ___ \|  _ <| |___|  _  |           |  _| | |___ | | |_| |  _  | | |      
          |____/|_____/_/   \_\_| \_\\____|_| |_|           |_|   |_____|___\____|_| |_| |_|      ");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("\tEnter the route of flight you want to search.......: ");
            string route = Console.ReadLine();
            for (int i = 0; i < size; ++i)
            {
                if (ticket_route[i] == route)
                {
                    // Display the flight information
                    Console.WriteLine();
                    Console.WriteLine("\t\tFlight Details:");
                    Console.WriteLine("\t\tRoute: " + ticket_route[i]);
                    Console.WriteLine("\t\tTime: " + ticket_time[i]);
                    Console.WriteLine("\t\tSeat Number: " + ticket_seat_Num[i]);
                    Console.WriteLine("\t\tPrice: $" + ticket_price[i]);
                }
            }
            Console.ReadKey();
        }
        static void ReservesSeat(string[] flight_names, int[] ticket_seat_Num, int idx_ticket, bool[] reserve_seat, int[] seatsused, int[] ticket_price)
        {
            Console.Write("Enter the Flight Route you want to reserve a seat for: ");
            string flightName = Console.ReadLine();

            Console.Write("Enter the seat number you want to reserve: ");
            int seatNum = int.Parse(Console.ReadLine());

            bool flightFound = false;
            bool seatAvailable = false;

            for (int i = 0; i < idx_ticket; i++)
            {
                if (flight_names[i] == flightName && ticket_seat_Num[i] > 0 && ticket_seat_Num[i] - seatNum >= 0)
                {
                    flightFound = true;
                    seatAvailable = true;
                    ticket_seat_Num[i] -= seatNum;
                    seatsused[i] = seatNum;
                    reserve_seat[i] = true;
                    total += seatNum * ticket_price[i]; // Assuming 'total' is a variable declared elsewhere
                    break;
                }
            }

            if (flightFound)
            {
                if (seatAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Seat {seatNum} on flight {flightName} reserved successfully!");
                }
                else
                {
                    Console.WriteLine($"Seat {seatNum} on flight {flightName} is not available.");
                }
            }
            else
            {
                Console.WriteLine($"Flight {flightName} not found.");
            }
        }

        static void ViewReservedFlights(string[] flight_names, int[] ticket_seat_Num, int idx_ticket, bool[] reserve_seat, int[] seatsused)
        {
            Console.WriteLine("Reserved Flights:");
            bool flightsReserved = false;

            for (int i = 0; i < idx_ticket; i++)
            {
                if (reserve_seat[i])
                {
                    Console.WriteLine($"Flight: {flight_names[i]}, Reserved Seats: {seatsused[i]}");
                    flightsReserved = true;
                }
            }

            if (!flightsReserved)
            {
                Console.WriteLine("No flights have been reserved.");
            }
        }
        static void AvailableSeats(string[] flight_names, int[] seatsused, int idx_ticket)
        {
            Console.Write("Enter the route for which you want to check: ");
            string route = Console.ReadLine();

            for (int i = 0; i < idx_ticket; i++)
            {
                if (flight_names[i] == route)
                {
                    Console.WriteLine(seatsused[i]);
                }
            }
        }
        static void ChangePassword(string[] nameArray, string[] passwordArray, int pass)
        {
            Console.WriteLine("Enter your existing password: ");
            string oldPass = Console.ReadLine();
            Console.WriteLine("Enter your new password: ");
            string newPass = Console.ReadLine();

            for (int i = 0; i < pass; i++)
            {
                if (passwordArray[i] == oldPass)
                {
                    passwordArray[i] = newPass;
                }
                else
                {
                    Console.WriteLine("Incorrect password");
                }
            }
        }
        static void ConfirmPayment(string[] flight_names, int[] ticket_seat_Num, int idx_ticket, bool[] reserve_seat, int[] seatsused, int[] ticket_price, ref int idx_ticket1)
        {
            ViewFlights(ticket_price, flight_names, ticket_seat_Num, flight_names, idx_ticket);
            Console.Write("Enter the route for which you want to confirm payment: ");
            string route = Console.ReadLine();

            for (int i = 0; i < idx_ticket; i++)
            {
                if (flight_names[i] == route)
                {
                    Console.Write("Enter the amount you want to pay: ");
                    int amount = Convert.ToInt32(Console.ReadLine());

                    if (amount == ticket_price[i])
                    {
                        Console.WriteLine("Payment confirmed");
                        ticket_seat_Num[i] -= seatsused[i];
                        reserve_seat[i] = false;
                        seatsused[i] = 0;
                        idx_ticket1++;
                    }
                    else
                    {
                        Console.WriteLine("Payment not confirmed");
                    }
                }
            }
        }
        static void CancelFlight(string[] flight_names, int[] ticket_seat_Num, int idx_ticket, bool[] reserve_seat, int[] seatsused, int[] ticket_price, ref int idx_ticket1)
        {
            ViewFlights(ticket_price, flight_names, ticket_seat_Num, flight_names, idx_ticket);
            Console.Write("Enter the route for which you want to cancel flight: ");
            string route = Console.ReadLine();

            for (int i = 0; i < idx_ticket; i++)
            {
                if (flight_names[i] == route)
                {
                    int amount;
                    amount = INTVALIDATION("Enter the amount you want to pay: ");

                    if (amount == ticket_price[i])
                    {
                        Console.WriteLine("Flight cancelled");
                        ticket_seat_Num[i] += seatsused[i];
                        reserve_seat[i] = false;
                        seatsused[i] = 0;
                        idx_ticket1--;
                    }
                    else
                    {
                        Console.WriteLine("Flight not cancelled");
                    }
                }
            }
        }
        static string IsNum(string input) // age validation
        {
            int x;
            int size;
            int check;
            bool flap;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    if (input[i] != ' ')
                    {
                        check = (int)input[i];
                        if ((check >= 48 && check <= 57))
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    x = int.Parse(input);
                    if (x >= 18 && x <= 60)
                    {
                        return input;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Age...");
                        Console.Write("Enter age: ");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Age...");
                    Console.Write("Enter age: ");
                    input = Console.ReadLine();
                }
            }
            return "0";
        }
        static string IsAlpha(string input) // name and city validation
        {
            Console.Clear();
            Console.WriteLine("Enter input: ");
            input = Console.ReadLine();
            int size;
            int check;
            bool flap;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    check = (int)input[i];
                    if ((check >= 65 && check <= 90) || (check >= 97 && check <= 122) || input[i] == ' ')
                    {
                        flap = true;
                    }
                    else
                    {
                        flap = false;
                        break;
                    }
                }
                if (flap == true)
                {
                    return input;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input...");
                    Console.WriteLine("Enter Again: ");
                    input = Console.ReadLine();
                }
            }
        }
        static string PasswordLength(string anypass)
        {
            Console.WriteLine("Enter password: ");
            anypass = Console.ReadLine();
            int size;
            while (true)
            {
                size = anypass.Length;
                if (size <= 8 && size >= 4)
                {
                    return anypass;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password must be between 4 and 8 characters long");
                    Console.WriteLine("Enter password again: ");
                    anypass = Console.ReadLine();
                }
            }
        }
        static string IsNum1(string input)
        {
            Console.WriteLine("Enter price: ");
            input = Console.ReadLine();
            int x;
            int size;
            int check;
            bool flap;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    if (input[i] != ' ')
                    {
                        check = (int)input[i];
                        if (check >= 48 && check <= 57)
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    x = int.Parse(input);
                    if (x >= 1 && x <= 5000000)
                    {
                        return input;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input...");
                        Console.WriteLine("Enter price: ");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input...");
                    Console.WriteLine("Enter price: ");
                    input = Console.ReadLine();
                }
            }
            return "0";
        }
        static string TimeValidation(string input)
        {
            while (true)
            {
                input = Console.ReadLine();
                bool am_pm_found = false;
                int i = input.Length;
                if ((input[i - 2] == 'A' || input[i - 2] == 'a' || input[i - 2] == 'P' || input[i - 2] == 'p') && (input[i - 1] == 'M' || input[i - 1] == 'm'))
                {
                    am_pm_found = true;
                }
                if (am_pm_found)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Wrong input...");
                    Console.WriteLine("Enter Again: ");
                }
            }
        }
        static string CheckNumber(string input)
        {
            input = Console.ReadLine();
            int size;
            int check;
            bool flap;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    if (input[i] != ' ')
                    {
                        check = Convert.ToInt32(input[i]);
                        if (check >= 48 && check <= 57)
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Wrong info...");
                    Console.WriteLine("Enter Again (only numbers): ");
                    input = Console.ReadLine();
                }
            }
        }
        static string PasswordLength1(string anypass)
        {
            anypass = Console.ReadLine();
            int size;
            while (true)
            {
                size = anypass.Length;
                if (size <= 8 && size >= 4 && !anypass.Contains(","))
                {
                    return anypass;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password must not be greater than 8 characters long and should not contain a comma");
                    Console.WriteLine("Enter password again: ");
                    anypass = Console.ReadLine();
                }
            }
            return "";
        }
        static bool CheckComma(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    return true;
                }
            }
            return false;
        }
        static void StoreLogin(string[] nameArray, string[] passwordArray, string[] roleArray, int indexCount)
        {
            using (StreamWriter file = new StreamWriter("login.txt"))
            {
                for (int i = 0; i < indexCount; i++)
                {
                    if (i == indexCount - 1)
                        file.Write($"{nameArray[i]},{passwordArray[i]},{roleArray[i]}");
                    else
                        file.WriteLine($"{nameArray[i]},{passwordArray[i]},{roleArray[i]}");
                }
            }
        }
        static void StoreFlight(string[] ticket_route, int[] ticket_price, int[] ticket_seat_Num, string[] ticket_time, int idx_ticket)
        {
            using (StreamWriter file = new StreamWriter("flight.txt"))
            {
                for (int i = 0; i < idx_ticket; i++)
                {
                    if (i == idx_ticket - 1)
                        file.Write($"{ticket_route[i]},{ticket_price[i]},{ticket_time[i]},{ticket_seat_Num[i]}");
                    else
                        file.WriteLine($"{ticket_route[i]},{ticket_price[i]},{ticket_time[i]},{ticket_seat_Num[i]}");
                }
            }
        }
        static void StoreEmployee(string[] employee_name, string[] employee_age, string[] employee_num, string[] employee_salary, ref int idx_employee)
        {
            using (StreamWriter file = new StreamWriter("employee.txt"))
            {
                for (int i = 0; i < idx_employee; i++)
                {
                    if (i == idx_employee - 1)
                        file.Write($"{employee_name[i]},{employee_age[i]},{employee_num[i]},{employee_salary[i]}");
                    else
                        file.WriteLine($"{employee_name[i]},{employee_age[i]},{employee_num[i]},{employee_salary[i]}");
                }
            }
        }
        static void StorePlanes(string[] Plane_id, string[] Plane_Type, string[] Plane_Capacity, string[] fuel_Capacity, string[] Plane_Range, ref int planeCount)
        {
            using (StreamWriter file = new StreamWriter("planes.txt"))
            {
                for (int i = 0; i < planeCount; i++)
                {
                    if (i == planeCount - 1)
                        file.Write($"{Plane_id[i]},{Plane_Type[i]},{Plane_Capacity[i]},{fuel_Capacity[i]},{Plane_Range[i]}");
                    else
                        file.WriteLine($"{Plane_id[i]},{Plane_Type[i]},{Plane_Capacity[i]},{fuel_Capacity[i]},{Plane_Range[i]}");
                }
            }
        }
        static void StoreCustomerComplain(string[] customer_name, string[] customer_number, string[] complain, ref int idx_complian)
        {
            using (StreamWriter file = new StreamWriter("complain.txt"))
            {
                for (int i = 0; i < idx_complian; i++)
                {
                    if (i == idx_complian - 1)
                        file.Write($"{customer_name[i]},{customer_number[i]},{complain[i]}");
                    else
                        file.WriteLine($"{customer_name[i]},{customer_number[i]},{complain[i]}");
                }
            }
        }
        static void StorePrice(string[] price, int idx_price)
        {
            using (StreamWriter file = new StreamWriter("price.txt"))
            {
                for (int i = 0; i < idx_price; i++)
                {
                    if (i == idx_price - 1)
                        file.Write(price[i]);
                    else
                        file.WriteLine(price[i]);
                }
            }
        }
        static void LoadLogin(string[] nameArray, string[] passwordArray, string[] roleArray, ref int indexCount)
        {
            using (StreamReader file = new StreamReader("login.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    nameArray[indexCount] = GetData(data, 0);
                    passwordArray[indexCount] = GetData(data, 1);
                    roleArray[indexCount] = GetData(data, 2);
                    indexCount++;
                }
            }
        }
        static void LoadFlight(string[] ticket_route, int[] ticket_price, int[] ticket_seat_Num, string[] ticket_time, ref int idx_ticket)
        {
            using (StreamReader file = new StreamReader("flight.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    ticket_route[idx_ticket] = GetData(data, 0);
                    ticket_price[idx_ticket] = int.Parse(GetData(data, 1));
                    ticket_seat_Num[idx_ticket] = int.Parse(GetData(data, 2));
                    ticket_time[idx_ticket] = GetData(data, 3);
                    idx_ticket++;
                }
            }
        }
        static void LoadEmployee(string[] employee_name, string[] employee_age, string[] employee_num, string[] employee_salary, ref int idx_employee)
        {
            using (StreamReader file = new StreamReader("employee.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    employee_name[idx_employee] = GetData(data, 0);
                    employee_age[idx_employee] = GetData(data, 1);
                    employee_num[idx_employee] = GetData(data, 2);

                    idx_employee++;
                }
            }
        }
        static void LoadPlanes(string[] Plane_id, string[] Plane_Type, string[] Plane_Capacity, string[] fuel_Capacity, string[] Plane_Range, ref int planeCount)
        {
            using (StreamReader file = new StreamReader("planes.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    Plane_id[planeCount] = GetData(data, 0);
                    Plane_Type[planeCount] = GetData(data, 1);
                    Plane_Capacity[planeCount] = GetData(data, 2);
                    fuel_Capacity[planeCount] = GetData(data, 3);
                    Plane_Range[planeCount] = GetData(data, 4);
                    planeCount++;
                }
            }
        }
        static void LoadCustomerComplain(string[] customer_name, string[] customer_number, string[] complain, ref int idx_complian)
        {
            using (StreamReader file = new StreamReader("complain.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    customer_name[idx_complian] = GetData(data, 0);
                    customer_number[idx_complian] = GetData(data, 1);
                    complain[idx_complian] = GetData(data, 2);
                    idx_complian++;
                }
            }
        }
        static void LoadPrice(string[] price, int idx_price)
        {
            using (StreamReader file = new StreamReader("price.txt"))
            {
                string data = "";
                while ((data = file.ReadLine()) != null)
                {
                    price[idx_price] = GetData(data, 0);
                    idx_price++;
                }
            }
        }

    }


    }

