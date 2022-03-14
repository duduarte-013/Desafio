using Example.Application.ExampleService.Models.Response.Person;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Endpoints.Persons
{
    public class PersonGetAll
    {

        public static string Template => "/persons";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(ApplicationDbContext context)
        {
            var persons = context.Persons.Include(p => p.City).OrderBy(p => p.Name).ToList();
            var results = persons.Select(p => new PersonResponse(p.Id,p.Name, p.Cpf, p.City.Name, p.Age));
            return Results.Ok(results);
        }
    }
}
