using UnityEngine;

public class AudioTurnOner : MonoBehaviour
{
    public GameObject soundplace;
    private AudioSource audio;
    public AudioClip clip;
    void Start()
    {
        audio = soundplace.GetComponent<AudioSource>();
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
