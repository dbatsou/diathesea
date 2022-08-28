using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
    }
}