using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoyamaTest : MonoBehaviour
{    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ScoreSystem.AddScore(1);
        }
    }
}
