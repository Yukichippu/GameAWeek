using UnityEngine;

public class Judge_KESHIPINN : MonoBehaviour
{
    [SerializeField]
    private string winnerName;

    public static string winner;

    private void Update()
    {
        winner = winnerName;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == gameObject.layer)
        {
            Debug.Log("HitPlayer");
        }
    }
}
