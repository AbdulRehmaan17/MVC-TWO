using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Models
{
    public class Student
    {
        [Key]
        [BindProperty]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
