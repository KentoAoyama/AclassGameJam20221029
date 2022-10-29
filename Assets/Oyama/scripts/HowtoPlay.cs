using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoPlay : MonoBehaviour
{
    [SerializeField] GameObject HowToPlaypanel;
    // Start is called before the first frame update
    public void Openpanel()
    {
        HowToPlaypanel.SetActive(true);
    }
}
