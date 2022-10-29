using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���j���o�Ă��Ă邩���肵�Ă����</summary>
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

        //���Ȃ��Ȃ����牣��Ȃ��@���H�H�H�H�H
        if (collision.gameObject.tag == "Target")
        {
            _onWani = false;
        }

    }

}
