using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���j���������n���}�[�̓���</summary>
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("�n���}�[�Œ@���ꏊ")] GameObject[] _wani = new GameObject[6];
    [Tooltip("�n���}�[�̂��Ƃ��Ƃ̈ʒu")] Vector2 _originPosition;
    [Tooltip("�n���}�[�̉摜")] SpriteRenderer _hammer;
    [SerializeField, Header("�@����C���^�[�o��")] float _interval = 0.2f;
    [SerializeField, Header("�n���}�[�����]����܂ł̎���")] float _flipHammer = 0.2f;
    [Tooltip("���������ǂ���")]�@bool _isPunched;
    [Tooltip("�I�[�f�B�I�\�[�X")] AudioSource _audioSource;
    [SerializeField, Header("�n���}�[�ŉ��鉹")] AudioClip _punchHammer;
    [SerializeField, Header("���j�������������ɏo��G�t�F�N�g")] GameObject _effect;

    void Start()
    {
        _originPosition = GetComponent<Transform>().position;
        _hammer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        //Debug.Log(_originPosition);
    }

    void Update()
    {

        //�Q�[�����n�܂��ĂȂ��Ɠ������Ȃ�
        if(TimeSystem._isGame)
        {

            //�܂��p���`���ĂȂ��Ƃ�
            if (!_isPunched)
            {

                //�����ꂽ�L�[�ɂ���ē��삪�ς��
                //������Asdfjkl�L�[�����j���X�|�[������ꏊ�ɑΉ����Ă�
                switch (Input.inputString)
                {
                    case "d":
                        Debug.Log("d�������ꂽ");
                        StartCoroutine(PunchWani(_wani[0]));
                        break;
                    case "f":
                        Debug.Log("f�������ꂽ");
                        StartCoroutine(PunchWani(_wani[1]));
                        break;
                    case "g":
                        Debug.Log("g�������ꂽ");
                        StartCoroutine(PunchWani(_wani[2]));
                        break;
                    case "h":
                        Debug.Log("h�������ꂽ");
                        StartCoroutine(PunchWani(_wani[3]));
                        break;
                    case "j":
                        Debug.Log("j�������ꂽ");
                        StartCoroutine(PunchWani(_wani[4]));
                        break;
                    case "k":
                        Debug.Log("k�������ꂽ");
                        StartCoroutine(PunchWani(_wani[5]));
                        break;
                    default:
                        break;
                }

            }

        }

    }
    
    /// <summary>�n���}�[�ł������B�������j�������瓾�_������</summary>
    /// <param name="wani"></param>
    /// <returns></returns>
    IEnumerator PunchWani(GameObject wani)
    {
        WaniJudgement waniJudge = wani.GetComponent<WaniJudgement>();

        //�@�����ꏊ�Ƀ��j��������A���_��������
        if (waniJudge.OnWani)
        {
            ScoreSystem.AddScore(1);
            waniJudge.OnWani = false;
            _effect.SetActive(true);
            //CrocodileSpawner.crocodileCount--;
        }

        //�n���}�[�ł���������
        //���]�����āA���肽���ꏊ�܂ňړ�����B�����Ȃ�B
        _isPunched = true;
        _hammer.flipX = true;
        this.transform.position = wani.transform.position;
        _audioSource.PlayOneShot(_punchHammer);
        yield return new WaitForSeconds(_flipHammer);
        //���]��߂�
        _hammer.flipX = false;
        _effect.SetActive(false);
        yield return new WaitForSeconds(_interval);
        //�n���}�[�����̏ꏊ�ɖ߂�
        //Debug.Log(_originPosition);
        this.transform.position = _originPosition;
        _isPunched = false;
    }

}
