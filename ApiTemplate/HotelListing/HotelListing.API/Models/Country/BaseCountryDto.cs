using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    public  abstract class BaseCountryDto
    {
        [Required]
        public string  ShortName { get; set; }
        public string Name { get; set; }


    }
}
