namespace StudentManagementApi.Models
{
    public class UpdateStudentDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string City { get; set; }
    }
}
