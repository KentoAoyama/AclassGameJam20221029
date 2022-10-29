using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    [SerializeField, Header("スポーン座標のリスト")] List<GameObject> SpawnPoints = new();
    [SerializeField, Header("ワニのオブジェクト")] GameObject Crocodile;
    [Tooltip("スポーン座標のインデックス")] int _spawnPointIndex;
    [Tooltip("前のインデックス")] int _oldIndex;

    [SerializeField, Header("スポーン間隔時間")] float _waitTime;
    [Tooltip("スポーン可能かどうか")] bool _canSpawn;
    [Tooltip("現在のワニの出現数")] static int crocodileCount;


    // Start is called before the first frame update
    void Start()
    {
        TimeSystem._isGame = true; //デバッグ用　あとで消す
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeSystem._isGame)
        {
            _spawnPointIndex = Random.Range(0, SpawnPoints.Count);   //出現させる場所を決定
            if (_oldIndex == _spawnPointIndex)  //被ったら抽選し直し
            {
                _canSpawn = false;
                return;
            }
            _oldIndex = _spawnPointIndex;

            if (_canSpawn && crocodileCount < 5)
            {
                StartCoroutine(Spawn()); ;    //指定間隔でワニをスポーンさせる
            }

        }

    }

    private IEnumerator Spawn() //スポーンスパン
    {
        yield return new WaitForSeconds(_waitTime); // 指定時間待機
        Instantiate(Crocodile, SpawnPoints[_spawnPointIndex].transform); //ワニを出現
        crocodileCount++;
        _canSpawn = true;
    }
}
