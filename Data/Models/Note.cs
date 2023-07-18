namespace Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        public int InvoiceNumber { get; set; }

        public Employee Employee { get; set; }
        public Company Company { get; set; }
    }
}
