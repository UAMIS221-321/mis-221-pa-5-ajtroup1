namespace mis_221_pa_5_ajtroup1
{
    public class ListingUtility
    {
        private static Listing[] listings = new Listing[100];

        //FILES
        public static void UpdateArray() //populate private static array with file
        {
            Array.Clear(listings);
            StreamReader inFile = new StreamReader("listings.txt");//open
            string line = inFile.ReadLine(); //priming
            int count=0;
            while(line!=null)//process
            {
                string[] temp = line.Split("#");
                Listing mylisting = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]),temp[5]);
                listings[count] = mylisting;
                count++;
                line = inFile.ReadLine(); //update
            }
            inFile.Close();//close
        }
        public static void UpdateFile() //print private static array into file
        {
            StreamWriter outFile = new StreamWriter("listings.txt");//open
            for(int i = 0; i<listings.Length; i++)//process
            {
                if(listings[i]==null)
                    break;
                outFile.WriteLine(listings[i].GetID()+"#"+listings[i].GetTrainer()+"#"+listings[i].GetDate()+"#"+listings[i].GetTime()+"#"+listings[i].GetCost()+"#"+listings[i].GetAvailable());
            }
            outFile.Close();//close
        }
        public static void DeleteListing(Listing[] listings, int searchVal)
        {
            StreamWriter outFile = new StreamWriter("listings.txt");//open
            for(int i=0; i<listings.Length; i++)
            {
                if(listings[i]==null)
                    break;
                if(listings[i].GetID()!=searchVal)
                    outFile.WriteLine(listings[i].GetID()+"#"+listings[i].GetTrainer()+"#"+listings[i].GetDate()+"#"+listings[i].GetTime()+"#"+listings[i].GetCost()+"#"+listings[i].GetAvailable());
            }
            outFile.Close();//close
        }

        //INTERNAL ARRAY
        public static void PrintAllListings()
        {
            UpdateArray();
            for(int i=0; i<listings.Length; i++)
            {
                if(listings[i]==null)
                    break;
                System.Console.WriteLine("\t"+listings[i].GetID()+" // Trainer: "+listings[i].GetTrainer()+" // Date & Time: "+listings[i].GetDate()+" @"+listings[i].GetTime()+" // Cost: $"+Math.Round(listings[i].GetCost(), 2)+" // Availabile: "+listings[i].GetAvailable());
            }
        }
        public static Listing[] ListingToArray()
        {
            UpdateArray();
            return listings;
        }
        public static void AddListingToArray(Listing myListing)
        {
            UpdateArray();
            int temp = GetHighestIndex();
            listings[temp] = myListing;
            UpdateFile();
        }
        public static void ReceiveArray(Listing[] listingsPassed)
        {
            listings = listingsPassed;
        }

        //COUNT
        public static int GetHighestID()
        {
            int highestID = 0;
            StreamReader inFile = new StreamReader("listings.txt"); //open
            string line = inFile.ReadLine(); //priming
            while(line!=null)//process
            {
                string[] temp = line.Split("#");
                if(int.Parse(temp[0])>highestID)
                    highestID = int.Parse(temp[0]);
                line = inFile.ReadLine(); //update
            }
            inFile.Close();//close
            return highestID;
        }
        public static int GetHighestIndex()
        {
            UpdateArray();
            int count = 0;
            while(1==1)
            {
                if(listings[count]==null)
                    break;
                count++;
            }
            return count;
        }
        public static int SearchByTrainer(string searchVal)
        {
            UpdateArray();
            for(int i=0; i<listings.Length; i++)
            {
                if(listings[i]==null)
                    break;
                if(listings[i].GetTrainer()==searchVal)
                    return i;
            }
            return -1;
        }
        public static int SearchByID(int searchVal)
        {
            UpdateArray();
            for(int i=0; i<listings.Length; i++)
            {
                if(listings[i]==null)
                    break;
                if(listings[i].GetID()==searchVal)
                    return i;
            }
            return -1;
        }
    }
}