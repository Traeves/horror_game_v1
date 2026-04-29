using UnityEngine;

public class CrossSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawn = Random.Range(1,7);
        if(spawn == 1)
        {
            transform.position = new Vector3(14f, 3.5f, 35.55f);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if(spawn == 2)
        {
            transform.position = new Vector3(-11.852f, 3.116f, 52.35f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(spawn == 3)
        {
            transform.position = new Vector3(-13.826f, 4.755f, 57.788f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(spawn == 4)
        {
            ransform.position = new Vector3(-1.7f, 3.5f, 64.3f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(spawn == 5)
        {
            transform.position = new Vector3(-0.416f, 3.058f, 63.601f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }else if(spawn == 6)
        {
            transform.position = new Vector3(-13.057f, 3.058f, 21.074f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
