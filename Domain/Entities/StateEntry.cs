using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class StateEntry : BaseEntity
    {
        [Key]
        public int StateEntryId { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}