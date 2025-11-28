using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private struct Ladders
    {
        public GameObject ladderObj;
        public Vector2 dis;
    }
    [SerializeField]
    Ladders[] ladder;

    string baseName = "Ladder";

    private void Start()
    {
        //オブジェクトを配列に格納
        List<Ladders> laddersList = new List<Ladders>();
        int index = 0;
        while(true)
        {
            string objName = baseName + index;
            GameObject obj = GameObject.Find(objName);

            if (obj == null)
                break;

            Ladders lad = new Ladders();
            lad.ladderObj = obj;
            lad.dis = Vector2.zero;

            laddersList.Add(lad);
            index++;
        }
        ladder = laddersList.ToArray();
    }

    private void Update()
    {
        //移動
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);

        //距離取得
        for (int i = 0; i < ladder.Length; i++)
        {
            if (ladder[i].ladderObj == null) continue;

            Ladders temp = ladder[i];
            temp.dis = transform.position - ladder[i].ladderObj.transform.position;
            ladder[i] = temp;

            if (ladder[i].dis.x < 0.1f && ladder[i].dis.y < 0.5f)
            {
                float y = Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += new Vector3(0, y, 0);
            }
        }
    }
}
