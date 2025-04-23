namespace all_spice_cs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
  {
    _ingrdientsService = ingredientsService;
    _auth0Provider = auth0Provider;
  }
  private readonly IngredientsService _ingrdientsService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Ingredient>> CreateIngredient(Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Ingredient ingredient = _ingrdientsService.CreateIngredient(ingredientData);
      return Ok(ingredient);


    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);

    }
  }

}