using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Recipe : XRSimpleInteractable
{
    public List<GameObject> ingredients = new List<GameObject>();
    // public List<GameObject> ingredientsUsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void addIngredient(GameObject ingredient)
    // {
    //     Debug.Log("adding:" + ingredient.name);
    //     ingredientsUsed.Add(ingredient);
    // }

    public bool checkRecipe(List<GameObject> ingredientsUsed)
    {
        // var secondNotFirst = ingredientsUsed.Except(ingredients).ToList();

        var correct = true;

        foreach (GameObject go in ingredients)
        {
            correct = correct && ((Boolean)ingredientsUsed.Find(goUsed => goUsed == go));
        }
        foreach (GameObject goUsed in ingredientsUsed)
        {
            correct = correct && ((Boolean)ingredients.Find(go => go == goUsed));
        }
        return correct;
    }
}
