using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    List<GameObject> Crocodiles = new(6);


    private void OnDisable()
    {
        Crocodiles.Remove(gameObject);

        if (!transform.GetChild(0))
        {
            
        }

        if (!Crocodiles[3])
        {
            Crocodiles[3] = gameObject;
        }
    }
}
