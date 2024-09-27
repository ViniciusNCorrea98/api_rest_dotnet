using API_REST_DOTNET.Data;
using API_REST_DOTNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_rest_dot_net.Services{
    public class SuperHeroService : ISuperHeroService{

        private readonly DataContext _context;

        public SuperHeroService(DataContext context){
            
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroes(){

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetHeroById(int id){
            
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task<List<SuperHero>> AddHero(SuperHero newHero){

            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> UpdateHero(SuperHero updatedHero){
            var existingHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);

            if(existingHero == null)
                return null;
            
            existingHero.FirstName = updatedHero.FirstName;
            existingHero.LastName = updatedHero.FirstName;
            existingHero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id){
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero ==null)
                return null;
            
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
}