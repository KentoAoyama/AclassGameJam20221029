using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���j���o�Ă��Ă邩���肵�Ă����</summary>
public class WaniJudgement : MonoBehaviour
{
    [SerializeField, Tooltip("���j���o�Ă邩�ǂ���")] bool _onWani;
    public bool OnWani { get => _onWani; }
    [Tooltip("�o�Ă������j�B�����Ƃ��Ɏg��")] GameObject _waniKun;
    public GameObject WaniKun { get => _waniKun; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //���j���o�Ă��Ă���true�ɂ��āA�o�Ă�����ɂ�������
        if (collision.gameObject.tag == "Target")
        {
            _onWani = true;
            _waniKun = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //���Ȃ��Ȃ�����false�ɂ��ă��j�N�͂��Ȃ��Ȃ�
        if (collision.gameObject.tag == "Target")
        {
            _onWani = false;
            _waniKun = default;
        }

    }

}
