using UnityEngine;

public class WaterHolderSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int spawn;
    void Start()
    {
        //Have it Spawn In one of a few different places
        spawn = Random.Range(1,4);
    }
}
