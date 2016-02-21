using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsController : csvlord
{

	void Start ()
    {
        CSVRead();
        int count = 1;
        foreach (Transform child in transform)
        {
            for (int i = 0; i <= status[0]; i++)
            {
                if (child.name == "Star (" + i + ")")
                {
                    if (i == status[0])
                    {
                        child.GetComponent<Animator>().enabled = true;
                    }
                    else
                    {
                        child.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    }
                }
            }
            count++;
        }
      
	}
}
