using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    
    public class Pet
    {
        public int id {get; set;}

        [Required]
        public string name {get; set;}

        public enum PetBreedType
        {
            Shepherd,
            Poodle,
            Beagle,
            Bulldog,
            Terrier,
            Boxer,
            Labrador,
            Retriever
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public PetBreedType breed { get; set; }
        public enum PetColorType 
        { 
            White,
            Black,
            Golden,
            Tricolor,
            Spotted
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public PetColorType color { get; set; }
        public DateTime checkedInAt {get; set;}
    }
}
