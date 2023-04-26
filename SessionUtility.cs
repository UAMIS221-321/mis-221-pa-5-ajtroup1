namespace mis_221_pa_5_ajtroup1
{
    public class SessionUtility
    {
        private static Session[] sessions = new Session[100];

        //FILES
        public static void UpdateArray()
        {
            int count=0;
            StreamReader inFile = new StreamReader("transactions.txt");//open
            string line = inFile.ReadLine();
            while(line!=null)
            {
                string[] temp = line.Split("#");
                Session mySession = new Session(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                sessions[count] = mySession;
                count++;
                line = inFile.ReadLine();
            }
            inFile.Close();//close
        }
        public static void UpdateArrayWithNew(Session myPassedSession)//updates array from file and passes in a new instance to add in after
        {
            int count=0;
            StreamReader inFile = new StreamReader("transactions.txt");//open
            string line = inFile.ReadLine();
            while(line!=null)
            {
                if(line==null)
                    break;
                string[] temp = line.Split("#");
                Session mySession = new Session(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                sessions[count] = mySession;
                count++;
                line = inFile.ReadLine();
            }
            sessions[count] = myPassedSession;
            inFile.Close();//close
        }
        public static void PrintAvailable() //prints all avaiable sessions from listings.txt
        {
            System.Console.WriteLine("ALL AVAIALABLE LISTINGS:\n");
            StreamReader inFile = new StreamReader("listings.txt");//open
            string line = inFile.ReadLine();
            while(line!=null)
            {
                string[] temp = line.Split("#");
                if(temp[5]=="YES")
                    System.Console.WriteLine("\t"+temp[0]+" // Trainer: "+temp[1]+" // Date & Time: "+temp[2]+" @"+temp[3]);
                line = inFile.ReadLine();
            }
            System.Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            inFile.Close();//close
        }
        public static void BookListing(Session mySession)
        {
            UpdateArrayWithNew(mySession);
            StreamWriter outFile = new StreamWriter("transactions.txt");//open
            for(int i = 0; i<sessions.Length; i++)
            {
                if(sessions[i]==null)
                    break;
                outFile.WriteLine(sessions[i].GetID()+"#"+sessions[i].GetCustomerName()+"#"+sessions[i].GetEmail()+"#"+sessions[i].GetDate()+"#"+sessions[i].GetTrainerID()+"#"+sessions[i].GetTrainerName()+"#NO");
            }
            outFile.Close();//close
        }
        public static int SearchByEmail(string email) //returns index of matching email in "transactions.txt"
        {
            int count=0;
            StreamReader inFile = new StreamReader("transactions.txt");//opem
            string line = inFile.ReadLine();
            while(line!=null)
            {
                string[] temp = line.Split("#");
                if(temp[2]==email)
                {
                    return count;
                }
                count++;
                line = inFile.ReadLine();
            }
            inFile.Close();//close
            return -1;
        }

        //INTERNAL ARRAY
        public static Session[] ReturnTransactionArray()
        {
            UpdateArray();
            return sessions;
        }
    }
}