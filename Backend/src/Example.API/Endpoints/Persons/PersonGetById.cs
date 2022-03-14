using Example.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Endpoints.Persons
{
    public class PersonGetById
    {

        public static string Template => "/persons/{id:int}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action(
            [FromRoute] int id, HttpContext http, ApplicationDbContext context)
        {
            
            var person = context.Persons.Where(c => c.Id == id).FirstOrDefault();

            if (person == null)
                return Results.NotFound();

            return Results.Ok(person);
        }
    }
}
