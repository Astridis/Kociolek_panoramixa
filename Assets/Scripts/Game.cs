using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // public List<Recipe> recipes;
    public Recipe currentRecipe;
    Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = Dialog.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectRecipe(Recipe recipe)
    {
        // The Recipe class inherits from XRSimpleInteractable
        // in the Recipe GameObject, add a "Select" "Interactable Event"
        // specify the "Game" GameObject, this function and that Recipe as the parameter
        string message = "recipe selected" + recipe.name +
            "\ningredients(" + recipe.ingredients.Count.ToString() + "): " + string.Join(", ", recipe.ingredients.ConvertAll<string>(ingr => ingr.name));
        dialog.Show(message);
        currentRecipe = recipe;
    }
}
