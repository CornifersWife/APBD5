using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Animals;

[Route("api/[controller]")]
public class AnimalController : ControllerBase {
    private readonly IConfiguration configuration;
    private readonly IAnimalRepository animalRepository;

    public AnimalController(IConfiguration configuration, IAnimalRepository animalRepository) {
        this.configuration = configuration;
        this.animalRepository = animalRepository;
    }

    [HttpGet]
    public IEnumerable<Animal> GetAnimals(string? orderBy) {
        orderBy ??= "name";
        switch (orderBy) {
            case "name": break;
            case "description": break;
            case "category": break;
            case "area": break;
            default:
                orderBy = "name";
                break;
        }

        var animals = new List<Animal>();
        using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"))) {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"select * from animal order by {orderBy}";
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read()) {
                animals.Add(new Animal {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Category = reader.GetString(3),
                    Area = reader.GetString(4)
                });
            }

            return Ok(animals);
        }
    }
}