using UnityEngine;

public class Game_Start : MonoBehaviour
{
    public GameObject Ameila;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Ameila.active = true;
        }
    }
}
