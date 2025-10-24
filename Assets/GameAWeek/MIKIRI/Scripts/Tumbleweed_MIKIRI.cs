using UnityEngine;

public class Tumbleweed_MIKIRI : MonoBehaviour
{
    private new Camera camera;                  //MainCamera

    private Vector3     myPos;                  //Position
    private Quaternion  myRot;                  //Rotation
    private Vector3     startPos;               //�J�n�n�_
    private Vector3     leftEdgePixel;          //��ʍ��[�̃s�N�Z�����W
    private Vector3     leftEdgeWorld;          //��ʂ̍��[�̃��[���h���W

    private float       delay;                  //���ɓ����܂ł̎���
    private float       radomMin = 1.0f;        //delay�̍ŏ��l
    private float       radomMax = 5.0f;        //delay�̍ő�l
    private float       timer;                  //�^�C�}�[
    private float       speed = 2.0f;           //�ړ����x

    private bool        moving;                 //�����Ă��邪�ǂ���

    private void Start()
    {
        camera = Camera.main;

        // ��ʍ��[�̃s�N�Z�����W���v�Z
        leftEdgePixel = new Vector3(camera.pixelRect.x, Screen.height / 2, 0);

        // �s�N�Z�����W�����[���h���W�ɕϊ�
        leftEdgeWorld = camera.ScreenToWorldPoint(leftEdgePixel);

        myPos = transform.position;
        myRot = transform.rotation;
        startPos = myPos;

        delay = Random.Range(radomMin,radomMax);
    }

    private void Update()
    {
        if (!moving)
            timer += Time.deltaTime;

        if (timer >= delay)
        {
            moving = true;
            //�ړ�
            myPos.x -= Time.deltaTime * speed;
            transform.position = myPos;
            //��]
            myRot = Quaternion.Euler(0, 0, 0.5f);
            transform.rotation *= myRot;
        }

        //��ʍ��[�𒴂�����ŏ��̈ʒu�ɖ߂�
        if (myPos.x < leftEdgeWorld.x)
        {
            myPos = startPos;
            transform.position = myPos;

            timer = 0f;
            delay = Random.Range(radomMin, radomMax);
            moving = false;
        }

    }
}
