using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cauldron : XRSimpleInteractable
{
    public List<GameObject> ingredients = new List<GameObject>();
    // public Game theGameObject;
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

    public void addIngredient(GameObject ingredient)
    {
        if ((bool)ingredients.Find(ingr => ingr == ingredient))
        {
            dialog.Show("it was already in the cauldron");
            return;
        }
        ingredients.Add(ingredient);
    }


    public void checkRecipe(Game theGameObject)
    {
        string message = "ingredients(" + ingredients.Count.ToString() + "): " + string.Join(", ", ingredients.ConvertAll<string>(ingr => ingr.name));

        var correct = false;

        if (theGameObject.currentRecipe)
        {
            correct = theGameObject.currentRecipe.checkRecipe(ingredients);
        }
        else
        {
            dialog.Show(message + "\n" + "No recipe has been selected!");
            return;
        }

        if (correct)
        {
            dialog.Show(message + "\n" + "Congratulations! Recipe Completed!");
            ingredients.Clear();
        }
        else
        {
            dialog.Show(message + "\n" + "Recipe not completed, resetting the cauldron");
            ingredients.Clear();
        }
    }
}
