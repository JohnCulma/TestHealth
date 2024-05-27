using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Presentation;
using Presentation.UserDTO;

namespace ITHealthNet7.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[EnableCors("Cors")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public UserController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<object> GetUser([FromBody] GetUserDto getUserDto )
        {
            var usu = await context.patients.Where(x => x.PatientID.Equals(getUserDto.Id)).FirstOrDefaultAsync();

            return usu;
        }

        [HttpPost]
        public async Task<object> CreateUser([FromBody] CreateUserDto createUserDto)
        {

            var usuCreate = mapper.Map<Patients>(createUserDto);

            usuCreate.FirstName = createUserDto.FirstName;
            usuCreate.LastName = createUserDto.LastName;
            usuCreate.BirthDate = Convert.ToDateTime(createUserDto.BirthDate);
            usuCreate.Gender = createUserDto.Gender;
            usuCreate.Address = createUserDto.Address;
            usuCreate.ContactNumber = createUserDto.ContactNumber;

            context.Add(usuCreate);
            await context.SaveChangesAsync();

            return Created("", new General
            {
                Titulo = "Pacientes",
                Estado = 201,
                Mensaje = "Paciente creado",
                OtrosDatos = ""

            });

        }

        [HttpPut]
        public async Task<object> UpdateUser([FromBody] UpdateDto deleteUserDto)
        {

            try
            {
                var existe = await context.patients.AnyAsync(x => x.PatientID.Equals(deleteUserDto.Id));

                if (!existe)
                {
                    return NotFound();
                }

                var data = mapper.Map<Patients>(deleteUserDto);

                data.FirstName = deleteUserDto.FirstName;
                data.LastName = deleteUserDto.LastName;
                data.BirthDate = Convert.ToDateTime(deleteUserDto.BirthDate);
                data.Gender = deleteUserDto.Gender;
                data.Address = deleteUserDto.Address;
                data.ContactNumber = deleteUserDto.ContactNumber;

                context.Update(data);

                await context.SaveChangesAsync();

                return Ok(new General
                {
                    Titulo = "Pacientes",
                    Estado = 200,
                    Mensaje = "Paciente actualizado",
                    OtrosDatos = ""
                });
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpDelete]
        public async Task<object> DeleteUser([FromBody] DeleteUserDto deleteUserDto)
        {

            try
            {

                var usuDelete = await context.patients.Where(x => x.PatientID.Equals(deleteUserDto.Id)).FirstAsync();

                if (usuDelete is null)
                {
                    return NoContent();
                }

                context.Remove(usuDelete);
                await context.SaveChangesAsync();

                return Ok(new General
                {
                    Titulo = "Pacientes",
                    Estado = 200,
                    Mensaje = "Paciente elminado",
                    OtrosDatos = ""
                });
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
