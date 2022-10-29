using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    List<GameObject> Crocodiles = new();


    private void OnDisable()
    {
        Crocodiles.Remove(gameObject);
    }
}
