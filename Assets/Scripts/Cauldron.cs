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
        if ((bool)ingredients.Find(ingr => ingr == ingredient))
        {
            Debug.Log("it was already in the cauldron");
            return;
        }
        ingredients.Add(ingredient);
    }


    public void checkRecipe(Game theGameObject)
    {
        Debug.Log("ingredients(" + ingredients.Count.ToString() + "): " + ingredients.ToString());

        var correct = false;

        if (theGameObject.currentRecipe)
        {
            correct = theGameObject.currentRecipe.checkRecipe(ingredients);
        }
        else
        {
            Debug.Log("No recipe has been selected!");
            return;
        }

        if (correct)
        {
            Debug.Log("Congratulations! Recipe Completed!");
        }
        else
        {
            Debug.Log("Recipe not completed, resetting the cauldron");
            ingredients.Clear();
        }
    }
}
