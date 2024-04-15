using System.Data.SqlClient;
using APBD5.Animals;

public interface IAnimalRepository {
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public Animal GetAnimal(int animalId);
    public void AddAnimal(Animal animal);
    public void ChangeAnima(int animalId, Animal newAnimalData);
    public void removeAnimal(int animalId);
}

public class AnimalRepository : IAnimalRepository {
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration) {
        _configuration = configuration;
    }
    

    public IEnumerable<Animal> GetAnimals(string orderBy) {
        var animals = new List<Animal>();
        string query = $"SELECT * FROM Animals ORDER BY {orderBy}";

        using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("Default"))) {
            sqlConnection.Open();
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT * FROM Animals ORDER BY {orderBy}";
                using (var reader = sqlCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        animals.Add(new Animal {
                            Name = reader.GetString("Name"),
                            Age = reader.GetInt32("Age"),
                            Type = reader.GetString("Type")
                        });
                    }
                
            }
        }
        return animals;
    }

    public Animal GetAnimal(int animalId) {
        throw new NotImplementedException();
    }

    public void AddAnimal(Animal animal) {
        throw new NotImplementedException();
    }

    public void ChangeAnima(int animalId, Animal newAnimalData) {
        throw new NotImplementedException();
    }

    public void removeAnimal(int animalId) {
        throw new NotImplementedException();
    }
}