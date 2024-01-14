﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EntityModels
{
    [Table("Drzava")] 
    public class Drzava
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
