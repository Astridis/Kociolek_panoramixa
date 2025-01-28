using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetector : MonoBehaviour
{
    public Cauldron cauldron;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Funkcja wywolywana przy kolizji
    private void OnCollisionEnter(Collision collision)
    {
        // is the bottle uncorked?
        BottleShake bottle = collision.gameObject.GetComponent<BottleShake>();
        if (bottle && bottle.isGrabbed == false)
        {
            if (bottle.corkPopped)
            {
                Debug.Log(collision.gameObject.name + " zostal dodany do kociolka!");
                cauldron.addIngredient(collision.gameObject);
                bottle.resetBottleShake();
                return;
            }
            else
            {
                Debug.Log("you must shake the bottle to uncork it!");
                bottle.resetBottleShake();
            }
        }

        RadishCut radishCut = collision.gameObject.GetComponent<RadishCut>();
        if (radishCut && radishCut.isGrabbed == false)
        {
            Debug.Log(collision.gameObject.name + " zostal dodany do kociolka!");
            cauldron.addIngredient(collision.gameObject);
            radishCut.resetRadish();
            return;
        }

        CuttableObject radish = collision.gameObject.GetComponent<CuttableObject>();
        if (radish && radish.isGrabbed == false)
        {
            Debug.Log("you must cut the radish to add it to the cauldron!");
            // cauldron.addIngredient(collision.gameObject);
            radish.resetRadish();
            return;
        }

        PotionRed potionRed = collision.gameObject.GetComponent<PotionRed>();
        if (potionRed && potionRed.isGrabbed == false)
        {
            Debug.Log(collision.gameObject.name + " zostal dodany do kociolka!");
            cauldron.addIngredient(collision.gameObject);
            potionRed.resetPotionRed();
            return;
        }
        Debug.Log(collision.gameObject.name + " nie może zostać dodany do kociołka!");
    }
}
