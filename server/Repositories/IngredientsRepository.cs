
namespace all_spice_cs.Repositories;

public class IngredientsRepository
{
  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
   INSERT INTO ingredients(name, quantity, id, recipe_id )
    VALUES(@Name, @Quantity, @Id, @RecipeId);
    
    SELECT *
     FROM ingredients 
     where id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query(sql, ingredientData).SingleOrDefault();
    return ingredient;
  }
}