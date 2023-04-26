using mis_221_pa_5_ajtroup1;
//start main

Trainer[] trainers = new Trainer[100];
trainers = TrainerUtility.TrainerToArray();
Listing[] listings = new Listing[100];
listings = ListingUtility.ListingToArray();
Menu(trainers, listings);

//end main

//MENU METHODS
static void Menu(Trainer[] trainers, Listing[] listings)
{
    DateTime dateTime = DateTime.Now;
    int menuChoice=0;
    while(menuChoice!=5)
    {
        Console.Clear();
        System.Console.WriteLine("REDX MENU:\t\t\t\t\t\tCurrent Date and Time: "+dateTime+"\n\t1-Trainers\n\t2-Listings\n\t3-Book\n\t4-Reports\n\t5-Exit");
        menuChoice = int.Parse(Console.ReadLine());
        if(menuChoice==1)
            TrainerDirect(trainers);
        else if(menuChoice==2)
            ListingDirect(listings);
        else if(menuChoice==3)
            BookingDirect(listings, trainers);
        else if(menuChoice==4)
            ReportDirect();
        else if(menuChoice==5)
            break;
        else
        {
            System.Console.WriteLine("Invalid input. Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

//TRAINER METHODS
static void UpdateTrainerArray(Trainer[] trainers)
{
    trainers = TrainerUtility.ReturnArray();
}
static void TrainerDirect(Trainer[] trainers)
{
    int menuChoice=0;
    while(menuChoice!=5)
    {
        Console.Clear();
        Console.Clear();
        System.Console.WriteLine("TRAINER MENU:\n\t1-Add Trainer\n\t2-Edit Trainer\n\t3-KILL (delete) Trainer\n\t4-List All Trainers\n\t5-Exit");
        menuChoice = int.Parse(Console.ReadLine());
        if(menuChoice==1)
            AddTrainer();
        else if(menuChoice==2)
            EditTrainer(trainers);
        else if(menuChoice==3)
            DeleteTrainer(trainers);
        else if(menuChoice==4)
        {
            Console.Clear();
            System.Console.WriteLine("ALL TRAINERS:\n");
            TrainerUtility.ListAllTrainers();
            System.Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        else if(menuChoice==5)
            break;
        else
        {
            System.Console.WriteLine("Invalid input. Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
static void AddTrainer()
{
    string name, mailAddress, email;
    Console.Clear();
    System.Console.WriteLine("Adding Trainer...");
    System.Console.WriteLine("Trainer name: ");
    name = Console.ReadLine();
    System.Console.WriteLine("Trainer mailing address: ");
    mailAddress = Console.ReadLine();
    System.Console.WriteLine("Trainer email: ");
    email = Console.ReadLine();
    Trainer myTrainer = new Trainer(name, mailAddress, email);
    TrainerUtility.AddTrainerToArray(myTrainer);
}
static void EditTrainer(Trainer[] trainers)
{
    Console.Clear();
    string search ="";
    while(search.ToUpper()!="EXIT")
    {
        System.Console.WriteLine("Input name of trainer you wish to edit ('Exit' to exit): ");
        search = Console.ReadLine();
        if(search.ToUpper()=="EXIT")
            break;
        Console.Clear();
        int index = TrainerUtility.Search(search);
        if(index == -1)
        {
            System.Console.WriteLine("No trainers were found by that name");
            System.Console.WriteLine("Input name of trainer you wish to edit ('Exit' to exit): ");
            search = Console.ReadLine();
            continue;
        }
        int editChoice=0;
        if(search.ToUpper()=="EXIT")
            break;
        while(editChoice!=1 || editChoice!=2 || editChoice!=3)
        {
            System.Console.WriteLine("Edit:\n\t1-Name\n\t2-Mailing Address\n\t3-Email\n");
            editChoice = int.Parse(Console.ReadLine());
            if(editChoice!=1 && editChoice!=2 && editChoice!=3)
            {
                System.Console.WriteLine("Invalid input. Press Enter to continue...");
                Console.ReadLine();
                continue;
            }
            else if(editChoice==1)
            {

                System.Console.WriteLine("New trainer name: ");
                string name = Console.ReadLine();
                trainers[index].SetName(name);
                break;
            }
            else if(editChoice==2)
            {
                System.Console.WriteLine("New trainer mail address: ");
                string mailAddress = Console.ReadLine();
                trainers[index].SetAddress(mailAddress);
                break;
            }
            else if(editChoice==3)
            {
                System.Console.WriteLine("New trainer email: ");
                string email = Console.ReadLine();
                trainers[index].SetEmail(email);
                break;
            }
        }
        TrainerUtility.ReceiveArray(trainers);
        TrainerUtility.UpdateFile();
    }
    
}
static void DeleteTrainer(Trainer[] trainers)
{
    Console.Clear();
    string search="";
    while(search.ToUpper()!="EXIT")
    {
        if(search == "")
        {
            System.Console.WriteLine("Input name of trainer you wish to delete ('Exit' to exit): ");
            search = Console.ReadLine();
        }
        Console.Clear();
        int index = TrainerUtility.Search(search);
        if(index == -1)
        {
            System.Console.WriteLine("No trainers were found by that name");
            System.Console.WriteLine("Input name of trainer you wish to delete ('Exit' to exit): ");
            search = Console.ReadLine();
            continue;
        }
        else
        {
            System.Console.WriteLine("Are you sure you want to delete "+trainers[index].GetName()+"? ");
            string confirm = Console.ReadLine();
            if(confirm.ToUpper()=="YES")
            {
                trainers = TrainerUtility.DeleteTrainer(trainers, trainers[index].GetName());
                break;
            }
            else if(confirm.ToUpper()=="NO")
                break;
            else
            {
                System.Console.WriteLine("Invalid input. Type either 'no' or 'yes'");
                confirm = Console.ReadLine();
                continue;
            }
        }
    }
}

//LISTING METHODS
static void ListingDirect(Listing[] listings)
{
    Console.Clear();
    System.Console.WriteLine("LISTING MENU:\n\t1-Add Listing\n\t2-Edit Listing\n\t3-Delete Listing\n\t4-Print All Listings\n\t5-Exit"); 
    int menuChoice = int.Parse(Console.ReadLine()); //priming
    while(menuChoice!=5)
    {
        Console.Clear();
        if(menuChoice==1)
            AddListing();
        else if(menuChoice==2)
            EditListing(listings);
        else if(menuChoice==3)
            DeleteListing(listings);
        else if(menuChoice==4)
        {
            System.Console.WriteLine("ALL LISTINGS:\n");
            ListingUtility.PrintAllListings();
            System.Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        else if(menuChoice==5)
            break;
        else
        {
            System.Console.WriteLine("Invalid input. Press Enter to continue...");
            Console.ReadLine();
        }
        Console.Clear();
        System.Console.WriteLine("LISTING MENU:\n\t1-Add Listing\n\t2-Edit Listing\n\t3-Delete Listing\n\t4-Print All Listings\n\t5-Exit"); 
        menuChoice = int.Parse(Console.ReadLine()); //update
    }
}
static void AddListing()
{
    Console.Clear();
    System.Console.WriteLine("ADDING LISTING:");
    System.Console.WriteLine("Trainer conducting session: ");
    string trainer = Console.ReadLine();
    int index = TrainerUtility.Search(trainer);
    while(index==-1)
    {
        System.Console.WriteLine("There is no trainer by the name '"+trainer+"'");
        System.Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        System.Console.WriteLine("Trainer conducting session: ");
        trainer = Console.ReadLine();
        index = TrainerUtility.Search(trainer);
    }
    System.Console.WriteLine("Date of session (M/D/YY): ");
    string date = Console.ReadLine();
    System.Console.WriteLine("Time of session (HH:MM):");
    string time = Console.ReadLine();
    double cost = 50;
    System.Console.WriteLine("Is this session available ('yes' or 'no')? ");
    string available = Console.ReadLine();
    available = available.ToUpper();
    while(available!="YES" && available!="NO")
    {
        System.Console.WriteLine("Invalid input. Press Enter to continue...");
        Console.ReadLine();
        System.Console.WriteLine("Is this session available ('yes' or 'no')? ");
        available = Console.ReadLine();
    }
    Listing myListing = new Listing(trainer, date, time, cost, available);
    ListingUtility.AddListingToArray(myListing);
}
static void EditListing(Listing[] listings)
{
    Console.Clear();
    System.Console.WriteLine("EDITING LISTING:");
    System.Console.WriteLine("Enter ID of listing(-1 to exit): ");
    int searchVal = int.Parse(Console.ReadLine());
    while(searchVal!=-1)
    {
        int index = ListingUtility.SearchByID(searchVal);
        if(index==-1)
        {
            System.Console.WriteLine("No listing was found by that ID number. Press Enter to continue...");
            Console.ReadLine();
        }
        else if(index>-1)
        {
            while(1==1)//wacky logic
            {
                Console.Clear();
                System.Console.WriteLine("EDITING LISTING #"+listings[index].GetID()+" WITH TRAINER "+listings[index].GetTrainer()+" ON "+listings[index].GetDate()+" @"+listings[index].GetTime());
                System.Console.WriteLine("Do you want to edit:\n\t1-Trainer Name\n\t2-Date\n\t3-Time\n\t4-Cost\n\t5-Availability");
                int editChoice = int.Parse(Console.ReadLine());
                if(editChoice!=1 && editChoice!=2 && editChoice!=3 && editChoice!=4 && editChoice!=5)
                {
                    System.Console.WriteLine("Invalid input. Press Enter to continue...");
                    Console.ReadLine();
                }
                if(editChoice==1)
                {
                    System.Console.WriteLine("New Trainer Name: ");
                    string name = Console.ReadLine();
                    listings[index].SetTrainer(name);
                    searchVal=-1;
                }
                else if(editChoice==2)
                {
                    System.Console.WriteLine("New Date (D/M/YY): ");
                    string date = Console.ReadLine();
                    listings[index].SetDate(date);
                    searchVal=-1;
                }
                else if(editChoice==3)
                {
                    System.Console.WriteLine("New Time (HH:MM): ");
                    string time = Console.ReadLine();
                    listings[index].SetTime(time);
                    searchVal=-1;
                }
                else if(editChoice==4)
                {
                    System.Console.WriteLine("New Cost (no $): ");
                    double cost = double.Parse(Console.ReadLine());
                    listings[index].SetCost(cost);
                    searchVal=-1;
                }
                else if(editChoice==5)
                {
                    string available;
                    if(listings[index].GetAvailable()=="YES")
                        available="AVAILABLE";
                    else
                        available="NOT AVAILABLE";
                    string change="";
                    while(change=="")
                    {
                        System.Console.WriteLine("This session is currently "+available+". Do you want to change that? ");
                        change = Console.ReadLine();
                        if(change.ToUpper()=="YES")
                        {
                            if(listings[index].GetAvailable()=="YES")
                                listings[index].SetAvailable("NO");
                            else
                                listings[index].SetAvailable("YES");
                            searchVal=-1;
                            break;
                        }
                        else if(change.ToUpper()=="NO")
                        {
                            searchVal=-1;
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid input. Press Enter to continue...");
                            Console.ReadLine();
                            continue;
                        }
                    }
                }
                ListingUtility.ReceiveArray(listings);
                ListingUtility.UpdateFile();
                if(searchVal==-1)
                    break;
            }

        }
        if(searchVal==-1)
            break;
        Console.Clear();
        System.Console.WriteLine("Enter ID of listing(-1 to exit): ");
        searchVal = int.Parse(Console.ReadLine());
    }
}
static void DeleteListing(Listing[] listings)
{
    Console.Clear();
    System.Console.WriteLine("Enter ID of the listing you want to delete (-1 to exit): ");
    int searchVal = int.Parse(Console.ReadLine());//priming
    while(searchVal!=-1)
    {
        int index = ListingUtility.SearchByID(searchVal);
        if(index==-1)
        {
            System.Console.WriteLine("There is no listing with that ID number. Press Enter to continue...");
            Console.ReadLine();
        }
        else if(index>-1)
        {
            System.Console.WriteLine("Are you sure you want to delete listing #"+listings[index].GetID()+" with "+listings[index].GetTrainer()+" on "+listings[index].GetDate()+" @"+listings[index].GetTime()+"? ");
            string confirm = Console.ReadLine();
            while(confirm.ToUpper()!="NO")
            {
                if(confirm.ToUpper()=="YES")
                {
                    ListingUtility.DeleteListing(listings, searchVal);
                    searchVal=-1;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid input. Press Enter to continue...");
                    Console.ReadLine();
                }
                Console.Clear();
                System.Console.WriteLine("Are you sure you want to delete listing #"+listings[index].GetID()+" with "+listings[index].GetTrainer()+" on "+listings[index].GetDate()+" @"+listings[index].GetTime()+"? ");
                confirm = Console.ReadLine();
            }
        }
        Console.Clear();
        if(searchVal==-1)
            break;
        System.Console.WriteLine("Enter ID of the listing you want to delete (-1 to exit): ");
        searchVal = int.Parse(Console.ReadLine());//update
    }
}

//BOOKING METHODS
static void BookingDirect(Listing[] listings, Trainer[] trainers)
{
    int menuChoice=0;
    while(menuChoice!=3)
    {
        Console.Clear();
        System.Console.WriteLine("BOOKING MENU:\n\t1-View Available Sessions\n\t2-Book a Session\n\t3-Exit\n");
        menuChoice = int.Parse(Console.ReadLine());
        if(menuChoice==1)
            ShowAvailable();
        else if(menuChoice==2)
            BookSession(listings, trainers);
        else if(menuChoice==3)
            break;
        else
        {
            System.Console.WriteLine("Invalid input. Press Enter to continue... ");
            Console.ReadLine();
            continue;
        }  
    }
}
static void ShowAvailable()
{
    Console.Clear();
    SessionUtility.PrintAvailable();
}
static void BookSession(Listing[] listings, Trainer[] trainers)
{
    Console.Clear();
    System.Console.WriteLine("BOOKING SESSION:\nEnter ID# of the listing you want to book (-1 to exit): ");
    int searchVal = int.Parse(Console.ReadLine());
    while(searchVal!=-1)
    {
        int index = ListingUtility.SearchByID(searchVal);
        if(index==-1)
        {
            System.Console.WriteLine("Couldn't find a session with that ID#. Press Enter to continue...");
            Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine("Are you sure you want to book session #"+listings[index].GetID()+" with "+listings[index].GetTrainer()+" on "+listings[index].GetDate()+" @"+listings[index].GetTime());
            string confirm = Console.ReadLine();
            while(confirm.ToUpper()!="NO" && confirm.ToUpper()!="YES")
            {
                System.Console.WriteLine("Invalid input. Press Enter to continue...");
                Console.ReadLine();
                System.Console.WriteLine("Are you sure you want to book session #"+listings[index].GetID()+" with "+listings[index].GetTrainer()+" on "+listings[index].GetDate()+" @"+listings[index].GetTime());
                confirm = Console.ReadLine();
            }
            if(confirm.ToUpper()=="YES")
            {
                System.Console.WriteLine("Name of customer book this session: ");
                string customerName = Console.ReadLine();
                System.Console.WriteLine("Customer email: ");
                string customerEmail = Console.ReadLine();
                string trainerName = listings[index].GetTrainer();
                int trainerIndex = ListingUtility.SearchByTrainer(trainerName);
                int trainerID = trainers[trainerIndex].GetID();
                Session mySession = new Session(listings[index].GetID(), customerName, customerEmail, listings[index].GetDate(), trainerID, trainerName, "NO");
                SessionUtility.BookListing(mySession);
                ListingUtility.DeleteListing(listings, searchVal);
                ListingUtility.UpdateArray();
                searchVal=-1;
            }
        }
        Console.Clear();
        System.Console.WriteLine("BOOKING SESSION:\nEnter ID# of the listing you want to book (-1 to exit): ");
        searchVal = int.Parse(Console.ReadLine());
    }

}

//REPORTS METHODS
static void ReportDirect()
{
    Console.Clear();
    System.Console.WriteLine("REPORTS MENU:\n\t1-Individual Customer Report\n\t2-Historical Customer Sessions\n\t3-Historical Revenue Report\n\t4-Exit");
    int menuChoice = int.Parse(Console.ReadLine());
    while(menuChoice!=4)
    {
        if(menuChoice==1)
            IndividualReport();
        else if(menuChoice==2)
            HistoricalSessions();
        else if(menuChoice==3)
        {
            RevenueReport();
        }
        else if(menuChoice==4)
            break;
        else
        {
            System.Console.WriteLine("Input invalid. Press Enter to continue...");
            Console.ReadLine();
        }
        Console.Clear();
        System.Console.WriteLine("REPORTS MENU:\n\t1-Individual Customer Report\n\t2-Historical Customer Sessions\n\t3-Historical Revenue Report\n\t4-Exit");
        menuChoice = int.Parse(Console.ReadLine());
    }
}
static void IndividualReport()  //search by email. report all customer instances in "transactions.txt"
{
    string email="";
    while(email!="-1")
    {
        Console.Clear();
        System.Console.WriteLine("Input customer email (-1 to exit): ");
        email = Console.ReadLine();
        if(email=="-1")
            break;
        if(SessionUtility.SearchByEmail(email) == -1)
        {
            System.Console.WriteLine("No sessions were found for "+email+". Press Enter to continue...");
            Console.ReadLine();
            continue;
        }
        else
        {
            string name="";
            Console.Clear();
            System.Console.WriteLine("REPORT FOR "+email+":\n");
            StreamReader inFile = new StreamReader("transactions.txt");
            string line = inFile.ReadLine();
            while(line!=null)
            {
                string[] temp = line.Split("#");
                if(temp[2]==email)
                {
                    System.Console.WriteLine("\t"+temp[0]+" // Customer: "+temp[1]+" (email: "+temp[2]+") // Date: "+temp[3]+" // Trainer: "+temp[5]);
                    name=temp[1];
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
            System.Console.WriteLine("\nWould you like to save this report to a file('yes' or 'no')?");
            string save = Console.ReadLine();
            if(save.ToUpper()=="YES")
            {
                string temp = " Report.txt";
                string pathName = String.Concat(name, temp);
                StreamWriter outFile = new StreamWriter(pathName);
                outFile.WriteLine(name+" REPORT: \n");
                StreamReader inFile2 = new StreamReader("transactions.txt");
                string line2 = inFile2.ReadLine();
                while(line2!=null)
                {
                    string[] temp2 = line2.Split("#");
                    if(temp2[2]==email)
                    {    
                        outFile.WriteLine("\t"+temp2[0]+" // Customer: "+temp2[1]+" (email: "+temp2[2]+") // Date: "+temp2[3]+" // Trainer: "+temp2[5]);
                    }
                    line2 = inFile2.ReadLine();
                }
                outFile.Close();
                inFile2.Close();
                System.Console.WriteLine("Your file was saved as '"+pathName+"'. Press Enter to continue...");
                Console.ReadLine();
            }
            else if(save.ToUpper()=="NO")
            {
                //do nothing
            }
            else
            {
                System.Console.WriteLine("Input invalid. Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
static void HistoricalSessions()
{
    Console.Clear();
    System.Console.WriteLine("HISTORICAL CUSTOMER REPORT:\n");
    string[] names = new string[100];
    Session[] sessions = new Session[100];
    sessions = SessionUtility.ReturnTransactionArray();
    for(int i = 0;i<sessions.Length; i++)
    {
        if(sessions[i]==null || sessions[i].GetCustomerName()=="")
            break;
        names[i] = sessions[i].GetCustomerName();
    }
    Array.Sort(names);
    names = RemoveDuplicates(names);
    for(int i = 0; i<names.Length; i++)
    {
        if(names[i]=="" || names[i]==null)
        {
            i++;
            continue;
        }
        for(int j=0; j<sessions.Length; j++)
        {
            if(sessions[j]==null)
            {
                j++;
                continue;
            }
            if(sessions[j].GetCustomerName()==names[i])
            {
                System.Console.WriteLine("\t"+sessions[j].GetID()+" // Customer: "+sessions[j].GetCustomerName()+" (email: "+sessions[j].GetEmail()+") // Trainer: "+sessions[j].GetTrainerName()+" (ID: "+sessions[j].GetTrainerID()+") // Date: "+sessions[j].GetDate());
            }
        }
    }
    System.Console.WriteLine("\nWould you like to save this report ('yes' or 'no')? ");
    string save = Console.ReadLine();
    if(save.ToUpper()=="YES")
    {
        StreamWriter outFile = new StreamWriter("HistoricalReport.txt");
        outFile.WriteLine("HISTORICAL CUSTOMER REPORT:\n");
        for(int i = 0; i<names.Length; i++)
        {
            if(names[i]=="" || names[i]==null)
            {
                i++;
                continue;
            }
            for(int j=0; j<sessions.Length; j++)
            {
                if(sessions[j]==null)
                {
                    j++;
                    continue;
                }
                if(sessions[j].GetCustomerName()==names[i])
                {
                    outFile.WriteLine("\t"+sessions[j].GetID()+" // Customer: "+sessions[j].GetCustomerName()+" (email: "+sessions[j].GetEmail()+") // Trainer: "+sessions[j].GetTrainerName()+" (ID: "+sessions[j].GetTrainerID()+") // Date: "+sessions[j].GetDate());
                }
            }
        }
        outFile.Close();
        System.Console.WriteLine("Report saved under 'HistoricalReport.txt'. Press Enter to continue...");
        Console.ReadLine();
    }
}
static string[] RemoveDuplicates(string[] names) //used for historical session report to remove duplicate names for mutiple sessions
{
    int newIndex = 0;
    string[] newNames = new string[100];
    for(int i = 0; i<names.Length; i++)
    {
        bool duplicate = false;
        for(int j=0; j<newNames.Length; j++)
        {
            if(names[i]==newNames[j])
            {
                duplicate=true;
            }
        }
        if(duplicate==false)
        {
            newNames[newIndex] = names[i];
            newIndex++;
        }
    }
    return newNames;
}
static void RevenueReport() //month revenue & revenue 2023 update when you book sessions in the program. Sample data was used to get the rest of the amounts
{
    double revenue2020=202560, revenue2021=278940, revenue2022=315680, monthRevenue=TotalCurrentRevenue();
    double revenue2023 = 103540+monthRevenue;
    Console.Clear();
    System.Console.WriteLine("HISTORICAL REVENUE REPORT: ");
    System.Console.WriteLine("\n\t2020: "+revenue2020+"\n\t2021: "+revenue2021+"\n\t2022: "+revenue2022+"\n\t2023: "+revenue2023+"\n\nCurrent Month Revenue: "+monthRevenue);
    System.Console.WriteLine("\nWould you like to save this to a file? ");
    string save = Console.ReadLine();
    if(save.ToUpper()=="YES")
    {
        StreamWriter outFile = new StreamWriter("RevenueReport.txt");
        outFile.WriteLine("HISTORICAL REVENUE REPORT: ");
        outFile.WriteLine("\n\t2020: "+revenue2020+"\n\t2021: "+revenue2021+"\n\t2022: "+revenue2022+"\n\t2023: "+revenue2023+"\n\nCurrent Month Revenue: "+monthRevenue);
        outFile.Close();
        System.Console.WriteLine("Saved to 'RevenueReport.txt'. Press Enter to continue...");
        Console.ReadLine();
    }
}
static double TotalCurrentRevenue() //totals revenue from this month (April / 4) transactions to populate "monthRevenue" in revenue report. A session costs $50
{
    double total=0;
    StreamReader inFile = new StreamReader("transactions.txt");
    string line = inFile.ReadLine();
    while(line!=null)
    {
        string[] temp = line.Split("#");
        if(temp[3].Substring(0, 1)=="4") //if the transaction is in the month "4" (april)
            total+=50;
        line = inFile.ReadLine();
    }
    inFile.Close();
    return total;
}