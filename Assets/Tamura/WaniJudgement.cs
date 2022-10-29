using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ワニが出てきてるか判定してくれる</summary>
public class WaniJudgement : MonoBehaviour
{
    [SerializeField, Tooltip("ワニが出てるかどうか")] bool _onWani;
    public bool OnWani { get => _onWani; }
    [Tooltip("出てきたワニ。消すときに使う")] GameObject _waniKun;
    public GameObject WaniKun { get => _waniKun; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //ワニが出てきてたらtrueにして、出てきたわにを代入する
        if (collision.gameObject.tag == "Target")
        {
            _onWani = true;
            _waniKun = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //いなくなったらfalseにしてワニ君はいなくなる
        if (collision.gameObject.tag == "Target")
        {
            _onWani = false;
            _waniKun = default;
        }

    }

}
