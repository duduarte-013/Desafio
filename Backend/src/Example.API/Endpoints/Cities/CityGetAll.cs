using Example.Application.ExampleService.Models.Response.City;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Endpoints.Cities
{
    public class CityGetAll
    {
        public static string Template => "/cities";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var cities = context.Cities.ToList();
            var response = cities.Select(c => new CityResponse(c.Id, c.Name, c.Uf));

            return Results.Ok(response);
        }
    }
}

