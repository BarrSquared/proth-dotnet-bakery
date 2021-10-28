using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        public int id {get; set;}

        [Required]
        public string name {get; set;}
    }
}

// {get; set;} 
// get; returns value of a variable
// set; assigns value to the variable