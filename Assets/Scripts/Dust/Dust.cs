using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour
{
    public enum Kind
    {
        //0はリサイクル出来ないもの 
        //1は
        Burnable    = 0,//燃えるゴミ
        NonBurnable = 1,//燃えないゴミ
        HardPlastic = 10,//プラスチック
        NewsPaper   = 11,//新聞紙
        Magazine    = 12,//雑誌
        AluminumCan = 13,//アルミ缶
        SteelCan    = 14,//スチール缶
        Bottle      = 15,//空きビン
        PET         = 16,//ペットボトル
        Glass       = 17,//ガラス
        Cloth       = 18,//布
        BigTrash    = 2,//粗大ごみ
        BigRecycle  = 19,//パソコンなどリサイクルできる大きいゴミ
    }

    public enum ColorKind
    {
        Red,
        Green,
        Blue,
        Purple,
        LightBlue,
        Yellow,
    }

    [System.Serializable]
    public struct Parameter
    {
        public Kind      kind;
        public ColorKind color;
        public float     size;
    }

    [SerializeField]
    private Parameter parameter;

    public Parameter Info
    {
        get { return parameter; }
    }

    public void ReRandomPut()
    {
        transform.parent.GetComponent<DustSender>().RandomPosition(gameObject);
    }
}
