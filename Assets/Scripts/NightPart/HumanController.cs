using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HumanController : csvlord
{

    void Start()
    {
        CSVRead();
        int count = 1;
        foreach (Transform child in transform)
        {
            for (int i = 0; i <= status[1]; i++)
            {
                if (child.name == "Human (" + i + ")")
                {
                    child.GetComponent<Image>().color = new Color(225, 225, 225, 225);
                }
            }
            count++;
        }

    }
}
