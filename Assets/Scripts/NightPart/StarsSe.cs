using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsSe : MonoBehaviour
{
    [Header("SE")]
    public AudioClip audioClip;
    AudioSource audioSource;

    private bool SETr = true;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.GetComponent<Image>().color.a >= 255 && SETr == true)
        {
            SETr = false;
            audioSource.Play();
        }
	}
}
