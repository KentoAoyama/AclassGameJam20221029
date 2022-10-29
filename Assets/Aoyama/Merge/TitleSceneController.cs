using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;

    void Start()
    {
        _fadeSystem.StartFadeIn();
    }
}
