using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// number % divisor = remainder; 5 % 3 = 2; i % array.length = 0 - array length - 1 

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
        source[currentSource].clip = musicClips[currentClip];
        source[currentSource].Play();

    }
	
	// Update is called once per frame
	void Update () {
        if (!fadingOut)
        {
            if (source[currentSource].time > musicClips[currentClip].length - 5)
            {
                fadingOut = true;
                int oldSource = currentSource;
                currentSource = (1+currentSource) % source.Length;
                currentClip = (1 + currentClip) % musicClips.Length;
                source[currentSource].clip = musicClips[currentClip];
                source[currentSource].Play();
                LeanTween.value(0, 1, 5).setOnUpdate(delegate (float f) { source[currentSource].volume = f; });
                LeanTween.value(1, 0, 5).setOnUpdate(delegate (float f) { source[oldSource].volume = f; }).setOnComplete(delegate () { fadingOut = false; });
            }
        }
    }

}
