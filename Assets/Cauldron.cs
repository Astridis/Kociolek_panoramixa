using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cauldron : XRSimpleInteractable
{
    public List<GameObject> ingredients = new List<GameObject>();
    // public Game theGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addIngredient(GameObject ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void checkRecipe(Game theGameObject)
    {
        var correct = theGameObject.currentRecipe.checkRecipe(ingredients);
        Debug.Log("ingredients: " + ingredients.ToString());

        if (correct)
        {
            Debug.Log("Congratulations! Recipe Completed!");
        }
        else
        {
            Debug.Log("Recipe not completed, resetting the cauldron");
            ingredients.Clear();
            Debug.Log("ingredients: " + ingredients.ToString());
        }
    }
}
