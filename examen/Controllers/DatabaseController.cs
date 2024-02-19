using examen.Models.DTOs;
using examen.Models.One_to_Many;
using examen.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly examenContext _examenContext;

        public DatabaseController(examenContext examenContext)
        {
            _examenContext = examenContext;
        }

        [HttpGet("Actor")]
        public async Task<IActionResult> GetActor()
        {
            return Ok(await _examenContext.ModelActorDTO.ToListAsync());
        }

        [HttpPost("AddActor")]
        public async Task<IActionResult> Create(ModelActorDTO modelActorDto)
        {
            var newModelActor = new ModelActorDTO
            {
                Id = Guid.NewGuid(),
                FirstName = modelActorDto.FirstName,
                LastName = modelActorDto.LastName,
                Age = modelActorDto.Age,
                Email = modelActorDto.Email
            };

            await _examenContext.AddAsync(newModelActor);
            await _examenContext.SaveChangesAsync();

            return Ok(newModelActor);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ModelActorDTO modelActorDto)
        {
            ModelActorDTO model1ById = await _examenContext.ModelActorDTO.FirstOrDefaultAsync(x => x.Id == modelActorDto.Id);
            if (model1ById == null)
            {
                return BadRequest("Object does not exist");
            }

            model1ById.FirstName = modelActorDto.FirstName;
            model1ById.LastName = modelActorDto.LastName;
            _examenContext.Update(model1ById);
            await _examenContext.SaveChangesAsync();

            return Ok(model1ById);
        }





    }
}
