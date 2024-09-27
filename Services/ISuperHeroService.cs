using API_REST_DOTNET.Entities;

//Este arquivo define a interface para o serviço de super-heróis. Ele contém a assinatura dos métodos que a classe de serviço deverá implementar, separando a lógica de negócios da API.

namespace API_REST_DOTNET.Services{
    public interface ISuperHeroService{
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetHeroById(int id);
        Task<List<SuperHero>> AddHero(SuperHero newHero);
        Task<List<SuperHero>?> UpdateHero(SuperHero updatedHero)
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}