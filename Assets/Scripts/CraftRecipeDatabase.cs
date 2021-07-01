using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour {
    public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private ItemDatabase v_itemDatabase;

    private void Awake()
    {
        v_itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecipeDatabase();
    }

    public Item CheckRecipe(int[] recipe)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            // Se compara la secuencia de la receta con la lista de items en la crafting table
            // Se ordenan ambos lados de menor a mayor para que no importa el orden de los items a craftear
            if (craftRecipe.requiredItems.OrderBy(i => i).SequenceEqual(recipe.OrderBy(i => i)))
            {
                return v_itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }

    void BuildCraftRecipeDatabase()
    {
        recipes = new List<CraftRecipe>()
        {
            new CraftRecipe(4,
            new int[]{
                1,2
                }),
            new CraftRecipe(5,
            new int[]{
                2,3
                })
        };
    }
}
