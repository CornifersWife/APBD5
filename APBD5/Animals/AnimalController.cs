namespace APBD5.Animals;

public class AnimalController {
    public static void RegisterEndpointsForAnimals(this IEndpointRouteBuilder app) {
        app.MapGet("/api/animals", (IAnimalRepository service) => {
        });
        
        app.MapGet("/api/animals/{id::int}", (int id,IAnimalRepository service) => {
        });
        
        app.MapPut("/api/v1/animals", (Animal newAnimal, IAnimalRepository service) => {
        });

        app.MapDelete("/api/v1/animals", (int id,IAnimalRepository service) => {
        });
        app.MapPost("/api/v1/animals", (Animal newAnimal,IAnimalRepository service) => {
        });
    }
}