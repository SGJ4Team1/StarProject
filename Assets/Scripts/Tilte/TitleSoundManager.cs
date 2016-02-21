using UnityEngine;
using System.Collections;

public class TitleSoundManager : MonoBehaviour {

    // public
    public AudioClip se0;
    public AudioClip bgm;

    // private 
    private AudioSource[] sources;

	// Use this for initialization
	void Start () {
        Debug.Log("se start");
        sources = gameObject.GetComponents<AudioSource>();
        sources[0].clip = bgm;
        sources[0].Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySe(int index, float time = 0.0f)
    {
        sources[1].clip = se0;
        sources[1].time = time;
        sources[1].Play();
    }

    public void StopAll()
    {
        sources[0].Stop();
        sources[1].Stop();
    }
}
