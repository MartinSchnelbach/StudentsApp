using System.ComponentModel.DataAnnotations;


namespace StudentsCRUDApp.Models.Student
{
    public class InputStudents
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Lastn { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public int Score { get; set; }
    }
}
