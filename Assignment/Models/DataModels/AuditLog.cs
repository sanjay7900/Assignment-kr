namespace Assignment.Models.DataModels
{
   
        public class AuditLog
        {
            public int Id { get; set; }
            public string Action { get; set; }
            public int Username { get; set; }
            public DateTime Timestamp { get; set; }
            public string Details { get; set; }
        }

    
}
