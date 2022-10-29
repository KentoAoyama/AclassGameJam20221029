using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ワニをたたくハンマーの動き</summary>
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("ハンマーで叩く場所")] GameObject[] _wani = new GameObject[6];
    [Tooltip("ハンマーのもともとの位置")] Vector2 _originPosition;
    [Tooltip("ハンマーの画像")] SpriteRenderer _hammer;
    [SerializeField, Header("叩けるインターバル")] float _interval = 0.2f;
    [SerializeField, Header("ハンマーが反転するまでの時間")] float _flipHammer = 0.2f;
    [Tooltip("押したかどうか")]　bool _isPunched;
    [Tooltip("オーディオソース")] AudioSource _audioSource;
    [SerializeField, Header("ハンマーで殴る音")] AudioClip _punchHammer;
    [SerializeField, Header("ワニをたたいた時に出るエフェクト")] GameObject _effect;

    void Start()
    {
        _originPosition = GetComponent<Transform>().position;
        _hammer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        //Debug.Log(_originPosition);
    }

    void Update()
    {

        //ゲームが始まってないと動かせない
        if(TimeSystem._isGame)
        {

            //まだパンチしてないとき
            if (!_isPunched)
            {

                //押されたキーによって動作が変わる
                //左から、sdfjklキーがワニがスポーンする場所に対応してる
                switch (Input.inputString)
                {
                    case "d":
                        Debug.Log("dがおされた");
                        StartCoroutine(PunchWani(_wani[0]));
                        break;
                    case "f":
                        Debug.Log("fがおされた");
                        StartCoroutine(PunchWani(_wani[1]));
                        break;
                    case "g":
                        Debug.Log("gがおされた");
                        StartCoroutine(PunchWani(_wani[2]));
                        break;
                    case "h":
                        Debug.Log("hがおされた");
                        StartCoroutine(PunchWani(_wani[3]));
                        break;
                    case "j":
                        Debug.Log("jがおされた");
                        StartCoroutine(PunchWani(_wani[4]));
                        break;
                    case "k":
                        Debug.Log("kがおされた");
                        StartCoroutine(PunchWani(_wani[5]));
                        break;
                    default:
                        break;
                }

            }

        }

    }
    
    /// <summary>ハンマーでたたく。もしワニがいたら得点が入る</summary>
    /// <param name="wani"></param>
    /// <returns></returns>
    IEnumerator PunchWani(GameObject wani)
    {
        WaniJudgement waniJudge = wani.GetComponent<WaniJudgement>();

        //叩いた場所にワニがいたら、得点が増える
        if (waniJudge.OnWani)
        {
            ScoreSystem.AddScore(1);
            waniJudge.OnWani = false;
            _effect.SetActive(true);
            //CrocodileSpawner.crocodileCount--;
        }

        //ハンマーでたたく動き
        //反転させて、殴りたい場所まで移動する。音もなる。
        _isPunched = true;
        _hammer.flipX = true;
        this.transform.position = wani.transform.position;
        _audioSource.PlayOneShot(_punchHammer);
        yield return new WaitForSeconds(_flipHammer);
        //反転を戻す
        _hammer.flipX = false;
        _effect.SetActive(false);
        yield return new WaitForSeconds(_interval);
        //ハンマーを元の場所に戻す
        //Debug.Log(_originPosition);
        this.transform.position = _originPosition;
        _isPunched = false;
    }

}
