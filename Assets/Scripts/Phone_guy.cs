using UnityEngine;

public class Phone_guy : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playAudio(){
        audio.PlayOneShot(clip);

    }
}
