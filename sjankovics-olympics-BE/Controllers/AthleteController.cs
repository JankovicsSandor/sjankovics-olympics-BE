using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sjankovics_olympics_BL.AthleteLogic;
using sjankovics_olympics_BL.Input;
using sjankovics_olympics_Database.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sjankovics_olympics_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AthleteController : Controller
    {
        private IAthleteLogic _athleteLogic;

        public AthleteController(IAthleteLogic athleteLogic)
        {
            _athleteLogic = athleteLogic;
        }

        [HttpGet("list")]
        public IActionResult GetAllAthleteList()
        {
            return Ok(_athleteLogic.GetAllAthlete());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneAthlete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Id must be positive" });
            }
            return Ok(_athleteLogic.GetOneAthlete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAthlete(int id, UpdateAthleteModel update)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Id must be positive" });
            }
            _athleteLogic.UpdateOneAthlete(id, update);
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewAthlete(BaseAthleteCUModel athleteModel)
        {

            try
            {
                return Ok(_athleteLogic.InsertNewAthlete(athleteModel));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Unknow error happened" });
            }
        }
    }
}
