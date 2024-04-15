using System.ComponentModel.DataAnnotations;

namespace APBD5.Animals;

public class Animal {
    [Required] public int Id { get; set; }
    [Required] [MaxLength(200)] public string Name { get; set; }
    [Required] [MaxLength(200)] public string? Description { get; set; }
    [Required] [MaxLength(200)] public string Category { get; set; }
    [Required] [MaxLength(200)] public string Area { get; set; }
}