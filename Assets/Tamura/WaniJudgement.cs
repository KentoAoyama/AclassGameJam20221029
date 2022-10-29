using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ワニが出てきてるか判定してくれる</summary>
[RequireComponent(typeof(BoxCollider2D))]
public class WaniJudgement : MonoBehaviour
{
    [SerializeField, Tooltip("ワニが出てるかどうか")] bool _onWani;
    public bool OnWani { get => _onWani; set => _onWani = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //ワニが出てきてたらtrueにして、出てきたわにを代入する
        if (collision.gameObject.tag == "Target")
        {
            _onWani = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //いなくなったらfalseにしてワニ君はいなくなる
        if (collision.gameObject.tag == "Target")
        {
            _onWani = false;
        }

    }

}
