using UnityEngine;
using System.Collections;

public class BlackSmoke : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float width;

    float radius;

    private RectTransform rectTrans;

	// Use this for initialization
	void Start ()
    {
        rectTrans = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        radius += speed;
        radius  = (radius + 360) % 360;
	    rectTrans.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * radius)*width, 0);
	}
}
