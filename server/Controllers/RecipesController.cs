namespace all_spice_cs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, RecipesRepository recipesRepository)
  {
    _reciepesService = recipesService;
    _auth0Provider = auth0Provider;


  }
  private readonly RecipesService _reciepesService;
  private readonly Auth0Provider _auth0Provider;




  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _reciepesService.CreateRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetRecipes()
  {
    try
    {
      List<Recipe> recipes = _reciepesService.GetRecipes();
      return Ok(recipes);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _reciepesService.GetRecipeById(recipeId);
      return Ok(recipe);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }
}

