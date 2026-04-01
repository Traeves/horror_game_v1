using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public string roomName;
    public int roomNumber =-1;
    private RoomManager rm;
    void Start(){
        rm = GetComponentInParent<RoomManager>();
    } 
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Player Entered" + roomName);
            rm.Player_Room = roomNumber;
        }
        if(other.CompareTag("Amelia")){
            Debug.Log("Amelia Entered" + roomName);
            rm.Amelia_Room = roomNumber;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Player Left" + roomName);
        }
        if(other.CompareTag("Amelia")){
            Debug.Log("Amelia left" + roomName);
        }
    }
}
