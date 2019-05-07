using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextParser : MonoBehaviour
{
    string m_strPath = "Assets/Resources/levels/";

    public GameObject baseTile;

    public void WriteData(string strData)
    {
        FileStream f = new FileStream(m_strPath + "levelDesign.txt", FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine(strData);
        writer.Close();
    }


    // level 이 문서 제일 끝에 붙을 이
    public void Parse(int level)
    {
        TextAsset data = Resources.Load("levels/levelDesign_" + level.ToString(), typeof(TextAsset)) as TextAsset;

        Debug.Log(data.text);

        string[] lines;                

        lines = data.text.Split('\n');

        for (int y = 0; y < lines.Length; y++)
        {
            // 입력 실수 방지
            if (lines[y].Length < 1) continue;

            string[] values = lines[y].Split(',');

            for (int x = 0; x < values.Length; x++)
            {
                Debug.Log(values[x]);
                // 텍스트에서 해당 값이 1인 애들만 타일 생성
                if(values[x] == "1")
                {
                    Instantiate(baseTile, transform.position + new Vector3(x, -y, 0), Quaternion.identity);
                }
            }
            
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Parse(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
