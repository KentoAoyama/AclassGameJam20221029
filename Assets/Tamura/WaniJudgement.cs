using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ワニが出てきてるか判定してくれる</summary>
public class WaniJudgement : MonoBehaviour
{
    [SerializeField] bool _onWani;
    public bool OnWani { get => _onWani; }
    GameObject _waniKun;
    public GameObject WaniKun { get => _waniKun; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //
        if (collision.gameObject.tag == "Target")
        {
            _onWani = true;
            _waniKun = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //いなくなったら殴れない　←？？？？？
        if (collision.gameObject.tag == "Target")
        {
            _onWani = false;
        }

    }

}
