using UnityEngine;

public class Game_Start : MonoBehaviour
{
    public bool Amelia = false;
    public bool Mummy = false;
    public bool Gnomes = false;
    public bool Statue = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Enemy = Random.Range(1,4);
        if(Enemy == 1)
        {
            Amelia = true;
        }
        else if(Enemy == 2)
        {
            Mummy = true;
        }
        else if (Enemy == 3)
        {
            Gnomes = true;
        }
        else
        {
            Statue = true;
        }
    }
}
