using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>ワニをたたくハンマーの動き</summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("ワニが出てくるところ")] GameObject[] _wani = new GameObject[6];
    [Tooltip("ハンマーのもともとの位置")] Transform _originPosition;
    [Tooltip("ハンマーの画像")] SpriteRenderer _hammer;
    [SerializeField, Header("叩けるインターバル")] float _interval = 0.2f;
    bool _isPunched;

    void Start()
    {
        _originPosition = GetComponent<Transform>();
        _hammer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        //まだパンチしてないとき
        if(!_isPunched)
        {
            

            //押されたキーによって動作が変わる
            switch (Input.inputString)
            {
                case "s":
                    Debug.Log("sがおされた");
                    StartCoroutine(PunchWani(_wani[0]));
                    break;
                case "d":
                    Debug.Log("dがおされた");
                    StartCoroutine(PunchWani(_wani[1]));
                    break;
                case "f":
                    Debug.Log("fがおされた");
                    StartCoroutine(PunchWani(_wani[2]));
                    break;
                case "j":
                    Debug.Log("jがおされた");
                    StartCoroutine(PunchWani(_wani[3]));
                    break;
                case "k":
                    Debug.Log("kがおされた");
                    StartCoroutine(PunchWani(_wani[4]));
                    break;
                case "l":
                    Debug.Log("lがおされた");
                    StartCoroutine(PunchWani(_wani[5]));
                    break;
                default:
                    break;
            }

        }
        

    }
    
    /// <summary>ハンマーでたたく。もしワニがいたら得点が入る</summary>
    /// <param name="wani"></param>
    /// <returns></returns>
    IEnumerator PunchWani(GameObject wani)
    {

        //叩いた場所にワニがいたら得点が増える
        if (wani.GetComponent<WaniJudgement>().OnWani)
        {
            ScoreSystem.AddScore(1);
            Destroy(wani.GetComponent<WaniJudgement>().WaniKun);
            CrocodileSpawner.crocodileCount--;
        }

        //ハンマーでたたく動き
        _isPunched = true;
        _hammer.flipX = true;
        this.transform.position = wani.transform.position;
        yield return new WaitForSeconds(_interval);
        _hammer.flipX = false;
        this.transform.position = _originPosition.position;
        _isPunched = false;
    }

}
