using System.IO;
using UnityEngine;

public class CSVReader_LABYRINTH : MonoBehaviour
{
    [SerializeField]
    private string CSVFilePath;

    public GameObject blockPrefab;        // 0 の時に生成
    public GameObject playerPrefab;       // 1 の時に生成

    private void Start()
    {
        LoadMap();
    }

    private void LoadMap()
    {
        //CSVFileを読み込む
        TextAsset csvFile = Resources.Load<TextAsset>(CSVFilePath);

        if (csvFile == null)
        {
            Debug.LogError("CSV ファイルが見つかりません: " + CSVFilePath);
            return;
        }

        StringReader reader = new StringReader(csvFile.text);

        int y = 0;  // 行

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            for (int x = 0; x < values.Length; x++)
            {
                int id;
                if (!int.TryParse(values[x], out id))
                    continue;

                Vector3 pos = new Vector3(x, -y, 0);
                // y をマイナスにして上から下へ並ぶようにする（2D向け）

                switch (id)
                {
                    case 0: // オブジェクト
                        Instantiate(blockPrefab, pos, Quaternion.identity);
                        break;

                    case 1: // プレイヤー
                        Instantiate(playerPrefab, pos, Quaternion.identity);
                        break;
                }
            }
            y++;
        }
    }
}
