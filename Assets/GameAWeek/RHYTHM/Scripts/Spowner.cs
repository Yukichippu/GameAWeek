using UnityEngine;

public class Spowner : MonoBehaviour
{
    [SerializeField]
    private GameObject  prefab;                                     //生成するオブジェクト
    [SerializeField]
    private float       spawnInterval           = 1f;               //生成間隔（秒）
    [SerializeField]
    private float       moveSpeed               = 3f;               //平行移動スピード
    [SerializeField]
    private Vector3     spawnPositionOffset     = Vector3.zero;     //生成位置のオフセット

    private float       timer;
    private int         spawnCount              = 0;                //タイマー
    private bool        isBursting              = false;            //高速生成モード中かどうか
    private int         burstSpawned            = 0;                //バースト中に生成した回数
    private float       normalSpawnInterval;                        //元の間隔を保持

    private void Start()
    {
        //デフォルトの値を保存
        normalSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //1秒毎に生成
        if (timer >= spawnInterval)
        {
            timer = 0f;

            // 通常モードまたはバーストモード問わず生成する
            SpawnObject();

            if (isBursting)
            {
                // バースト中は spawnCount を止める代わりにカウンタを進める
                burstSpawned++;

                // 3回生成したらバースト終了
                if (burstSpawned >= 3)
                {
                    isBursting = false;
                    burstSpawned = 0;
                    // 元に戻す
                    spawnInterval = normalSpawnInterval;
                    // ここで1回だけ加算
                    spawnCount++; 
                }
            }
            else
            {
                // 通常モード中は毎回カウントアップ
                spawnCount++;

                // 10の倍数でスピード減少
                if (spawnCount % 10 == 0)
                {
                    moveSpeed += 0.5f;
                }

                // 3の倍数で高速バースト開始
                else if (spawnCount % 3 == 0)
                {
                    isBursting = true;
                    spawnInterval = 0.5f;
                }
            }
        }
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    private void SpawnObject()
    {
        // 生成位置を指定
        Vector3 spawnPos = transform.position + spawnPositionOffset;
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // 移動スピードを設定
        Mover mover = obj.GetComponent<Mover>();
        if (mover != null)
        {
            mover.SetSpeed(moveSpeed);
        }
    }
}
