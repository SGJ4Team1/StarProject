using UnityEngine;
using System.Collections;

public class BlackSmoke : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float time;

    private Vector3 startPosition;

    private RectTransform rectTrans;

	// Use this for initialization
	void Start ()
    {
        rectTrans = GetComponent<RectTransform>();
        startPosition = rectTrans.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    rectTrans.position += new Vector3(speed, 0);
	}

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            rectTrans.position = startPosition;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(speed, 0) * 60 * time);
    }
}
