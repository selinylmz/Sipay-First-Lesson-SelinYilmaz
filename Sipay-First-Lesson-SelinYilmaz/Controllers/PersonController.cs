using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sipay_First_Lesson_SelinYilmaz.Model;

namespace Sipay_First_Lesson_SelinYilmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> _validator;

        public PersonController(IValidator<Person> validator)
        {
            _validator = validator;
        }

        [HttpPost("Create or update person")]
        public IActionResult CreateOrUpdatePerson([FromBody] Person person)
        {
            //here we perform the logic to create or update person

            var validationResult = _validator.Validate(person);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(person);
        }

    }
}
