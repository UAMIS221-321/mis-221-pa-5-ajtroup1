
namespace mis_221_pa_5_ajtroup1
{
    public class TrainerUtility
    {
        private static Trainer[] trainers = new Trainer[100];

        //FILES
        public static void UpdateArray()  //sets internal static array to what is in the file
        {
            int count=0;
            Array.Clear(trainers);
            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine(); //priming
            while(line!=null)
            {
                string[] temp = line.Split("#");
                Trainer myTrainer = new Trainer(temp[0], int.Parse(temp[1]), temp[2], temp[3]);
                trainers[count] = myTrainer;
                count++;
                line = inFile.ReadLine(); //update
            }
            inFile.Close();
        }
        public static void UpdateFile()  //update the file using the private static array
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for(int i = 0; i<trainers.Length; i++)
            {
                if(trainers[i]==null)
                    break;
                else
                {
                    outFile.WriteLine((trainers[i].GetName()+"#"+trainers[i].GetID()+"#"+trainers[i].GetAddress()+"#"+trainers[i].GetEmail()));
                }
            }
            outFile.Close();
        }
        public static Trainer[] DeleteTrainer(Trainer[] trainersPassed, string searchVal) //update the file from program cs 
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");//open
            for(int i = 0; i<trainersPassed.Length; i++)//process
            {
                if(trainers[i]==null)
                    break;
                else if(trainersPassed[i].GetName()==searchVal)
                {
                    //don't write into the file
                }
                else
                {
                    outFile.WriteLine(trainersPassed[i].GetName()+"#"+trainersPassed[i].GetID()+"#"+trainersPassed[i].GetAddress()+"#"+trainersPassed[i].GetEmail());
                }
            }
            outFile.Close();//close
            UpdateArray();
            return trainers;
        }
        public static Trainer[] TrainerToArray()
        {
            UpdateArray();
            return trainers;
        }

        //INTERNAL ARRAY
        public static Trainer[] ReturnArray()
        {
            UpdateArray();
            return trainers;
        }
        public static void ReceiveArray(Trainer[] trainersPassed)
        {
            trainers = trainersPassed;
        }
        public static void AddTrainerToArray(Trainer myTrainer)
        {
            UpdateArray();
            int temp = GetHighestIndex();
            trainers[temp] = myTrainer;
            UpdateFile();
        }
        public static void ListAllTrainers()
        {
            UpdateArray();
            for(int i=0; i<trainers.Length; i++)
            {
                if(trainers[i]==null)
                    break;
                System.Console.WriteLine("\t"+trainers[i].GetName()+", ID: "+trainers[i].GetID()+", Address: "+trainers[i].GetAddress()+", Email: "+trainers[i].GetEmail());
            }
        }

        //"COUNT"
        public static int GetHighestID() //returns the highest id in the file
        {
            int highestID=0;
            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine(); //priming
            while(line!=null)
            {
                string[] temp = line.Split("#");
                if(int.Parse(temp[1])>highestID)
                {
                    highestID = int.Parse(temp[1]);
                }
                line = inFile.ReadLine(); //update
            }
            inFile.Close();
            return highestID;
        }
        public static int GetHighestIndex()
        {
            UpdateArray();
            int count = 0;
            while(1==1)
            {
                if(trainers[count]==null)
                    break;
                count++;
            }
            return count;
        }
        public static int Search(string searchVal)
        {
            UpdateArray();
            int index;
            for(int i=0; i<trainers.Length; i++)
            {
                if(trainers[i]==null)
                {
                    i++;
                    continue;
                }
                if(trainers[i].GetName().ToUpper()==searchVal.ToUpper())
                    return i;
            }
            return -1;
        }
    }
}