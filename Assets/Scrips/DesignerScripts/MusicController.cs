using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static MusicController instance = null;

    public AudioClip[] musicClips;
    public AudioSource[] source;
    private int currentClip=0;
    private int clipPos=0;
    private int currentSource = 0;
    private bool fadingOut;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        source = GetComponents<AudioSource>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!fadingOut)
        {
            if (source[currentSource].time > musicClips[currentClip].length - 5)
            {
                StartCoroutine(FadeOut());
            }
        }
    }


    private IEnumerator FadeOut()
    {
        return null;
    }

    private IEnumerator FadeIn()
    {
        return null;
    }
}
