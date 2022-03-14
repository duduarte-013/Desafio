using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Example.Domain.Persons;

public class Person: Notifiable<Notification>
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public int CityId { get; private set; }
    public City City { get; private set; }
    public int Age { get; private set; }

    private Person() { }

    public Person(string name, string cpf, City city, int age)
    {
        Name = name;
        Cpf = cpf;
        City = city;
        Age = age;

    }

    private void Validate()
    {
        var contract = new Contract<Person>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsNotNullOrEmpty(Cpf, "Cpf")
            .IsNotNull(City, "City", "City not found");
            AddNotifications(contract);
    }

    public void EditInfo(string name, string cpf, City city, int age)
    {


        Name = name;
        Cpf = cpf;
        City = city;
        Age = age;

        Validate();
    }
}





