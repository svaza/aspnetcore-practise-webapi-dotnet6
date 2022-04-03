using Microsoft.AspNetCore.Mvc;
using practise_api.Filters;
using practise_api.Models;
using practise_api.Services;

namespace practise_api.Controllers;

[ApiController]
[Route("[controller]")]
[TypeFilter(typeof(SampleActionFilter))]
public class PizzaController : ControllerBase
{
  public PizzaController()
  {
  }

  // GET all action
  [HttpGet]
  public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

  // GET by Id action
  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);
    if (pizza == null)
      return NotFound();

    return pizza;
  }

  // POST action
  [HttpPost]
  public IActionResult Create(Pizza pizza)
  {
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { pizza.Id }, pizza);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
      return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if (existingPizza is null)
      return NotFound();

    PizzaService.Update(pizza);

    return NoContent();
  }

  // DELETE action
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza is null)
      return NotFound();

    PizzaService.Delete(id);

    return NoContent();
  }
}