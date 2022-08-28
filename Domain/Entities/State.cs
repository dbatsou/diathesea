using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public int? Order { get; set; }
        public string StateName { get; set; }
        public int? ParentStateID { get; set; }
    }
}