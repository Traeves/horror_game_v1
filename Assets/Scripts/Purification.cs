using UnityEngine;

public class Purification : MonoBehaviour
{
    public Collider PurificationZone= null;
    public GameObject normal= null;
    public GameObject purified = null;
    void OnTriggerEnter(Collider other)
    {
        if(other == PurificationZone)
        {
            normal.active = false;
            purified.active = true;
        }
    }
}
