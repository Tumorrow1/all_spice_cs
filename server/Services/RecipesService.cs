


namespace all_spice_cs.Services;

public class RecipesService
{
  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }

  private readonly RecipesRepository _repository;


  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetRecipes()
  {
    List<Recipe> recipes = _repository.GetRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);
    if (recipe == null)
    {
      throw new Exception($"No Recipe found with the ID of {recipeId}");
    }
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, Recipe recipeData, Account userInfo)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO UPDATE SHAQS RECIPE, {userInfo.Name.ToUpper()}");
    }

    recipe.Instructions = recipeData.Instructions ?? recipe.Instructions;
    recipe.Title = recipeData.Title ?? recipe.Title;
    _repository.UpdateRecipe(recipe);
    return recipe;
  }

  internal string DeleteRecipe(int recipeId, Account userInfo)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.Creator.Id != userInfo.Id)
    {
      throw new Exception($"SHAQ SAID NO TO DELETEING SOMEONE ELSES RECIPE, {userInfo.Name.ToUpper()}");
    }
    _repository.DeleteRecipe(recipeId);
    return $"your {recipe.Title} has been deleted!";
  }
}