using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICY.Home.API.Models;

namespace ICY.Home.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly GerenciadorDeTimesPokemonContext _context;

        public PokemonController(GerenciadorDeTimesPokemonContext context)
        {
            _context = context;
        }

        // GET: api/Pokemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemons>>> GetPokemons()
        {
            return await _context.Pokemons.ToListAsync();
        }

        // GET: api/Pokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemons>> GetPokemons(int id)
        {
            var pokemons = await _context.Pokemons.FindAsync(id);

            if (pokemons == null)
            {
                return NotFound();
            }

            return pokemons;
        }

        // PUT: api/Pokemon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemons(int id, Pokemons pokemons)
        {
            if (id != pokemons.id)
            {
                return BadRequest();
            }

            _context.Entry(pokemons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pokemon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pokemons>> PostPokemons(Pokemons pokemons)
        {
            _context.Pokemons.Add(pokemons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokemons", new { id = pokemons.id }, pokemons);
        }

        // DELETE: api/Pokemon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemons(int id)
        {
            var pokemons = await _context.Pokemons.FindAsync(id);
            if (pokemons == null)
            {
                return NotFound();
            }

            _context.Pokemons.Remove(pokemons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonsExists(int id)
        {
            return _context.Pokemons.Any(e => e.id == id);
        }
    }
}
