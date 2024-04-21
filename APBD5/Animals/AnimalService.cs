namespace APBD5.Animals;

public interface IAnimalService {
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public Animal GetAnimal(int id);
    public void AddAnimal(Animal animal);
    public void UpdateAnimal(int id, Animal newAnimal);
    public void RemoveAnimal(int id);
}

public class AnimalService : IAnimalService {
    private readonly IAnimalRepository animalRepository;

    public AnimalService(IAnimalRepository animalRepository) {
        this.animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy = "name") {
        var animals = animalRepository.Get(orderBy);
        return animals;
    }

    public Animal GetAnimal(int id) {
        var animal = animalRepository.Get(id);
        return animal;
    }

    public void AddAnimal(Animal animal) {
        animalRepository.Create(animal);
    }

    public void UpdateAnimal(int id, Animal newAnimal) {
        animalRepository.Update(id, newAnimal);
    }

    public void RemoveAnimal(int id) {
        animalRepository.Delete(id);
    }
}