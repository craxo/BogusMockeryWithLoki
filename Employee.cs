using Bogus;

namespace Employee;

public static class EmployeeExtensions
{
    public static EmployeeInfo GetBogusEmployee()
    {
        var faker = new Faker<EmployeeInfo>()
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Gender, f => f.PickRandom<Gender>())
            .RuleFor(e => e.Age, f => f.Random.Int(18, 67))
            .Generate();

        return faker;
    }
}

public class EmployeeInfo
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender {get; set; }
    public int? Age { get; set; }
}

public enum Gender
{
    Male,
    Female,
    ApacheAttackHelicopter
}