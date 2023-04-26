namespace mis_221_pa_5_ajtroup1
{
    public class Session
    {
        private int id, trainerID;
        private string customerName, customerEmail, date, trainerName, status;

        //CONSTRUCTORS
        public Session()
        {

        }
        public Session(int id, string customerName, string customerEmail, string date, int trainerID, string trainerName, string status)
        {
            this.id = id;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.date = date;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        //GET SET
        public int GetID()
        {
            return id;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public string GetEmail()
        {
            return customerEmail;
        }
        public string GetDate()
        {
            return date;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public string GetStatus()
        {
            return status;
        }
    }
}