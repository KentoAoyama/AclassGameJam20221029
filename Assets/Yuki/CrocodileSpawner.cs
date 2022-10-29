using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    [SerializeField, Header("スポーン座標のリスト")] List<GameObject> SpawnPoints = new();
    [SerializeField, Header("ワニのオブジェクト")] GameObject Crocodile;
    [Tooltip("スポーン座標のインデックス")] int _spawnPointIndex;

    [SerializeField, Header("スポーン間隔時間")] float _waitTime;
    [Tooltip("スポーン可能かどうか")] bool _canSpawn;
    [Tooltip("現在のワニの出現数")] public static int crocodileCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        TimeSystem._isGame = true; //デバッグ用　あとで消す
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (crocodileCount >= 6) _canSpawn = false;

        if (TimeSystem._isGame && _canSpawn)
        {
            StartCoroutine(Spawn());    //指定間隔でワニをスポーンさせる
        }

    }

    private IEnumerator Spawn() //スポーンスパン
    {
        //Debug.Log("コルーチンがこわれてる");
        _canSpawn = false;
        yield return new WaitForSeconds(_waitTime); // 指定時間待機

        _spawnPointIndex = Random.Range(0, SpawnPoints.Count);   //出現させる場所を決定

        if (SpawnPoints[_spawnPointIndex].transform.childCount == 0)  //被ったら(子オブジェクトがなかったら)出現
        {
            Debug.Log(_spawnPointIndex);
            crocodileCount++;
            Instantiate(Crocodile, SpawnPoints[_spawnPointIndex].transform); //ワニを出現
            if (_waitTime > 0f)
            {
                _waitTime -= 0.01f;
            }
            else
            {
                _waitTime = 0f;
            }
        }


        //Debug.Log(crocodileCount);
        _canSpawn = true;

    }
}
