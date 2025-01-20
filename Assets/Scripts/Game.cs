using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // public List<Recipe> recipes;
    public Recipe currentRecipe;

    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("recipe selected" + recipe.name);
        currentRecipe = recipe;
    }
}
