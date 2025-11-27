using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ladders;

    private struct Ladders
    {
        public GameObject ladderObj;
        public float dis;
    }
    [SerializeField]
    Ladders[] ladder;

    int count = 1;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            ladder[i] = new Ladders();
            ladder[i].ladderObj = GameObject.Find("Ladder" +  i).gameObject;

            if(ladder[i].ladderObj != null)
                count++;
        }
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);

        //for(int i = 0; i < ladders.Length; i++)
        //{
        //    ladder[i].dis = (ladders[i].transform.position-transform.position).magnitude;
        //    if (ladder[i].dis <= 0.1f)
        //    {
        //        float y = Input.GetAxis("Velocity") * Time.deltaTime;
        //        transform.position += new Vector3(0, y, 0);
        //    }
        //}
    }
}
