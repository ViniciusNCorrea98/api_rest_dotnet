[ApiController]
[Route('api/[controller]')]
public class SuperHeroController : ControllerBase {
    private readonly DataContext _context;


    public SuperHeroController(dataContext context){
        _context = context
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get(){
        
        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id){

        var hero = await _context.SuperHeroes.FindAsync(id);
        if(hero == null)
            return NotFound();

        return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero){

        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return Ok(await _context.SuperHeroes.ToListAsync();)
    }


    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero){

        var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);

        if (dbHero == null)
            return NotFound();
        
        dbHero.FirstName = hero.FirstName;
        dbHero.LastName = hero.LastName;
        dbHero.Place = hero.Place;

        await _context.SaveChangesAsync();
        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id){

        var dbHero = await _context.SuperHeroes.FindAsync(id);
        if(dbHero == null)
            return NotFound();
        
        _context.SuperHeroes.Remove(dbHero);

        await _context.SaveChangesAsync();
        return Ok(await _context.SuperHeroes.ToListAsync();)
    }
}