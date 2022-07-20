using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using AutoMapper;
using HotelListing.API.Contracts;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper ;
        private readonly ICountryRepository _coutryRepository;

        public CountriesController( IMapper mapper, ICountryRepository coutryRepository)
        {
            
            _mapper = mapper;
            _coutryRepository = coutryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            var countries = await _coutryRepository.GetAllAsync(); 
            var recors = _mapper.Map<List<CountryDto>>(countries); 
            return Ok(recors);             
                        

        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailsDto>> GetCountry(int id)
        {

            var country = await _coutryRepository.GetDetails(id);
          //  var country = await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);

            if (country == null)
            {
                return NotFound();
            }
            var countryDto = _mapper.Map<CountryDetailsDto>(country);

            return Ok(countryDto); 
        }

        // PUT: api/Countries/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest("Invalid Record ID");
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country = await _coutryRepository.GetAsync(id);
            _mapper.Map(updateCountry, country);
            if (country == null)
            {
                return NotFound();
            }

            try
            {
                await _coutryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            var country = _mapper.Map<Country>(createCountryDto);
            
            await _coutryRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _coutryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _coutryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _coutryRepository.Exists(id);
        }
    }
}
