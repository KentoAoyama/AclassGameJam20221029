using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    [SerializeField, Header("�X�|�[�����W�̃��X�g")] List<GameObject> SpawnPoints = new();
    [SerializeField, Header("���j�̃I�u�W�F�N�g")] GameObject Crocodile;
    [Tooltip("�X�|�[�����W�̃C���f�b�N�X")] int _spawnPointIndex;
    [Tooltip("�O�̃C���f�b�N�X")] int _oldIndex;

    [SerializeField, Header("�X�|�[���Ԋu����")] float _waitTime;
    [Tooltip("�X�|�[���\���ǂ���")] bool _canSpawn;
    [Tooltip("���݂̃��j�̏o����")] static int crocodileCount;


    // Start is called before the first frame update
    void Start()
    {
        TimeSystem._isGame = true; //�f�o�b�O�p�@���Ƃŏ���
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeSystem._isGame)
        {
            _spawnPointIndex = Random.Range(0, SpawnPoints.Count);   //�o��������ꏊ������
            if (_oldIndex == _spawnPointIndex)  //������璊�I������
            {
                _canSpawn = false;
                return;
            }
            _oldIndex = _spawnPointIndex;

            if (_canSpawn && crocodileCount < 5)
            {
                StartCoroutine(Spawn()); ;    //�w��Ԋu�Ń��j���X�|�[��������
            }

        }

    }

    private IEnumerator Spawn() //�X�|�[���X�p��
    {
        yield return new WaitForSeconds(_waitTime); // �w�莞�ԑҋ@
        Instantiate(Crocodile, SpawnPoints[_spawnPointIndex].transform); //���j���o��
        crocodileCount++;
        _canSpawn = true;
    }
}
