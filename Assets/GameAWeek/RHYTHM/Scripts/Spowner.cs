using UnityEngine;

public class Spowner : MonoBehaviour
{
    [SerializeField] GameObject prefab;  // ��������I�u�W�F�N�g
    [SerializeField] float spawnInterval = 1f; // �����Ԋu�i�b�j
    [SerializeField] float moveSpeed = 3f;     // ���s�ړ��X�s�[�h
    [SerializeField] Vector3 spawnPositionOffset = Vector3.zero; // �����ʒu�̃I�t�Z�b�g

    private float timer;
    private int spawnCount = 0;
    private bool isBursting = false;       // �����������[�h�����H
    private int burstSpawned = 0;          // �o�[�X�g���ɐ���������
    private float normalSpawnInterval;     // ���̊Ԋu��ێ�

    private void Start()
    {
        normalSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // �ʏ탂�[�h�܂��̓o�[�X�g���[�h��킸��������
            SpawnObject();

            if (isBursting)
            {
                // �o�[�X�g���� spawnCount ���~�߂����ɃJ�E���^��i�߂�
                burstSpawned++;

                // 3�񐶐�������o�[�X�g�I��
                if (burstSpawned >= 3)
                {
                    isBursting = false;
                    burstSpawned = 0;
                    spawnInterval = normalSpawnInterval; // ���ɖ߂�
                    spawnCount++; // ������1�񂾂����Z
                }
            }
            else
            {
                // �ʏ탂�[�h���͖���J�E���g�A�b�v
                spawnCount++;

                // 10�̔{���ŃX�s�[�h����
                if (spawnCount % 10 == 0)
                {
                    moveSpeed += 0.5f;
                }

                // 3�̔{���ō����o�[�X�g�J�n
                else if (spawnCount % 3 == 0)
                {
                    isBursting = true;
                    spawnInterval = 0.5f;
                }
            }
        }
    }

    private void SpawnObject()
    {
        // �����ʒu���w��
        Vector3 spawnPos = transform.position + spawnPositionOffset;
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // �ړ��X�s�[�h��ݒ�
        Mover mover = obj.GetComponent<Mover>();
        if (mover != null)
        {
            mover.SetSpeed(moveSpeed);
        }
    }
}
