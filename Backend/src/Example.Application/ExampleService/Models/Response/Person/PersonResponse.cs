using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Models.Response.Person
{
    public record PersonResponse(int id, string Name, string Cpf, string CityName, int Age);
}
