using UnityEngine;
using System.Collections;

public class DustDetector : MonoBehaviour
{
    [SerializeField]
    private DustRest dustRect;

    [Header("ゴミを判定基準")]

    [SerializeField, Tooltip("検知するゴミの情報")]
    private bool detectorKind;

    [SerializeField, Tooltip("検知するゴミの情報")]
    private bool detectorRecycle;

    [SerializeField, Tooltip("検知するゴミの情報")]
    private bool detectorColor;

    [SerializeField, Tooltip("検知するゴミの情報")]
    private bool detectorSize;

    [SerializeField, Tooltip("検知するゴミの種類")]
    private Dust.Parameter detectorInfo;

    private Rigidbody2D rig;

	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnOverlapDust(GameObject dust)
    {
        Dust.Parameter param = dust.GetComponent<Dust>().Info;

        bool isEqualKind    = true;
        bool isEqualRecycle = true;
        bool isEqualColor   = true;
        bool isEqualSize    = true;

        if(detectorKind)
        {
            //ゴミの種類で検知
            isEqualKind    = detectorInfo.kind  == param.kind;
        }

        if(detectorRecycle)
        {
            //リサイクルできるかで検知
            isEqualRecycle = 10 <= (int)param.kind;
        }

        if(detectorColor)
        {
            //ゴミの色で検知
            isEqualColor   = detectorInfo.color == param.color;
        }

        if(detectorSize)
        {
            //ゴミの大きさで検知
            isEqualSize    = detectorInfo.size  == param.size;
        }

        if(isEqualKind && isEqualRecycle &&isEqualColor && isEqualSize)
        {
            Debug.Log("正解");
            Success();
            Destroy(dust);
            dust = null;
        }
        else
        {
            Debug.Log("不正解");
            dust.GetComponent<Dust>().ReRandomPut();
        }
    }

    IEnumerator StopDelay()
    {
        yield return null;
        StopAllCoroutines();
    }

    void Success()
    {
        dustRect.Sub();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dust")
        {
            StartCoroutine(CheckMouse(other));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(StopDelay());
    }

    IEnumerator CheckMouse(Collider2D col)
    {
        while(true)
        {
            rig.WakeUp();
            if(!Input.GetMouseButton(0) && rig.IsTouching(col))
            {
                OnOverlapDust(col.gameObject);
            }
            yield return null;
        }
    }
}
