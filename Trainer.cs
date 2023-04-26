namespace mis_221_pa_5_ajtroup1
{
    public class Trainer
    {
        private string name, mailAddress, email;
        private int id;

        //CONSTRUCTORS
        public Trainer()
        {

        }
        public Trainer(string name, string mailAddress, string email) //used to create new trainer. Sets ID to highest number+1 from file
        {
            id = TrainerUtility.GetHighestID()+1;
            this.name = name;
            this.mailAddress = mailAddress;
            this.email = email;
        }
        public Trainer(string name, int id, string mailAddress, string email) //used for temporary objects
        {
            this.name = name;
            this.id = id;
            this.mailAddress = mailAddress;
            this.email = email;
        }

        //GET SET
        public string GetName()
        {
            return name;
        }
        public int GetID()
        {
            return id;
        }
        public string GetAddress()
        {
            return mailAddress;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetID(int id)
        {
            this.id = id;
        }
        public void SetAddress(string mailAddress)
        {
            this.mailAddress = mailAddress;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }

        public override string ToString()
        {
            return $""+name+" "+id+" "+mailAddress+" "+email;
        }
    }
}