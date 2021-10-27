using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{

    public enum BreadType {
        Sourdough,      // 0
        Focaccia,       // 1
        Rye,            // 2
        Wheat,          // 3
        White           // 4
    }

    public class Bread 
    {
        public int id {get; set;}

        [Required]
        public string name {get; set;}

        public string description {get; set;}

        public int count {get; set;}

        [ForeignKey("Bakers")]
        public int bakedById {get; set;}

        public Baker bakedBy {get; set;}

        // JSON converst our BreadType ints
        // into string value
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type {get; set;}
    }
}
