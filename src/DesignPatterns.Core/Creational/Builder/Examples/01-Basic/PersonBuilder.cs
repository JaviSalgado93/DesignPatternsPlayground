namespace DesignPatterns.Core.Creational.Builder.Examples._01_Basic;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"Person: {FirstName} {LastName}, Age: {Age}, Email: {Email}, Phone: {Phone}, Address: {Address}";
    }
}

/// <summary>
/// Builder fluent para crear Person sin constructor complejo
/// </summary>
public class PersonBuilder
{
    private Person _person = new();

    public PersonBuilder WithFirstName(string firstName)
    {
        _person.FirstName = firstName;
        return this;
    }

    public PersonBuilder WithLastName(string lastName)
    {
        _person.LastName = lastName;
        return this;
    }

    public PersonBuilder WithAge(int age)
    {
        _person.Age = age;
        return this;
    }

    public PersonBuilder WithEmail(string email)
    {
        _person.Email = email;
        return this;
    }

    public PersonBuilder WithPhone(string phone)
    {
        _person.Phone = phone;
        return this;
    }

    public PersonBuilder WithAddress(string address)
    {
        _person.Address = address;
        return this;
    }

    public Person Build()
    {
        return _person;
    }
}