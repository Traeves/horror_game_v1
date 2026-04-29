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
    public AudioClip humming;
    public AudioClip iknowyou;
    public AudioClip runfast;
    public AudioClip findyou;
    public AudioClip foundyou;
    public AudioClip death;
    public GameObject BanshimentItem;
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
        if(move_to == 1 && rm.Player_Room != 1){// Foyer
            int foyer = Random.Range(1,4);
            if(foyer == 1)
            {
                transform.position = new Vector3(10.8f,3.65f,23f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if(foyer == 2)
            {
                transform.position = new Vector3(1.5f,3f,26.5f);
                transform.rotation = Quaternion.Euler(0, 160, 0);
            }
            else if(foyer == 3)
            {
                transform.position = new Vector3(-10.5f,4f,16.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(foyer == 4)
            {
                transform.position = new Vector3(-9.75f,4f,39.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(move_to == 2 && rm.Player_Room != 2){//Left Exhibit
            int LE = Random.Range(1,2);
            if(LE == 1)
            {
                transform.position = new Vector3(-30f,4f,28.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(LE == 2)
            {
                transform.position = new Vector3(-33.8f,3f,28.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.position = new Vector3(-37.6f,5.1f,37f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        if(move_to == 3 && rm.Player_Room != 3){//Top left Exhibit
            int TLE = Random.Range(1,3);
            if(TLE == 1)
            {
                transform.position = new Vector3(-11.55f,3.65f,53.25f);
                transform.rotation = Quaternion.Euler(75, 0, 0);
            }
            else if(TLE == 2)
            {
                transform.position = new Vector3(-11.8f,3.65f,55.5f);
                transform.rotation = Quaternion.Euler(0, 55, 0);
            }
            else if(TLE == 3)
            {
                transform.position = new Vector3(-12.74f,3.095f,57.542f);
                transform.rotation = Quaternion.Euler(0, 50, 0);
            }
            else if(TLE == 4)
            {
                transform.position = new Vector3(20.5f,3.095f,54.3f);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if(move_to == 4&& rm.Player_Room != 4){//Backroom
            transform.position = new Vector3(0,5,66);
        }
        if(move_to == 5&& rm.Player_Room != 5){//Main Hall
            transform.position = new Vector3(0,5,52);
        }
        if(move_to == 6&& rm.Player_Room != 6){//Left Hall
            transform.position = new Vector3(-21,3,31);
            if(rm.Player_Room == 2 || rm.Player_Room == 3 || rm.Player_Room == 7 || rm.Player_Room == 8)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if(move_to == 7&& rm.Player_Room != 7){//Left Hall to Exhibit 3
            transform.position = new Vector3(-31,3.095f,50);
            if(rm.Player_Room == 1 || rm.Player_Room == 2 || rm.Player_Room == 6)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if(move_to == 8&& rm.Player_Room != 8){//Left Hall to Backroom
            transform.position = new Vector3(-18,5,64);
            if(rm.Player_Room == 4 || rm.Player_Room == 5 || rm.Player_Room == 1)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    void AmeliaTell(){
        audio.PlayOneShot(humming,0.2f);
    }
    void Amelia_Attack(){
        audio.PlayOneShot(foundyou,0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Happened");
        if(collision.gameObject == BanshimentItem)
        {
            audio.PlayOneShot(death, 0.5f);
            //gameObject.SetActive(false);
        }
    }
}
