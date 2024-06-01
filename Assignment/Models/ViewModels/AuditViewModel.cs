namespace Assignment.Models.ViewModels
{
    public class AuditViewModel
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int Username { get; set; }
        public string name { get; set; }
        public DateTime Timestamp { get; set; }
        public string Details { get; set; }
        public AuditViewModel()
        {
            if (Id == 1)
            {
                name = "Operator";

            }
            else
            {
                name = "Admin";

            }
        }
    }
}
