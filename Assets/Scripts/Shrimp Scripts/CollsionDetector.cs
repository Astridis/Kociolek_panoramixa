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

    // Funkcja wywo�ywana przy kolizji
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy nazwa obiektu to "Potion_Red"
        if (collision.gameObject.name == "Potion_Red" || collision.gameObject.name == "RaddishCut")
        {
            Debug.Log(collision.gameObject.name + " zosta� dodany do kocio�ka!");
            // Zniszcz obiekt, z kt�rym nast�pi�a kolizja
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            cauldron.addIngredient(collision.gameObject);
        }
        else
        {
            Debug.Log(collision.gameObject.name + " nie może zostać dodany do kociołka!");
        }
    }
}
