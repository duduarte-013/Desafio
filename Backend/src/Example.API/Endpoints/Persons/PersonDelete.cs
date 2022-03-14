using Example.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Endpoints.Persons
{
    public class PersonDelete
    {
         public static string Template => "/persons/{id:int}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;


        public static async Task<IResult> Action(
            [FromRoute] int id, HttpContext http ,ApplicationDbContext context)
        {
           var person = await context.Persons.FindAsync(id);
            if (person == null)
                return Results.NotFound();

            context.Remove(person);
       
            await context.SaveChangesAsync();

            return Results.Ok();




        }
    }
}


        
    
