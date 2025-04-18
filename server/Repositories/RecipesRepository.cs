



namespace all_spice_cs.Repositories;

public class RecipesRepository
{
  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    Insert INTO 
    recipes(title, instructions, img, category, creator_id)
    VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    INNER JOIN accounts ON accounts.id = recipes.creator_id
    Where recipes.id = LAST_INSERT_ID();";

    Recipe createdRecipe = _db.Query(sql, (Recipe recipe, Account account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).SingleOrDefault();
    return createdRecipe;
  }

  internal List<Recipe> GetRecipes()
  {
    string sql = @"
    select recipes.*,
     accounts.*
      FROM recipes 
      INNER JOIN accounts ON accounts.id = recipes.creator_id";
    List<Recipe> recipes = _db.Query(sql, (Recipe recipe, Account account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();
    return recipes;

  }

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
   SELECT recipes.*,
    accounts.*
     FROM recipes
      INNER JOIN accounts ON accounts.id = recipes.creator_id
       WHERE recipes.id = @recipeId;";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Account account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { recipeId }).SingleOrDefault();
    return recipe;
  }

  internal void UpdateRecipe(Recipe recipe)
  {
    string sql = @"
UPDATE recipes
 SET 
 title = @Title,
  instructions = @Instructions,
   img = @Img
    WHERE id = @Id
     LIMIT 1;";

    int rowsAffected = _db.Execute(sql, recipe);
    if (rowsAffected == 0)
    {
      throw new Exception("NO ROWS WERE UPDATED");
    }
    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + "ROWS WERE UPDATED THATS NOT GOOD");
    }
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = @"DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { recipeId });
    if (rowsAffected == 0)
    {
      throw new Exception("NO ROWS WERE DELETED");
    }
    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + "ROWS WERE DELETED AND THATS BAD SHAQ SAYS ");
    }
  }
}