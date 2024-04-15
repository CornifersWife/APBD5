using APBD5.Animals;

public interface IAnimalService {
    public IEnumerable<Animal> GetAnimals();
    public Animal GetAnimal(int animalId){}
}

public class AnimalService : IAnimalService {
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository) {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetSortedAnimals(string orderBy) {
        var animals = _animalRepository.GetAllAnimals();

        return orderBy.ToLower() switch {
            "name" => animals.OrderBy(a => a.Name),
            "description" => animals.OrderBy(a => a.Description),
            "category" => animals.OrderBy(a => a.Category),
            "area" => animals.OrderBy(a => a.Area),
            _ => animals.OrderBy(a => a.Name) // Default to 'name'
        };
    }
}