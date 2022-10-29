using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoPlay : MonoBehaviour
{
    [SerializeField] GameObject HowToPlaypanel;
    public void Openpanel()
    {
        HowToPlaypanel.SetActive(true);
    }
    public void Closepanel()
    {
        HowToPlaypanel.SetActive(false);
    }
}
