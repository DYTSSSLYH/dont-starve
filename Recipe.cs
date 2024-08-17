using System.Collections.Generic;
using System.Reflection;
using DYT;
using UnityEngine;
using UnityEngine.Assertions;

public class Ingredient
{
    public string type;
    public int amount;
    public string atlas;
        
    public Ingredient(string ingredientType, int amount, string atlas = null)
    {
        // Character ingredient multiples of 5 check only applies to health and sanity cost,
        // not max health or max sanity
        if (ingredientType == Constant.CHARACTER_INGREDIENT.HEALTH
            || ingredientType == Constant.CHARACTER_INGREDIENT.SANITY)
        {
            int x = Mathf.Abs(amount);
            // NOTE: if you changed CHARACTER_INGREDIENT_SEG, then update this assert
            Assert.IsTrue(x == 0 || x == 5,
                $"Character ingredients must be multiples of {Constant.CHARACTER_INGREDIENT_SEG}");
        }
            
        type = ingredientType;
        this.amount = amount;
        this.atlas = atlas == null ? null : Util.resolvefilepath(atlas);
    }
}

public class Recipe
{
    private static int num = 0;

    // Don't use this directly, call GetAllRecipes instead
    public static List<Recipe> Recipes = new List<Recipe>();
    public static Dictionary<string, Recipe> Common_Recipes = new Dictionary<string, Recipe>();
    public static Dictionary<string, Recipe> RoG_Recipes = new Dictionary<string, Recipe>();
    public static Dictionary<string, Recipe> Shipwrecked_Recipes = new Dictionary<string, Recipe>();
    public static Dictionary<string, Recipe> Vanilla_Recipes = new Dictionary<string, Recipe>();
    public static Dictionary<string, Recipe> Porkland_Recipes = new Dictionary<string, Recipe>();
    public static bool Recipes_Merged = false;

    private static List<string> is_character_ingredient = new List<string>();
    public static bool IsCharacterIngredient(string ingredienttype)
    {
        if (is_character_ingredient.Count <= 0)
        {
            foreach (FieldInfo fieldInfo in typeof(Constant.CHARACTER_INGREDIENT).GetFields())
                is_character_ingredient.Add((string)fieldInfo.GetValue(null));
        }

        return is_character_ingredient.Contains(ingredienttype);
    }


    public string name;
    public List<Ingredient> ingredientList;
    public List<Ingredient> characterIngredientList;
    public List<Ingredient> altIngredientList;
    public List<Ingredient> characterAltIngredientList;
    public string product;
    public Constant.RecipeTab tab;
    public string image;
    public int sortkey;
    public Constant.Tech level;
    public string placer;
    public float min_spacing;
    public bool nounlock;
    public int numtogive;
    public object wallitem;
    public bool aquatic;
    public bool decor;
    public bool flipable;
    public object distance;
    public string[] game_type;

    private static void primerecipe(Recipe recipe, string[] gametype, string name)
    {
        if (!Common_Recipes.ContainsKey(name)) Common_Recipes.Add(name, recipe);
    }
    private static void sortrecipe(Recipe recipe, string gametype, string name)
    {
        if (gametype == Constant.RECIPE_GAME_TYPE.COMMON) Common_Recipes.TryAdd(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.ROG) RoG_Recipes.Add(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.SHIPWRECKED) Shipwrecked_Recipes.Add(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.VANILLA) Vanilla_Recipes.Add(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.PORKLAND) Porkland_Recipes.Add(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.ROG) RoG_Recipes.Add(name, recipe);
        else if (gametype == Constant.RECIPE_GAME_TYPE.ROG) RoG_Recipes.Add(name, recipe);
    }
    public Recipe(string name, Ingredient[] ingredients, Constant.RecipeTab tab, Constant.Tech level = null,
        string[] game_type = null, string placer = null, float? min_spacing = 3.2f, bool? nounlock = false,
        int? numtogive = 1, bool? aquatic = false, object distance = null, bool? decor = false,
        bool? flipable = false, string image = null, object wallitem = null, object alt_ingredients = null)
    {
        this.name = name;
        ingredientList = new List<Ingredient>();
        characterIngredientList = new List<Ingredient>();
        
        foreach (Ingredient ingredient in ingredients)
        {
            if (IsCharacterIngredient(ingredient.type)) characterIngredientList.Add(ingredient);
            else ingredientList.Add(ingredient);
        }

        if (alt_ingredients != null)
        {
            Ingredient[] altIngredients = (Ingredient[])alt_ingredients;
            altIngredientList = new List<Ingredient>();
            characterAltIngredientList = new List<Ingredient>();
        
            foreach (Ingredient altIngredient in altIngredients)
            {
                if (IsCharacterIngredient(altIngredient.type)) characterAltIngredientList.Add(altIngredient);
                else altIngredientList.Add(altIngredient);
            }
        }

        product = name;
        this.tab = tab;

        this.image = image == null ? name : image;

        int? oldsortkey = null;
        if (Common_Recipes.ContainsKey(name)) oldsortkey = Common_Recipes[name].sortkey;
        else if (RoG_Recipes.ContainsKey(name)) oldsortkey = RoG_Recipes[name].sortkey;
        else if (Shipwrecked_Recipes.ContainsKey(name)) oldsortkey = Shipwrecked_Recipes[name].sortkey;
        else if (Vanilla_Recipes.ContainsKey(name)) oldsortkey = Vanilla_Recipes[name].sortkey;
        else if (Porkland_Recipes.ContainsKey(name)) oldsortkey = Porkland_Recipes[name].sortkey;

        sortkey = oldsortkey.HasValue ? oldsortkey.Value : num;
        this.level = level == null ? new Constant.Tech() : level;

        this.placer = placer;
        this.min_spacing = min_spacing.GetValueOrDefault(3.2f);
        this.nounlock = nounlock.GetValueOrDefault(false);
        this.numtogive = numtogive.GetValueOrDefault(1);
        this.wallitem = wallitem;
        
        this.aquatic = aquatic.GetValueOrDefault(false);
        // decor has it's own placeable test functions.
        this.decor = decor.GetValueOrDefault(false);
        // decor has it's own placeable test functions.
        this.flipable = flipable.GetValueOrDefault(false);
        this.distance = distance;

        num += 1;

        this.game_type = game_type == null ? new [] { Constant.RECIPE_GAME_TYPE.COMMON } : game_type;
        
        primerecipe(this, this.game_type, name);
        
        foreach (string gameType in this.game_type) sortrecipe(this, gameType, name);
    }
}

public class DeconstructRecipe : Recipe
{
    public bool is_deconstruction_recipe;
    
    public DeconstructRecipe(string name, Ingredient[] return_ingredients)
        : base(name, return_ingredients, null, Constant.TECH.NONE)
    {
        is_deconstruction_recipe = true;
        nounlock = true;
    }
}