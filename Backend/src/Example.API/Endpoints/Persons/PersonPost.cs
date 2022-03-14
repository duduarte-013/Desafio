using Example.Application.ExampleService.Models.Request;
using Example.Domain.Persons;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Endpoints.Persons
{
    public class PersonPost
    {
        public static string Template => "/Persons";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(PersonRequest personRequest, HttpContext http, ApplicationDbContext context)
        {
            var city = await context.Cities.FirstOrDefaultAsync(c => c.Id == personRequest.CityId);
            var person =
                new Person(personRequest.Name, personRequest.Cpf, city, personRequest.Age);

            if (!person.IsValid)
            {
                return Results.BadRequest();
            }

            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();

            return Results.Created($"/persons/{person.Id}", person.Id);
        }
    }
}
