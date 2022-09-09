using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ActivityEntry : BaseEntity
    {
        [Key]
        public int ActivityEntryId { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public string Note { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
    }
}