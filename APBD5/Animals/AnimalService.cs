namespace APBD5.Animals;

public interface IAnimalService {
    public IEnumerable<Animal> GetAnimals(string? orderBy);
    public Animal? GetAnimal(int id);
    public int AddAnimal(Animal animal);
    public int UpdateAnimal(int id, Animal newAnimal);
    public int RemoveAnimal(int id);
}

public class AnimalService : IAnimalService {
    private readonly IAnimalRepository animalRepository;

    public AnimalService(IAnimalRepository animalRepository) {
        this.animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string? orderBy) {
        orderBy ??= "name";
        orderBy = orderBy.ToLower();
        switch (orderBy) {
            case "idanimal": break;
            case "animalid":
            case "id":
                orderBy = "idanimal";
                break;
            case "name": break;
            case "description": break;
            case "category": break;
            case "area": break;
            default:
                orderBy = "name";
                break;
        }

        var animals = animalRepository.Get(orderBy);
        return animals;
    }

    public Animal? GetAnimal(int id) {
        var animal = animalRepository.Get(id);
        return animal;
    }

    public int AddAnimal(Animal animal) {
        return animalRepository.Create(animal);
    }

    public int UpdateAnimal(int id, Animal newAnimal) {
        var affectedCount = animalRepository.Update(id, newAnimal);
        if (affectedCount < 1)
            throw new ArgumentException("No animal with such id");
        return affectedCount;
    }

    public int RemoveAnimal(int id) {
        var affectedCount = animalRepository.Delete(id);
        if (affectedCount < 1)
            throw new ArgumentException("No animal with such id");
        return affectedCount;
    }
}