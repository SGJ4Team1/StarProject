using UnityEngine;
using System.Collections.Generic;

public class DustCreator : MonoBehaviour, GameStartHandlar
{
    [SerializeField]
    GameObject DustParent;

    [SerializeField]
    Rect createField;

    [SerializeField]
    List<GameObject> createObject;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnGameStart()
    {
        //ランダム生成
        for(int i = 0; i < 20; i++)
        {
            Vector2 randomPosition = RandomPosition();

            int createNum = Random.Range(0, createObject.Count);

            GameObject obj = Instantiate(createObject[createNum], 
                                         randomPosition, 
                                         Quaternion.identity) as GameObject;

            obj.GetComponent<SpriteRenderer>().sortingOrder = i + 10;

            obj.transform.parent = DustParent.transform;
        }
    }

    public Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(createField.xMin, createField.xMax), 
                           Random.Range(createField.yMin, createField.yMax));
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position + (Vector3)createField.center, createField.size);
    }
}
