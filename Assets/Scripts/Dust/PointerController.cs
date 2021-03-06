﻿using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour
{
    GameObject tapObject;

	// Use this for initialization
	void Start ()
    {
	    tapObject = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //タップされているか判断
	    if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);

            //ゴミをタップしたか
            if(hitInfo.collider != null && hitInfo.collider.tag == "Dust")
            {
                tapObject = hitInfo.collider.gameObject;
            }
            else
            {
                tapObject = null;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //タップ解除
            tapObject = null;
        }
        else if(Input.GetMouseButton(0) && tapObject != null)
        {
            //
            Vector3 position = Input.mousePosition;
            position.z = 10.0f;
            position = Camera.main.ScreenToWorldPoint(position);

            tapObject.transform.position = position + new Vector3(0, 0.5f, 0);
        }
	}
}
