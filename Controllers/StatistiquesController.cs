using ECF.Models;
using ECF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECF.Controllers
{
    [Route("api/statistiques")]
    public class StatistiquesController : ControllerBase
    {
        private readonly StatistiquesService _statistiquesService;

        public StatistiquesController(StatistiquesService statistiquesService) =>
            _statistiquesService = statistiquesService;

        [HttpGet]
        public async Task<List<Statistiques>> Get() =>
            await _statistiquesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Statistiques>> Get(string id)
        {
            var statistique = await _statistiquesService.GetAsync(id);

            if (statistique is null)
            {
                return NotFound();
            }

            return statistique;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Statistiques newstatistique)
        {
            await _statistiquesService.CreateAsync(newstatistique);

            return CreatedAtAction(nameof(Get), new { id = newstatistique.Id }, newstatistique);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Statistiques updatedstatistique)
        {
            var statistique = await _statistiquesService.GetAsync(id);

            if (statistique is null)
            {
                return NotFound();
            }

            updatedstatistique.Id = statistique.Id;

            await _statistiquesService.UpdateAsync(id, updatedstatistique);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var statistique = await _statistiquesService.GetAsync(id);

            if (statistique is null)
            {
                return NotFound();
            }

            await _statistiquesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
