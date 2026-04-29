using UnityEngine;

public class Purification : MonoBehaviour
{
    public Collider PurificationZone= null;
    public GameObject normal= null;
    public GameObject purified = null;
    private AudioSource audio;
    public AudioClip clip;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other == PurificationZone)
        {
            normal.active = false;
            purified.active = true;
            audio.PlayOneShot(clip,0.2f);

        }
    }
}
