using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratory_2.Data.Models.Data
{
    public class EEntity
    {
        [Key]
        public Guid Key { get; set; }
    }
}
