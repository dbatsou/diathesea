namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}