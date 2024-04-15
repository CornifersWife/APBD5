using System.ComponentModel.DataAnnotations;

namespace APBD5.Animals;

public class Animal {
    public static int id { get; private set; }
    [MaxLength(200)]
    public string Name;
    [MaxLength(200)]
    public string? Description;
    [MaxLength(200)]
    public string Category;
    [MaxLength(200)]
    public string Area;

    
}