using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource Click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance != null) { Destroy(this.gameObject); }
        else { instance = this; }
    }

    public void ClickSound()
    {
        Click.Play();
    }
}
