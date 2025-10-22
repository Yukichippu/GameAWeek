using UnityEngine;

public class Tumbleweed_MIKIRI : MonoBehaviour
{
    private new Camera camera;

    private Vector3     myPos;
    private float  myRot;
    private Vector3     startPos;
    private Vector3     leftEdgePixel;
    private Vector3     leftEdgeWorld;

    private float speed = 2.0f;

    private void Start()
    {
        camera = Camera.main;

        // ��ʍ��[�̃s�N�Z�����W���v�Z
        leftEdgePixel = new Vector3(camera.pixelRect.x, Screen.height / 2, 0);

        // �s�N�Z�����W�����[���h���W�ɕϊ�
        leftEdgeWorld = camera.ScreenToWorldPoint(leftEdgePixel);

        myPos = transform.position;
        startPos = myPos;
    }

    private void Update()
    {
        //�ړ�
        myPos.x -= Time.deltaTime * speed;
        transform.position = myPos;
        //��]


        //��ʒ[�𒴂�����ŏ��̈ʒu�ɖ߂�
        if (myPos.x < leftEdgeWorld.x)
        {
            transform.localPosition = startPos;
        }
    }
}
