using System;

namespace mis_221_pa_5_acboliver
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Start Main
            System.Console.WriteLine("Welcome to the TLAC! Where the dumbells are secretly 2x the weight at our studio (Dont tell OSHA please they said one more strike and we are done :(  ).");
            System.Console.WriteLine("··········00000000000000K··································000000000000KK·······");
            System.Console.WriteLine("········000000000000000000c······························00000000000000000k·····");
            System.Console.WriteLine("······0000000000000000K00000c··························000000000000000000000K···");
            System.Console.WriteLine("····/0KK00K00KK0K00000KKKK00K·························0000KKK00000000000K0000Kc·");
            System.Console.WriteLine("···)KKKK00000KO00KK000KKKKKK0·························0KKKKKK00000KK0000KK0KKKKk"); 
            System.Console.WriteLine("···)KKKK000KKKKKK0K000KKKKKK0·························00KKKKK0000k0K00K0000KKK0K");
            System.Console.WriteLine("···0KKKK000K0KK000K000KKKKKKK0K00000000000000KK00000000KKKKKK00000000000000KKKKK");
            System.Console.WriteLine("···0KKKK000k0KK0K0K000KKKKKKk0K0K00k00k0k000000K0KKK0KKKKKKKK000KK|0K|0000KKKKKK");
            System.Console.WriteLine("···0KKKK000000K0KKK0K0KKKKKK00K0K00000000000000000000K0KKKKKK000K000k000000KKKKK");
            System.Console.WriteLine("···00KKK0000000000K00KKKKKKK0·························0KKKKKK000K00000000000KK0K");
            System.Console.WriteLine("···0000K0KKKK0K00KK0KKKKKKKK0·························00KKKKK000000000000000000K");
            System.Console.WriteLine("····0000KKKKKKKKKKKKKKKK0K00K·························00KKKKKKKKKKKKKKKKKKKKKK0O");
            System.Console.WriteLine("····^0000KKKKKKKKKKKKKKK0K00K·························)00KKKKKKKKKKKKKKKKKK000K·");
            System.Console.WriteLine("······0000KKKKKKKKKKKKK00KK^···························*000KKKKKKKKKKKKKKK000K··");
            System.Console.WriteLine("·······^00K0KKKKKKKKKKKKK^·······························*000KKKKKKKKKKKKK0K····");
            System.Console.WriteLine("·········^KKK0000000000^···································*0000000000000K······");
            System.Console.WriteLine("················································································");
            System.Console.WriteLine("················································································");
            PauseAction();
            Trainer[] myTrainers = new Trainer[100];
            CreateTrainer(myTrainers);
            Listing[] myListings = new Listing[100];
            CreateListing(myListings);
            Booking[] myBookings = new Booking[100];
            CreateBooking(myBookings);
            string userInput = GetMenuChoice();
            while (userInput != "5")
            {
                Route(userInput, myTrainers, myListings, myBookings);
                userInput = GetMenuChoice();
            }
            // End main
            // Start Menu
            // Gets user's choice for menu 
            static string GetMenuChoice()
            {
                DisplayMenu();
                string userInput = Console.ReadLine();
                while (!ValidMenuChoice(userInput))
                {
                    Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    DisplayMenu();
                    userInput = Console.ReadLine();
                }
                return userInput;
            }
            // Displays menu
            static void DisplayMenu()
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to Manage Trainers\nEnter 2 to Manage Listings\nEnter 3 to Manage Bookings\nEnter 4 to Run Reports\nEnter 5 to Exit");
            }
            // Ensures userInput is a valid menu choice
            static bool ValidMenuChoice(string userInput)
            {
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5")
                {
                    return true;
                }
                else return false;
            }
            // Route user to desired menu function 
            static void Route(string userInput, Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings)
            {
                if (userInput == "1")
                {
                    ManageTrainers(myTrainers);
                }
                else if (userInput == "2")
                {
                    ManageListings(myListings);
                }
                else if (userInput == "3")
                {
                    Bookings(myTrainers, myListings, myBookings);
                }
                else if (userInput == "4")
                {
                    Reports(myBookings, myListings);
                }
            }
            static void PauseAction()
            {
                System.Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
            }
            // End Menu
            // Start Trainer
            // Gets user's choice for add/edit/delete menu
            static string GetUserChoice(string title)
            {
                Console.Clear();
                System.Console.WriteLine($"Enter 1 to add a new {title}\nEnter 2 to edit an existing {title}\nEnter 3 to delete an existing {title}\nEnter 4 to exit back to the menu");
                string userChoice = Console.ReadLine();
                return userChoice;
            }
            // Populates trainer array and routes user to add/edit/delete menu
            static void ManageTrainers(Trainer[] myTrainers)
            {
                string title = "trainer";
                string userChoice = GetUserChoice(title);
                while (userChoice != "4")
                {
                    RouteTrainer(myTrainers, userChoice);
                    userChoice = GetUserChoice(title);
                }
            }
            // Routes user to either AddTrainer, EditTrainer, or DeleteTrainer
            static void RouteTrainer(Trainer[] myTrainers, string userChoice)
            {
                if (userChoice == "1")
                {
                    AddTrainer(myTrainers);
                }
                else if (userChoice == "2")
                {
                    EditTrainer(myTrainers);
                }
                else if (userChoice == "3")
                {
                    DeleteTrainer(myTrainers);
                }
            }
            // Populates Trainer array from trainers.txt
            static void CreateTrainer(Trainer[] myTrainers)
            {
                StreamReader inFile = new StreamReader("trainers.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while (line != null)
                {
                    string[] temp = new string[1000];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    Trainer newTrainer = new Trainer(x, temp[1], temp[2], temp[3]);
                    myTrainers[count] = newTrainer;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            // Adds new trainer array and writes it to trainers.txt
            static void AddTrainer(Trainer[] myTrainers)
            {
                Console.Clear();
                System.Console.WriteLine("Would you like to add a new trainer? 1 for yes, any other key for no");
                string userChoice = Console.ReadLine();
                int length = 0;
                while (myTrainers[length] != null)
                {
                    length++;
                }
                int max = myTrainers[length - 1].GetTrainerID();
                for (int i = 0; i < length; i++)
                {
                    int currID = myTrainers[i].GetTrainerID();
                    if (currID > max)
                    {
                        max = currID;
                    }
                }
                if (userChoice == "1")
                {
                    Console.Clear();
                    string[] temp = new string[100];
                    System.Console.WriteLine("Please Enter Their Name");
                    temp[0] = Console.ReadLine();
                    System.Console.WriteLine("Please Enter Their Mailing Address");
                    temp[1] = Console.ReadLine();
                    System.Console.WriteLine("Please Enter Their Email");
                    temp[2] = Console.ReadLine();
                    Trainer newTrainer = new Trainer(max + 1, temp[0], temp[1], temp[2]);
                    myTrainers[length] = newTrainer;
                    PrintAllTrainers(myTrainers);
                    System.Console.WriteLine("Your trainer has been added!");
                    PauseAction();
                    string title = "add another trainer";
                    if (AskAgain(title))
                    {
                        AddTrainer(myTrainers);
                    }
                }
            }
            static bool AskAgain(string title)
            {
                Console.Clear();
                System.Console.WriteLine($"Would you like to {title}?\nEnter 1 for yes or press another key for no");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    return true;
                }
                else return false;
            }
            // Writes new trainers to trainers.txt
            static void PrintAllTrainers(Trainer[] myTrainers)
            {
                StreamWriter inFile = new StreamWriter("trainers.txt");
                int length = GetTrainerLength(myTrainers);
                for (int i = 0; i < length; i++)
                {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    inFile.WriteLine($"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}");
                }
                inFile.Close();
            }
            // Prompts user to edit a trainer 
            static void EditTrainer(Trainer[] myTrainers)
            {
                Console.Clear();
                int length = 0;
                while (myTrainers[length] != null)
                {
                    length++;
                }
                System.Console.WriteLine("Would you like to edit a trainer? Enter 1 for yes or press any other key for no");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    ViewTrainers(myTrainers);
                    System.Console.WriteLine("Please enter the Trainer ID of the trainer you would like to edit");
                    int trainerID = int.Parse(Console.ReadLine());
                    for (int i = 0; i < length; i++)
                    {
                        int id = myTrainers[i].GetTrainerID();
                        if (id == trainerID)
                        {
                            Edit(myTrainers, i);
                        }
                    }
                }
                PrintAllTrainers(myTrainers);
            }
            // Edits selected trainer attribute in trainer array
            static void Edit(Trainer[] myTrainers, int x)
            {
                ViewTrainer(myTrainers, x);
                System.Console.WriteLine("What would you like to edit?\nEnter 1 for Trainer Name\nEnter 2 for Mailing Address\nEnter or 3 for Email");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    string currName = myTrainers[x].GetTrainerName();
                    System.Console.WriteLine($"The current name is {currName}\nwhat would you like to set the name to?");
                    myTrainers[x].SetTrainerName(Console.ReadLine());
                }
                else if (userChoice == "2")
                {
                    string currAddress = myTrainers[x].GetMailingAddress();
                    System.Console.WriteLine($"The current mailing address is {currAddress}\nWhat would you like the address to be set to?");
                    myTrainers[x].SetMailingAddress(Console.ReadLine());
                }
                else if (userChoice == "3")
                {
                    string currEmail = myTrainers[x].GetTrainerEmail();
                    System.Console.WriteLine($"The current email is {currEmail}\nWhat would you like to change their email to?");
                    myTrainers[x].SetTrainerEmail(Console.ReadLine());
                }
                ViewTrainer(myTrainers, x);
                System.Console.WriteLine("The trainer has been edited");
                PauseAction();
            }
            // Prompts user to delete a trainer
            static void DeleteTrainer(Trainer[] myTrainers)
            {
                Console.Clear();
                int length = 0;
                while (myTrainers[length] != null)
                {
                    length++;
                }
                System.Console.WriteLine("Would you like to Delete a Trainer today? Enter 1 for Yes or press any other key for No");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    ViewTrainers(myTrainers);
                    System.Console.WriteLine("Please enter the trainer ID of the trainer you would like to delete");
                    int searchID = int.Parse(Console.ReadLine());
                    for (int i = 0; i < length; i++)
                    {
                        int currID = myTrainers[i].GetTrainerID();
                        if (currID == searchID)
                        {
                            Delete(myTrainers, i);
                            System.Console.WriteLine("Your trainer has been deleted");
                            PauseAction();
                        }
                    }
                }
            }
            // Deletes selected trainer from trainers.txt
            static void Delete(Trainer[] myTrainers, int x)
            {
                StreamWriter inFile = new StreamWriter("trainers.txt");
                int length = 0;
                while (myTrainers[length] != null)
                {
                    length++;
                }
                for (int i = 0; i < length; i++)
                {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    if (myTrainers[i] != myTrainers[x])
                    {
                        inFile.WriteLine($"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}");
                    }
                }
                inFile.Close();
            }
            // Displays all current trainers to user
            static void ViewTrainers(Trainer[] myTrainers)
            {
                int length = GetTrainerLength(myTrainers);
                Console.Clear();
                System.Console.WriteLine("These are the current trainers: ");
                for (int i = 0; i < length; i++)
                {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    Console.WriteLine($"ID: {trainerID}\tName: {trainerName}\nAddress: {mailingAddress}\tEmail: {trainerEmail}");
                }
            }
            // Displays selected trainer to user
            static void ViewTrainer(Trainer[] myTrainers, int x)
            {
                int length = GetTrainerLength(myTrainers);
                Console.Clear();
                System.Console.WriteLine("This is the current trainer: ");
                int trainerID = myTrainers[x].GetTrainerID();
                string trainerName = myTrainers[x].GetTrainerName();
                string mailingAddress = myTrainers[x].GetMailingAddress();
                string trainerEmail = myTrainers[x].GetTrainerEmail();
                Console.WriteLine($"ID: {trainerID}\tName: {trainerName}\nAddress: {mailingAddress}\tEmail: {trainerEmail}");
            }
            // Gets length of partially filled Trainer array
            static int GetTrainerLength(Trainer[] myTrainers)
            {
                int length = 0;
                while (myTrainers[length] != null)
                {
                    length++;
                }
                return length;
            }
            // End Trainer
            // Start Listing
            // Populates listing array and routes user to GetUserChoice
            static void ManageListings(Listing[] myListings)
            {
                string title = "listing";
                string userChoice = GetUserChoice(title);
                while (userChoice != "4")
                {
                    RouteListing(myListings, userChoice);
                    userChoice = GetUserChoice(title);
                }
            }
            // Routes user to add/edit/delete listing
            static void RouteListing(Listing[] myListings, string userChoice)
            {
                if (userChoice == "1")
                {
                    AddListing(myListings);
                }
                else if (userChoice == "2")
                {
                    EditListing(myListings);
                }
                else if (userChoice == "3")
                {
                    DeleteListing(myListings);
                }
            }
            // Populates Listing array from listings.txt
            static void CreateListing(Listing[] myListings)
            {
                StreamReader inFile = new StreamReader("listings.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while (line != null)
                {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    double.TryParse(temp[4], out double y);
                    int.TryParse(temp[5], out int z);
                    Listing newListing = new Listing(x, temp[1], temp[2], temp[3], y, z);
                    myListings[count] = newListing;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            // Adds a new listing to the listing array
            static void AddListing(Listing[] myListings)
            {
                Console.Clear();
                System.Console.WriteLine("Would you like to add a new listing? Enter 1 for yes or press any other key for no");
                string userChoice = Console.ReadLine();
                int length = GetLength(myListings);
                if (userChoice == "1")
                {
                    Console.Clear();
                    string[] temp = new string[100];
                    System.Console.WriteLine("Please enter the name of the trainer running the session");
                    temp[0] = Console.ReadLine();
                    System.Console.WriteLine("Please enter the date of the session ex: 10/15/2024");
                    temp[1] = Console.ReadLine();
                    System.Console.WriteLine("Please enter the time of the session ex: 10:30AM");
                    temp[2] = Console.ReadLine();
                    System.Console.WriteLine("Will this session have a different cost than the normal rate of $50?\nPress 1 for yes or press any other key to set the cost to $50");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        System.Console.WriteLine("Please enter the cost of the session");
                        temp[3] = Console.ReadLine();
                    }
                    else temp[3] = "50";
                    System.Console.WriteLine("Please set the availability of the session");
                    temp[4] = Console.ReadLine();
                    double.TryParse(temp[3], out double cost);
                    int.TryParse(temp[4], out int availability);
                    Listing newListing = new Listing(length + 1, temp[0], temp[1], temp[2], cost, availability);
                    myListings[length] = newListing;
                    PrintAllListings(myListings);
                    System.Console.WriteLine("Your listing has been added");
                    PauseAction();
                    string title = "add another listing";
                    if (AskAgain(title))
                    {
                        AddListing(myListings);
                    }
                }
            }
            // Prints all listings to listings.txt
            static void PrintAllListings(Listing[] myListings)
            {
                StreamWriter inFile = new StreamWriter("listings.txt");
                int length = GetLength(myListings);
                SortListingByDate(myListings);
                for (int i = 0; i < length; i++)
                {
                    string trainerName = myListings[i].GetTrainerName();
                    string listingDate = myListings[i].GetSessionDate();
                    string listingTime = myListings[i].GetSessionTime();
                    double listingCost = myListings[i].GetSessionCost();
                    int listingAvailability = myListings[i].GetSessionAvailability();
                    inFile.WriteLine($"{i + 1}#{trainerName}#{listingDate}#{listingTime}#{listingCost}#{listingAvailability}");
                }
                inFile.Close();
            }
            // Prompts user to edit a listing
            static void EditListing(Listing[] myListings)
            {
                Console.Clear();
                int length = GetLength(myListings);
                System.Console.WriteLine("Would you like edit a listing? Enter 1 for yes or press any other key for no");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    ViewListings(myListings);
                    System.Console.WriteLine("Enter the session ID of the listing you would like to edit");
                    int searchID = int.Parse(Console.ReadLine());
                    EditChoice(myListings, searchID);
                    System.Console.WriteLine("Your listing has been edited");
                    PauseAction();
                }
                PrintAllListings(myListings);
            }
            // Displays all available listings to user
            static void ViewListings(Listing[] myListings)
            {
                int length = GetLength(myListings);
                Console.Clear();
                System.Console.WriteLine("These are the current listings available: ");
                for (int i = 0; i < length; i++)
                {
                    int sessionID = myListings[i].GetListingID();
                    string trainerName = myListings[i].GetTrainerName();
                    string sessionDate = myListings[i].GetSessionDate();
                    string sessionTime = myListings[i].GetSessionTime();
                    double sessionCost = myListings[i].GetSessionCost();
                    int sessionAvailability = myListings[i].GetSessionAvailability();
                    System.Console.WriteLine($"ID: {sessionID}\tTrainer: {trainerName}\nDate: {sessionDate}\t Time: {sessionTime}\nCost: {sessionCost}\tAvailable Slots: {sessionAvailability}");
                }
            }
            // Displays selected listing to user
            static void ViewListing(Listing[] myListings, int searchVal)
            {
                searchVal--;
                Console.Clear();
                System.Console.WriteLine("This is the current listing: ");
                int sessionID = myListings[searchVal].GetListingID();
                string trainerName = myListings[searchVal].GetTrainerName();
                string sessionDate = myListings[searchVal].GetSessionDate();
                string sessionTime = myListings[searchVal].GetSessionTime();
                double sessionCost = myListings[searchVal].GetSessionCost();
                int sessionAvailability = myListings[searchVal].GetSessionAvailability();
                System.Console.WriteLine($"ID: {sessionID}\tTrainer: {trainerName}\nDate: {sessionDate}\t Time: {sessionTime}\nCost: {sessionCost}\tAvailable Slots: {sessionAvailability}");
            }
            // Prompts user for which attribute to edit and makes change
            static void EditChoice(Listing[] myListings, int x)
            {
                ViewListing(myListings, x);
                System.Console.WriteLine("What would you like to edit?\nEnter 1 for Trainer Name\nEnter 2 for Listing Date\nEnter 3 for Listing Time\nEnter 4 for Listing Cost\nEnter 5 for Listing Availability");
                string userChoice = Console.ReadLine();
                x--;
                Console.Clear();
                if (userChoice == "1")
                {
                    string currName = myListings[x].GetTrainerName();
                    System.Console.WriteLine($"The current name is {currName}\nWhat would you like to set the name to?");
                    myListings[x].SetTrainerName(Console.ReadLine());
                }
                else if (userChoice == "2")
                {
                    string currDate = myListings[x].GetSessionDate();
                    System.Console.WriteLine($"The current session date is {currDate}\nWhat would you like the date to be set to?");
                    myListings[x].SetSessionDate(Console.ReadLine());
                }
                else if (userChoice == "3")
                {
                    string currTime = myListings[x].GetSessionTime();
                    System.Console.WriteLine($"The current session time is {currTime}\nWhat would you like to change the time to?");
                    myListings[x].SetSessionTime(Console.ReadLine());
                }
                else if (userChoice == "4")
                {
                    double currCost = myListings[x].GetSessionCost();
                    System.Console.WriteLine($"The current cost is set to {currCost}\nWhat would you like to set the cost to?");
                    myListings[x].SetSessionCost(double.Parse(Console.ReadLine()));
                }
                else if (userChoice == "5")
                {
                    int currAvail = myListings[x].GetSessionAvailability();
                    System.Console.WriteLine($"The current session availability is {currAvail}\nWhat would you like to set the availability to?");
                    myListings[x].SetSessionAvailability(int.Parse(Console.ReadLine()));
                }
            }
            // Prompts user to delete a listing
            static void DeleteListing(Listing[] myListings)
            {
                Console.Clear();
                System.Console.WriteLine("Would you like to delete a listing today? Enter 1 for Yes or press any other key for No");
                string userChoice = Console.ReadLine();
                int length = GetLength(myListings);
                if (userChoice == "1")
                {
                    Console.Clear();
                    System.Console.WriteLine("These are the current listings available: ");
                    ViewListings(myListings);
                    System.Console.WriteLine("Enter the session ID of the listing you would like to delete");
                    int searchID = int.Parse(Console.ReadLine());
                    for (int i = 0; i < length; i++)
                    {
                        int currID = myListings[i].GetListingID();
                        if (currID == searchID)
                        {
                            DeleteChoice(myListings, i);
                            System.Console.WriteLine("The listing has been deleted");
                            PauseAction();
                        }
                    }
                }
            }
            // Deletes selected listing from listings.txt
            static void DeleteChoice(Listing[] myListings, int x)
            {
                StreamWriter inFile = new StreamWriter("listings.txt");
                int length = GetLength(myListings);
                for (int i = 0; i < length; i++)
                {
                    int listingID = myListings[i].GetListingID();
                    string trainerName = myListings[i].GetTrainerName();
                    string sessionDate = myListings[i].GetSessionDate();
                    string sessionTime = myListings[i].GetSessionTime();
                    double sessionCost = myListings[i].GetSessionCost();
                    int sessionAvailability = myListings[i].GetSessionAvailability();
                    if (myListings[i] != myListings[x])
                    {
                        inFile.WriteLine($"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#${sessionCost}#{sessionAvailability}");
                    }
                }
                inFile.Close();
            }
            // Gets length of partially filled Listing array
            static int GetLength(Listing[] myListings)
            {
                int length = 0;
                while (myListings[length] != null)
                {
                    length++;
                }
                return length;
            }
            static void SwapListings(Listing[] myListings, int x, int y)
            {
                Listing temp = new Listing();
                temp = myListings[x];
                myListings[x] = myListings[y];
                myListings[y] = temp;
            }
            // End Listing
            // Start Booking
            // Populates Trainer, Listing, and Booking array and routes user to chosen Booking function
            static void Bookings(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the booking tab!\nEnter 1 to book a session\nEnter 2 to update a session's status\nEnter any other key to exit the menu");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    BookSession(myTrainers, myListings, myBookings);
                }
                else if (userChoice == "2")
                {
                    UpdateStatus(myBookings);
                }
            }
            // Populates Booking array from transactions.txt
            static void CreateBooking(Booking[] myBookings)
            {
                StreamReader inFile = new StreamReader("transactions.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while (line != null)
                {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    int.TryParse(temp[4], out int y);
                    Booking newBooking = new Booking(x, temp[1], temp[2], temp[3], y, temp[5], temp[6]);
                    myBookings[count] = newBooking;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            // Books a new session for customer
            static void BookSession(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings)
            {
                ViewListings(myListings);
                System.Console.WriteLine("Enter the session ID of the session you would like to book");
                int sessionID = int.Parse(Console.ReadLine());
                ViewListing(myListings, sessionID);
                int length = GetTrainerLength(myTrainers);
                string[] temp = new string[100];
                System.Console.WriteLine("Please enter your name");
                temp[0] = Console.ReadLine();
                System.Console.WriteLine("Please enter your email");
                temp[1] = Console.ReadLine();
                temp[2] = myListings[sessionID - 1].GetSessionDate();
                temp[3] = myListings[sessionID - 1].GetTrainerName();
                int trainerID = 0;
                for (int i = 0; i < length; i++)
                {
                    string trainerName = myTrainers[i].GetTrainerName();
                    if (trainerName == temp[3])
                    {
                        trainerID = i + 1;
                    }
                }
                int bookingLength = GetBookingLength(myBookings);
                Booking newBooking = new Booking(sessionID, temp[0], temp[1], temp[2], trainerID, temp[3], "Booked");
                myBookings[bookingLength] = newBooking;
                int currentAvailability = myListings[sessionID - 1].GetSessionAvailability();
                myListings[sessionID - 1].SetSessionAvailability(currentAvailability - 1);
                PrintAllListings(myListings);
                System.Console.WriteLine("You've successfully booked a session");
                PauseAction();
                PrintAllBookings(myBookings);
            }
            // Prints all bookings to transactions.txt
            static void PrintAllBookings(Booking[] myBookings)
            {
                StreamWriter inFile = new StreamWriter("transactions.txt");
                int length = GetBookingLength(myBookings);
                string[] year = new string[100];
                string[] month = new string[100];
                CreateDates(myBookings, month, year);
                SortByDate(myBookings);
                for (int i = 0; i < length; i++)
                {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string bookingStatus = myBookings[i].GetSessionStatus();
                    inFile.WriteLine($"{sessionID}#{customerName}#{customerEmail}#{sessionDate}#{trainerID}#{trainerName}#{bookingStatus}");
                }
                inFile.Close();
            }
            // Gets length of partially filled Booking array
            static int GetBookingLength(Booking[] myBookings)
            {
                int length = 0;
                while (myBookings[length] != null)
                {
                    length++;
                }
                return length;
            }
            // Updates status of selected booking in Booking array
            static void UpdateStatus(Booking[] myBookings)
            {
                ViewBookings(myBookings);
                System.Console.WriteLine("Please enter the booking ID of the booking you would like to update");
                int bookingID = int.Parse(Console.ReadLine());
                ViewBooking(myBookings, bookingID);
                System.Console.WriteLine("Please select your update reason\nEnter 1 to update the session to completed\nEnter 2 to update the session to canceled\nEnter any other key to keep the session the same");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    myBookings[bookingID - 1].SetSessionStatus("Completed");
                }
                else if (userChoice == "2")
                {
                    myBookings[bookingID - 1].SetSessionStatus("Canceled");
                }
                PrintAllBookings(myBookings);
                System.Console.WriteLine("The status has been updated");
                PauseAction();
            }
            // Displays all current bookings to user
            static void ViewBookings(Booking[] myBookings)
            {
                Console.Clear();
                System.Console.WriteLine("These are the current bookings on file: ");
                int length = GetBookingLength(myBookings);
                for (int i = 0; i < length; i++)
                {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    System.Console.WriteLine($"\tBooking ID: {i + 1}\nSession ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\n\tSession Status: {sessionStatus}");
                    System.Console.WriteLine("");
                }
            }
            // Displays selected booking to user
            static void ViewBooking(Booking[] myBookings, int x)
            {
                x--;
                Console.Clear();
                System.Console.WriteLine("Here is the booking you've selected: ");
                int sessionID = myBookings[x].GetSessionID();
                string customerName = myBookings[x].GetCustomerName();
                string customerEmail = myBookings[x].GetCustomerEmail();
                string sessionDate = myBookings[x].GetTrainingDate();
                int trainerID = myBookings[x].GetTrainerID();
                string trainerName = myBookings[x].GetTrainerName();
                string sessionStatus = myBookings[x].GetSessionStatus();
                System.Console.WriteLine($"\tBooking ID: {x + 1}\nSession ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\n\tSession Status: {sessionStatus}");
                System.Console.WriteLine("");
            }
            // Swaps booking array
            static void SwapBookings(Booking[] myBookings, int x, int y)
            {
                Booking temp = new Booking();
                temp = myBookings[x];
                myBookings[x] = myBookings[y];
                myBookings[y] = temp;

            }
            static void SortByCustomer(Booking[] myBookings)
            {
                int length = GetBookingLength(myBookings);
                for (int maxElement = length - 1; maxElement > 0; maxElement--)
                {
                    for (int index = 0; index < maxElement; index++)
                    {
                        string currName = myBookings[index].GetCustomerName();
                        string compName = myBookings[index + 1].GetCustomerName();
                        if (string.Compare(currName, compName) > 0)
                        {
                            SwapBookings(myBookings, index, index + 1);
                        }
                    }
                }
            }
            // End Booking
            // Start reporting
            // Prompts user for menu choice and routes user to chosen function
            static void Reports(Booking[] myBookings, Listing[] myListings)
            {
                Console.Clear();
                System.Console.WriteLine("Please select the report you would like to receive\nEnter 1 to view a report of individual customer sessions\nEnter 2 to view a report of historical customer sessions\nEnter 3 to view a report of historical revenue information\nEnter any other key to return to the menu");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    IndividualHistory(myBookings);
                }
                else if (userChoice == "2")
                {
                    HistoricalCustomer(myBookings);
                }
                else if (userChoice == "3")
                {
                    HistoricalRevenue(myBookings, myListings);
                }
            }
            // Displays customer history based off of customer email
            static void IndividualHistory(Booking[] myBookings)
            {
                Console.Clear();
                System.Console.WriteLine("Please enter the email of the customer you would like to view session history for");
                SortByDate(myBookings);
                string searchEmail = Console.ReadLine();
                int length = GetBookingLength(myBookings);
                Console.Clear();
                for (int i = 0; i < length; i++)
                {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    if (searchEmail == customerEmail)
                    {
                        System.Console.WriteLine($"Session ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\nSession Status: {sessionStatus}");
                        System.Console.WriteLine("");
                    }
                }
                PauseAction();
            }
            static void HistoricalCustomer(Booking[] myBookings)
            {
                Console.Clear();
                System.Console.WriteLine("The historical customer summary: ");
                SortByCustomer(myBookings);
                SortAfter(myBookings);
                ViewBookings(myBookings);
                SessionsByCustomer(myBookings);
                PauseAction();
            }
            static void HistoricalRevenue(Booking[] myBookings, Listing[] myListings)
            {
                Console.Clear();
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates(myBookings, month, year);
                SortByDate(myBookings);
                PrintRevenue(myBookings, myListings);
                PauseAction();
            }
            static void PrintRevenue(Booking[] myBookings, Listing[] myListings)
            {
                double totalCost = 0;
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates(myBookings, month, year);
                int length = GetBookingLength(myBookings);
                for (int i = 0; i < length; i++)
                {
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    int sessionID = myBookings[i].GetSessionID();
                    double sessionCost = myListings[sessionID - 1].GetSessionCost();
                    if (month[i] == month[i + 1])
                    {
                        if (sessionStatus != "Canceled")
                        {
                            totalCost += sessionCost;
                        }
                    }
                    else
                    {
                        totalCost += sessionCost;
                        System.Console.WriteLine($"The total revenue for month {month[i]} of year {year[i]} is {totalCost}");
                        totalCost = 0;
                    }
                }
            }
            static void CreateDates(Booking[] myBookings, string[] month, string[] year)
            {
                int length = GetBookingLength(myBookings);
                for (int i = 0; i < length; i++)
                {
                    string[] temp = new string[100];
                    string date = myBookings[i].GetTrainingDate();
                    temp = date.Split('/');
                    month[i] = temp[0];
                    year[i] = temp[2];
                }
            }
            static void CreateDates2(Listing[] myListings, string[] month, string[] year)
            {
                int length = GetLength(myListings);
                for (int i = 0; i < length; i++)
                {
                    string[] temp = new string[100];
                    string date = myListings[i].GetSessionDate();
                    temp = date.Split('/');
                    month[i] = temp[0];
                    year[i] = temp[2];
                }
            }
            static void SwapYear(string[] year, int x, int y)
            {
                string temp = year[x];
                year[x] = year[y];
                year[y] = temp;
            }
            static void SortAfter(Booking[] myBookings)
            {
                int length = GetBookingLength(myBookings);
                for (int maxElement = length - 1; maxElement > 0; maxElement--)
                {
                    for (int index = 0; index < maxElement; index++)
                    {
                        string currName = myBookings[index].GetCustomerName();
                        string compName = myBookings[index + 1].GetCustomerName();
                        if (currName == compName)
                        {
                            string currDate = myBookings[index].GetTrainingDate();
                            string compDate = myBookings[index + 1].GetTrainingDate();
                            if (string.Compare(currDate, compDate) > 0)
                            {
                                SwapBookings(myBookings, index, index + 1);
                            }
                        }
                    }
                }
            }
            static void SortByDate(Booking[] myBookings)
            {
                int length = GetBookingLength(myBookings);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates(myBookings, month, year);
                for (int maxElement = length - 1; maxElement > 0; maxElement--)
                {
                    for (int index = 0; index < maxElement; index++)
                    {
                        int.TryParse(year[index], out int x);
                        int.TryParse(year[index + 1], out int y);
                        string currDate = myBookings[index].GetTrainingDate();
                        string compDate = myBookings[index + 1].GetTrainingDate();
                        if (x == y)
                        {
                            if (string.Compare(currDate, compDate) > 0)
                            {
                                SwapBookings(myBookings, index, index + 1);
                            }
                        }
                        else if (x > y)
                        {
                            SwapBookings(myBookings, index, index + 1);
                            SwapYear(year, index, index + 1);
                        }
                    }
                }
            }
            static void SortListingByDate(Listing[] myListings)
            {
                int length = GetLength(myListings);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates2(myListings, month, year);
                for (int maxElement = length - 1; maxElement > 0; maxElement--)
                {
                    for (int index = 0; index < maxElement; index++)
                    {
                        int.TryParse(year[index], out int x);
                        int.TryParse(year[index + 1], out int y);
                        string currDate = myListings[index].GetSessionDate();
                        string compDate = myListings[index + 1].GetSessionDate();
                        if (x == y)
                        {
                            if (string.Compare(currDate, compDate) > 0)
                            {
                                SwapListings(myListings, index, index + 1);
                            }
                        }
                        else if (x > y)
                        {
                            SwapListings(myListings, index, index + 1);
                            SwapYear(year, index, index + 1);
                        }
                    }
                }
            }
            static void SessionsByCustomer(Booking[] myBookings)
            {
                int length = GetBookingLength(myBookings);
                string curr = myBookings[0].GetCustomerName();
                int sessionCount = 0;
                for (int i = 0; i < length; i++)
                {
                    if (myBookings[i].GetCustomerName() == curr)
                    {
                        sessionCount += 1;
                    }
                    else
                    {
                        ProcessBreakSession(ref sessionCount, ref curr, myBookings[i]);
                    }
                }
                ProcessBreakSession2(curr, sessionCount);
            }
            static void ProcessBreakSession(ref int sessionCount, ref string curr, Booking newBooking)
            {
                System.Console.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
                curr = newBooking.GetCustomerName();
                sessionCount = 1;
            }
            static void ProcessBreakSession2(string curr, int sessionCount)
            {
                System.Console.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
            }
        }
    }
}