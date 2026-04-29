using UnityEngine;

public class AudioTurnOner : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip clip;
    void start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.PlayOneShot(clip);
        }
    }
}
