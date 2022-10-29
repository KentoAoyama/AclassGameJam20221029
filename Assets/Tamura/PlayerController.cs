using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���j���������n���}�[�̓���</summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("���j���o�Ă���Ƃ���")] GameObject[] _wani = new GameObject[6];
    [Tooltip("�n���}�[�̂��Ƃ��Ƃ̈ʒu")] Transform _originPosition;
    [Tooltip("�n���}�[�̉摜")] SpriteRenderer _hammer;
    [SerializeField, Header("�@����C���^�[�o��")] float _interval = 0.2f;
    bool _isPunched;

    void Start()
    {
        _originPosition = GetComponent<Transform>();
        _hammer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        //�܂��p���`���ĂȂ��Ƃ�
        if(!_isPunched)
        {
            

            //�����ꂽ�L�[�ɂ���ē��삪�ς��
            switch (Input.inputString)
            {
                case "s":
                    Debug.Log("s�������ꂽ");
                    StartCoroutine(PunchWani(_wani[0]));
                    break;
                case "d":
                    Debug.Log("d�������ꂽ");
                    StartCoroutine(PunchWani(_wani[1]));
                    break;
                case "f":
                    Debug.Log("f�������ꂽ");
                    StartCoroutine(PunchWani(_wani[2]));
                    break;
                case "j":
                    Debug.Log("j�������ꂽ");
                    StartCoroutine(PunchWani(_wani[3]));
                    break;
                case "k":
                    Debug.Log("k�������ꂽ");
                    StartCoroutine(PunchWani(_wani[4]));
                    break;
                case "l":
                    Debug.Log("l�������ꂽ");
                    StartCoroutine(PunchWani(_wani[5]));
                    break;
                default:
                    break;
            }

        }
        

    }
    
    /// <summary>�n���}�[�ł������B�������j�������瓾�_������</summary>
    /// <param name="wani"></param>
    /// <returns></returns>
    IEnumerator PunchWani(GameObject wani)
    {

        //�@�����ꏊ�Ƀ��j�������瓾�_��������
        if (wani.GetComponent<WaniJudgement>().OnWani)
        {
            ScoreSystem.AddScore(1);
            Destroy(wani.GetComponent<WaniJudgement>().WaniKun);
            CrocodileSpawner.crocodileCount--;
        }

        //�n���}�[�ł���������
        _isPunched = true;
        _hammer.flipX = true;
        this.transform.position = wani.transform.position;
        yield return new WaitForSeconds(_interval);
        _hammer.flipX = false;
        this.transform.position = _originPosition.position;
        _isPunched = false;
    }

}
