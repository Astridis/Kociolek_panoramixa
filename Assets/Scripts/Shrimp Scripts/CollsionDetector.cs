using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funkcja wywo³ywana przy kolizji
    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy nazwa obiektu to "Potion_Red"
        if (collision.gameObject.name == "Potion_Red")
        {
            Debug.Log("Potion_Red zosta³ dodany do kocio³ka!");
            // Zniszcz obiekt, z którym nast¹pi³a kolizja
            Destroy(collision.gameObject);
        }
    }
}
