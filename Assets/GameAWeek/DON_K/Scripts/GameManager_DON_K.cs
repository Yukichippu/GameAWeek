using UnityEngine;

public class GameManager_DON_K : MonoBehaviour
{
    public GameObject prefabObj;
    public GameObject eObj;

    private void Start()
    {
        GameObject cloneObj = Instantiate(prefabObj, eObj.transform.position, Quaternion.identity);
    }
}
