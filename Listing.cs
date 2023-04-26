namespace mis_221_pa_5_ajtroup1
{
    public class Listing
    {
        private int id;
        private string trainer, date, time, available;
        private double cost=50;

        //CONSTRUCTORS
        public Listing()
        {

        }
        public Listing(string trainer, string date, string time, double cost, string available) //generates id on creation
        {
            this.trainer = trainer;
            this.date = date;
            this.time = time;
            this.cost = 50;
            this.available = available;
            id = ListingUtility.GetHighestID()+1;
        }
        public Listing(int id, string trainer, string date, string time, double cost, string available) //used when id is being passed, not generated
        {
            this.id = id;
            this.trainer = trainer;
            this.date = date;
            this.time = time;
            this.cost = 50;
            this.available = available;
        }

        //GET SET
        public int GetID()
        {
            return id;
        }
        public string GetTrainer()
        {
            return trainer;
        }
        public string GetDate()
        {
            return date;
        }
        public string GetTime()
        {
            return time;
        }
        public double GetCost()
        {
            return cost;
        }
        public string GetAvailable()
        {
            return available;
        }
        public void SetID(int id)
        {
            this.id = id;
        }
        public void SetTrainer(string trainer)
        {
            this.trainer = trainer;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public void SetTime(string time)
        {
            this.time = time;
        }
        public void SetCost(double cost)
        {
            this.cost = cost;
        }
        public void SetAvailable(string available)
        {
            this.available = available;
        }
    }
}