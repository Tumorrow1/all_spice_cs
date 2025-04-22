import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js";
import { AppState } from "@/AppState.js";


class RecipesService {



  async getRecipes() {
    console.log(`getting recipes`)
    const response = await api.get(`api/recipes`)
    logger.log(`got recipes`, response.data);
    const recipes = response.data.map(pojo => new Recipe(pojo))
    AppState.recipes = recipes

  }

  setActiveRecipe(recipe) {
    AppState.activeRecipe = recipe
  }

}
export const recipesService = new RecipesService()