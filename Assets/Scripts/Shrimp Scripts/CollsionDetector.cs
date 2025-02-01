using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetector : MonoBehaviour
{
    public Cauldron cauldron;
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

    // Funkcja wywolywana przy kolizji
    private void OnCollisionEnter(Collision collision)
    {
        // is the bottle uncorked?
        BottleShake bottle = collision.gameObject.GetComponent<BottleShake>();
        if (bottle && bottle.isGrabbed == false)
        {
            if (bottle.corkPopped)
            {
                dialog.Show(collision.gameObject.name + " zostal dodany do kociolka!");
                cauldron.addIngredient(collision.gameObject);
                bottle.resetBottleShake();
                return;
            }
            else
            {
                dialog.Show("you must shake the bottle to uncork it!");
                bottle.resetBottleShake();
                return;
            }
        }

        RadishCut radishCut = collision.gameObject.GetComponent<RadishCut>();
        if (radishCut && radishCut.isGrabbed == false)
        {
            dialog.Show(collision.gameObject.name + " zostal dodany do kociolka!");
            cauldron.addIngredient(collision.gameObject);
            radishCut.resetRadish();
            return;
        }

        CuttableObject radish = collision.gameObject.GetComponent<CuttableObject>();
        if (radish && radish.isGrabbed == false)
        {
            dialog.Show("you must cut the radish to add it to the cauldron!");
            // cauldron.addIngredient(collision.gameObject);
            radish.resetRadish();
            return;
        }

        PotionRed potionRed = collision.gameObject.GetComponent<PotionRed>();
        if (potionRed && potionRed.isGrabbed == false)
        {
            dialog.Show(collision.gameObject.name + " zostal dodany do kociolka!");
            cauldron.addIngredient(collision.gameObject);
            potionRed.resetPotionRed();
            return;
        }
        dialog.Show(collision.gameObject.name + " nie może zostać dodany do kociołka!");
    }
}
