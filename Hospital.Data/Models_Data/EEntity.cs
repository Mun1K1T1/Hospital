using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Data.Models_Data
{
    public class EEntity
    {
        [Key]
        public Guid Key { get; set; }
    }
}
