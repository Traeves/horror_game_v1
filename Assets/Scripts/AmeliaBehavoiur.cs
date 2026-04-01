using UnityEngine;

public class AmeliaBehavoiur : MonoBehaviour
{
    public int state = 0; // 0 = Neutral, 1 = Roaming, 2 = Aggresive
    public float timepassed = 0f;
    public RoomManager rm;
    public float angerTimer = 0f;
    public float anger = 0;
    public float move = 0f;
    private float attackTresh;
    private float whenNextMove;
    private AudioSource audio;
    public AudioClip beep;
    public AudioClip death;
    void Start(){
        attackTresh = Random.Range(10,15);
        whenNextMove = Random.Range(10,15);
        audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        timepassed += Time.deltaTime;
        if(state == 2 && rm.Player_Room == rm.Amelia_Room ){
            angerTimer += Time.deltaTime;
            if(angerTimer > 2){
                angerTimer=0;
                if(attackTresh < anger){
                    anger = 0;
                    Amelia_Attack();
                }
                anger++;
            }
        }
        if(state == 2 && rm.Player_Room != rm.Amelia_Room ){
            move += Time.deltaTime;
            if(move > whenNextMove){
                AmeliaMoves();
                move = 0f;
                whenNextMove = Random.Range(5,10);
                AmeliaTell();
            }
        }
        if(state == 1 && rm.Player_Room == rm.Amelia_Room ){
            angerTimer += Time.deltaTime;
            if(angerTimer > 2.5){
                angerTimer=0;
                if(attackTresh < anger){
                    Amelia_Attack();
                }
                anger++;
                
            }
        }
        if(state == 1 && rm.Player_Room != rm.Amelia_Room ){
            move += Time.deltaTime;
            if(move > whenNextMove){
                AmeliaMoves();
                move = 0f;
                whenNextMove = Random.Range(10,15);
                AmeliaTell();
            }
        }
        if(state == 1 && timepassed >= 30f){
            state = 2; //Ranges should be shorter than Normal
            attackTresh = Random.Range(5,10);
            whenNextMove = Random.Range(5,10);
        }
        if(state == 0 && timepassed >= 10f){
            state = 1;
            timepassed =0f;
        }
    }
    void AmeliaMoves(){
        //All of this is less temporary
        int move_to = Random.Range(1,13);
        if(move_to == 1){
            transform.position = new Vector3(1,5,25);
        }
        if(move_to == 2){
            transform.position = new Vector3(32,5,34);
        }
        if(move_to == 3){
            transform.position = new Vector3(-32,5,34);
        }
        if(move_to == 4){
            transform.position = new Vector3(17,5,53);
        }
        if(move_to == 5){
            transform.position = new Vector3(-17,5,53);
        }
        if(move_to == 6){
            transform.position = new Vector3(0,5,66);
        }
        if(move_to == 7){
            transform.position = new Vector3(0,5,52);
        }
        if(move_to == 8){
            transform.position = new Vector3(22,5,30);
        }
        if(move_to == 9){
            transform.position = new Vector3(-22,5,30);
        }
        if(move_to == 10){
            transform.position = new Vector3(30,5,50);
        }
        if(move_to == 11){
            transform.position = new Vector3(-30,5,50);
        }
        if(move_to == 12){
            transform.position = new Vector3(18,5,64);
        }
        if(move_to == 13){
            transform.position = new Vector3(-18,5,64);
        }
    }
    void AmeliaTell(){
        audio.PlayOneShot(beep, 0.5f);
    }
    void Amelia_Attack(){
        audio.PlayOneShot(death, 1f);
    }
}
