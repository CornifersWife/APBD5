using Microsoft.AspNetCore.Mvc;

namespace APBD5.Animals;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase {
    private readonly IConfiguration configuration;
    private IAnimalService animalService;

    public AnimalController(IConfiguration configuration, IAnimalService animalService) {
        this.configuration = configuration;
        this.animalService = animalService;
    }
    
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name") {
        var animals = animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpGet("{id::int}")]
    public IActionResult GetAnimal(int id) {
        var animal = animalService.GetAnimal(id);
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal) {
        animalService.AddAnimal(animal);
        return Created();
    }

    [HttpPut("{id::int}")]
    public IActionResult UpdateAnimal(int id, [FromBody]Animal newAnimalData) {
        animalService.UpdateAnimal(id, newAnimalData);
        return Ok($"Updated animal with id {id}");
    }

    [HttpDelete("{id::int}")]
    public IActionResult RemoveAnimal(int id) {
        animalService.RemoveAnimal(id);
        return NoContent();
    }
}