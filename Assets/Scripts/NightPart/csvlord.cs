using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

public class csvlord : MonoBehaviour {

    private string guitxt = "";
    private FileInfo fi;
    StreamWriter sw;

    [Header("0 星の数' 1 人の数' 2 ラウンド")]
    public int[] status ;


    #region CSV読み書き
    protected void CSVReset()//CSVの中身をリセットする
    {
        Array.Resize(ref status, 3);
        fi = new FileInfo(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");

        File.Delete(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        sw = fi.AppendText();

        for (int i = 0; i < status.Length; i++)
        {
            sw.Write("0" + ",");
        } 

        sw.Flush();
        sw.Close();
    }
    //書き込み
    public void CSVInput(int[] plusstatus)
    {
        Array.Resize(ref status, 3);
        fi = new FileInfo(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        CSVRead();
        File.Delete(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        sw = fi.AppendText();


        for (int i = 0; i < status.Length; i++)
        {
            status[i] = status[i] + plusstatus[i];
            sw.Write(status[i] + ",");
        } 

        sw.Flush();
        sw.Close();
    }
    // 読み込み関数
    public void CSVRead()
    {
        Array.Resize(ref status, 3);
        fi = new FileInfo(Application.dataPath + "/Resources/NighResource/" + "StarsNum.csv");
        try
        {
            // 一行毎読み込み
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {
                guitxt = sr.ReadToEnd();

                string[] elements = guitxt.Split(',');
                Array.Resize(ref status, elements.Length - 1);
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    status[i] = int.Parse(elements[i]);
                }  
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
        return "\n";
    }

    #endregion
}
