using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    [SerializeField, Header("�X�|�[�����W�̃��X�g")] List<GameObject> SpawnPoints = new();
    [SerializeField, Header("���j�̃I�u�W�F�N�g")] GameObject Crocodile;
    [Tooltip("�X�|�[�����W�̃C���f�b�N�X")] int _spawnPointIndex;

    [SerializeField, Header("�X�|�[���Ԋu����")] float _waitTime;
    [Tooltip("�X�|�[���\���ǂ���")] bool _canSpawn;
    [Tooltip("���݂̃��j�̏o����")] public static int crocodileCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        TimeSystem._isGame = true; //�f�o�b�O�p�@���Ƃŏ���
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (crocodileCount >= 6) _canSpawn = false;

        if (TimeSystem._isGame && _canSpawn)
        {
            StartCoroutine(Spawn());    //�w��Ԋu�Ń��j���X�|�[��������
        }

    }

    private IEnumerator Spawn() //�X�|�[���X�p��
    {
        //Debug.Log("�R���[�`���������Ă�");
        _canSpawn = false;
        yield return new WaitForSeconds(_waitTime); // �w�莞�ԑҋ@

        _spawnPointIndex = Random.Range(0, SpawnPoints.Count);   //�o��������ꏊ������

        if (SpawnPoints[_spawnPointIndex].transform.childCount == 0)  //�������(�q�I�u�W�F�N�g���Ȃ�������)�o��
        {
            Debug.Log(_spawnPointIndex);
            crocodileCount++;
            Instantiate(Crocodile, SpawnPoints[_spawnPointIndex].transform); //���j���o��
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
