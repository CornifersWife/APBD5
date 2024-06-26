using System.Data.SqlClient;

namespace APBD5.Animals;

public interface IAnimalRepository {
    public IEnumerable<Animal> Get(string orderBy);
    public Animal Get(int id);
    public int Create(Animal animal);
    public int Update(int id, Animal newData);
    public int Delete(int id);
}

public class AnimalRepository : IAnimalRepository {
    private readonly IConfiguration configuration;

    public AnimalRepository(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public IEnumerable<Animal> Get(string orderBy) {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand($"SELECT * FROM Animals ORDER BY {orderBy}");
        cmd.Connection = con;
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read()) {
            var animal = new Animal {
                Id = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(animal);
        }

        return animals;
    }

    public Animal Get(int id) {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand("SELECT * FROM Animals WHERE IdAnimal = @IdAnimal");
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        cmd.Connection = con;
        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        var animal = new Animal {
            Id = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString(),
        };

        return animal;
    }

    public int Create(Animal animal) {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd =
            new SqlCommand(
                "INSERT INTO Animals(Name, Description, Category, Area) " +
                "VALUES(@Name, @Description, @Category, @Area)");
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int Update(int id, Animal newData) {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd =
            new SqlCommand(
                "UPDATE Animals " +
                "SET Name = @Name, Description = @Description, Category = @Category, Area = @Area " +
                "WHERE IdAnimal = @IdAnimal");
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Name", newData.Name);
        cmd.Parameters.AddWithValue("@Description", newData.Description);
        cmd.Parameters.AddWithValue("@Category", newData.Category);
        cmd.Parameters.AddWithValue("@Area", newData.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int Delete(int id) {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand("DELETE FROM Animals WHERE IdAnimal = @IdAnimal");
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        int affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }
}