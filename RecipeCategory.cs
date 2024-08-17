public class RecipeCategory : Recipe
{
    public Constant.RecipeTab subcategory;
    public bool skipCategoryCheck;
    public object tooltip;
    
    
    public RecipeCategory(string name, Constant.RecipeTab category, Constant.RecipeTab tab,
        Constant.Tech level = null, string[] game_type = null, string image = null, object tooltip = null)
        : base(name, new Ingredient[]{}, tab, level, game_type,
            null, null, true, null, null, null, null, null, image)
    {
        subcategory = category;
        skipCategoryCheck = false;
        this.tooltip = tooltip;
    }
}