using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

public class csvlord : MonoBehaviour {
    private string guitxt = "";
    private FileInfo fi;
    StreamWriter sw;

    private int star;

    void Start()
    {
        fi = new FileInfo(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
    }


    #region 関数
    public int StarReset()
    {
        Reset();
        return star;
    }
    public int StarUp()
    {
        InputFile();
        return star;
    }
    public int StarRead()
    {
        print("a");
        ReadFile();
        print(star);
        return star;
    }
    #endregion
    #region CSV読み書き
    //Reset
    void Reset()
    {
        File.Delete(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        sw = fi.AppendText();
        sw.WriteLine("0");
        sw.Flush();
        sw.Close();
    }
    //書き込み
    void InputFile()
    {
        File.Delete(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        sw = fi.AppendText();
        int num = star + 1;
        sw.WriteLine(num.ToString());
        sw.Flush();
        sw.Close();
    }
    // 読み込み関数
    void ReadFile()
    {
        try
        {
            // 一行毎読み込み
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {
                guitxt = sr.ReadToEnd();
                star = int.Parse(guitxt);
            }
        }
        catch (Exception e)
        {
            // 改行コード
            guitxt += SetDefaultText();
        }
    }
    // 改行コード処理
    string SetDefaultText()
    {
        return "C#\n";
    }

    #endregion
}
