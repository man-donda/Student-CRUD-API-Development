namespace StudentManagementApi.Models
{
    public class CreateStudentDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string City { get; set; }
    }
}
