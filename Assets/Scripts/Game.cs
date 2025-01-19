using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Recipe> recipes;
    private Recipe currentRecipe;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectRecipe(Recipe recipe)
    { // Recipe recipe
        Debug.Log("recipe selected" + recipe.name);
        currentRecipe = recipe;
    }
}
