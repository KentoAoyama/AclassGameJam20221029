using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaniwaniDestroy : MonoBehaviour
{
    private void WaniDestroy()
    {
        Destroy(this.gameObject);
        CrocodileSpawner.crocodileCount--;
    }
}
