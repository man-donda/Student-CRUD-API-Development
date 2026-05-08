using System.ComponentModel.DataAnnotations;

public class Student
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string City { get; set; }
}