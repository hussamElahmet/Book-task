using Alphastellar.DataProcess;
using Alphastellar.IBll;
using Alphastellar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Alphastellar.Models.Book;


namespace Alphastellar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Ibook InterfaceBook;
        public BookController(Ibook countryInterface)
        {
            InterfaceBook = countryInterface;
        }
        [HttpGet]
        public Book Get()
        {
            return InterfaceBook.GetBook(); ;
        }               
        // POST api/<BookForm>
        [HttpGet("{From}/{To}/{CountryId}")]
        public outputForm Get(string From, string To, int CountryId)
        {
            var country= InterfaceBook.AllCountries.Where(x => x.CountryId ==CountryId).First();
            var holidays = InterfaceBook.GetHolidaysById(CountryId);
            var BusinessDays = new CountryDPL().BusinessDaysGet(Convert.ToDateTime(From), Convert.ToDateTime(To),country);
            var Price = new CountryDPL().TotalPriceGet(BusinessDays);
            outputForm result = new outputForm()
            {
                BuisnessDays = BusinessDays,
                TotalPrice = Price,
                Currency = country.CountryCurrency
            };
            return result;

        }
    }
}
