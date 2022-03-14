using Example.Application.ExampleService.Models.Request;
using Example.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Endpoints.Persons
{
    public class PersonPut
    {
            public static string Template => "/persons/{id:int}";
            public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
            public static Delegate Handle => Action;

          
            public static async Task<IResult> Action(
                [FromRoute] int id, HttpContext http, PersonRequest personRequest, ApplicationDbContext context)
            {
            var city = await context.Cities.FirstOrDefaultAsync(c => c.Id == personRequest.CityId);
            var person = context.Persons.Where(c => c.Id == id).FirstOrDefault();

                if (person == null)
                    return Results.NotFound();

            person.EditInfo(personRequest.Name, personRequest.Cpf, city, personRequest.Age);

            if (!person.IsValid)
                return Results.BadRequest();

                await context.SaveChangesAsync();

                return Results.Ok();
            }
        }
}
