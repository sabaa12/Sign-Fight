namespace Domain.Models.Data
{
    public class SubScribes
    {
        public int ID { get; set; }
        public int CauseID { get; set; }
        public string UserID { get; set; }
        public Cause Cause { get; set; }
    }
}
