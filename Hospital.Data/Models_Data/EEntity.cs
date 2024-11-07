using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Data.Models_Data
{
    public class EEntity
    {
        [Key]
        public Guid Key { get; set; }
    }
}
