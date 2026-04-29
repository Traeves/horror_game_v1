using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmeliaBehavoiur : MonoBehaviour
{
    public int state = 0; // 0 = Neutral, 1 = Roaming, 2 = Aggresive
    public float timepassed = 0f;
    private int survivedAttacks = 0;
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
    public AudioClip death;
    public GameObject BanshimentItem;

    [Header("Jump Scare Settings")]
    public Transform xrCamera;
    public float distanceFromFace = 0.4f;
    public float scareHoldTime = 2f;
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;
    public string deathSceneName = "DeathScene";

    private bool isDead = false;
    private bool isDefeated = false;

    void Start()
    {
        attackTresh = Random.Range(20, 31);
        whenNextMove = Random.Range(15, 21);
        audio = GetComponent<AudioSource>();

        if (xrCamera == null)
            xrCamera = Camera.main.transform;
    }

    void Update()
    {
        if(isDead || isDefeated) return;

        timepassed += Time.deltaTime; // Track the amount of Time passed
        if(state == 2 && rm.Player_Room == rm.Amelia_Room ){//Aggresive Gain Anger: 1 Anger per 2 seconds
            angerTimer += Time.deltaTime;//Time between Anger Increasing
            if(angerTimer > 2){
                angerTimer=0;
                if(attackTresh < anger){ //Attempts to Attack
                    anger = 0;
                    Amelia_Attack();
                }
                anger++;
            }
        }
        if(state == 2 && rm.Player_Room != rm.Amelia_Room ){//Aggresive Move
            move += Time.deltaTime;
            if(move > whenNextMove){
                AmeliaMoves(-1);//She can move into the same room as you
                move = 0f;
                whenNextMove = Random.Range(5, 11);
                AmeliaTell();
            }
        }
        if(state == 1 && rm.Player_Room == rm.Amelia_Room ){//Normal Gain Anger: 1 Anger per 2.5 seconds
            angerTimer += Time.deltaTime;
            if (angerTimer > 2.5)
            {
                angerTimer = 0;
                if (attackTresh < anger)
                {
                    Amelia_Attack();
                }
                anger++;
            }
        }
        if(state == 1 && rm.Player_Room != rm.Amelia_Room ){//Normal Move
            move += Time.deltaTime;
            if(move > whenNextMove){
                AmeliaMoves(rm.Player_Room);//She Cannot move into the same room as the player
                move = 0f;
                whenNextMove = Random.Range(10,26);
                if(anger > 0) anger--;//Anger Reduces in Normal Mode
                AmeliaTell();
            }
        }
        if(state == 1 && timepassed >= 90f){//Normal To Aggresive: 1 Minute 30 Seconds
            state = 2; //Ranges should be shorter than Normal
            attackTresh = Random.Range(10,21);
            whenNextMove = Random.Range(5,11);
        }
        if(state == 0 && timepassed >= 30f){//Neutral To Normal: 30 Seconds
            state = 1;
            timepassed = 0f;
        }
    }
    void AmeliaMoves(int room){
        //All of this is less temporary
        int move_to = Random.Range(1,9);
        if(move_to == 1 && room != 1){// Foyer
            int foyer = Random.Range(1,5);
            if(foyer == 1)
            {
                transform.position = new Vector3(10.8f, 3.65f, 23f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (foyer == 2)
            {
                transform.position = new Vector3(1.5f, 3f, 26.5f);
                transform.rotation = Quaternion.Euler(0, 160, 0);
            }
            else if (foyer == 3)
            {
                transform.position = new Vector3(-10.5f, 4f, 16.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (foyer == 4)
            {
                transform.position = new Vector3(-9.75f, 4f, 39.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(move_to == 2 && room != 2){//Left Exhibit
            int LE = Random.Range(1,3);
            if(LE == 1)
            {
                transform.position = new Vector3(-30f, 4f, 28.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (LE == 2)
            {
                transform.position = new Vector3(-33.8f, 3f, 28.5f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.position = new Vector3(-37.6f, 5.1f, 37f);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        if(move_to == 3 && room != 3){//Top left Exhibit
            int TLE = Random.Range(1,5);
            if(TLE == 1)
            {
                transform.position = new Vector3(-11.55f, 3.65f, 53.25f);
                transform.rotation = Quaternion.Euler(75, 0, 0);
            }
            else if (TLE == 2)
            {
                transform.position = new Vector3(-11.8f, 3.65f, 55.5f);
                transform.rotation = Quaternion.Euler(0, 55, 0);
            }
            else if (TLE == 3)
            {
                transform.position = new Vector3(-12.74f, 3.095f, 57.542f);
                transform.rotation = Quaternion.Euler(0, 50, 0);
            }
            else if (TLE == 4)
            {
                transform.position = new Vector3(20.5f, 3.095f, 54.3f);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if(move_to == 4&& room != 4){//Backroom
            int TLE = Random.Range(1,3);
            if(TLE == 1)
            {
                transform.position = new Vector3(-7.92f, 3.909f, 66f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (TLE == 2)
            {
                transform.position = new Vector3(-0.045f, 3.043f, 63.675f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(move_to == 5&& room != 5){//Main Hall
            int TLE = Random.Range(1,3);
            if(TLE == 1)
            {
                transform.position = new Vector3(-2.578f, 3.12f, 53.59f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (TLE == 2)
            {
                transform.position = new Vector3(-2.64f, 3.12f, 48.31f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(move_to == 6&& room != 6){//Left Hall
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
        if(move_to == 7&& room != 7){//Left Hall to Exhibit 3
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
        if(move_to == 8&& room != 8){//Left Hall to Backroom
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
        if(state == 1)
        {
            int tell = Random.Range(1,16);
            if(tell == 1)
            {
                audio.PlayOneShot(humming, 0.2f);
            }
            else if(tell == 4)
            {
                audio.PlayOneShot(runfast,0.2f);
            }
            else if (tell == 6)
            {
                audio.PlayOneShot(iknowyou,0.2f);
            }
            else if (tell == 11)
            {
                audio.PlayOneShot(findyou,0.2f);
            }
        }
        if(state == 2)
        {
            int tell = Random.Range(1,31); // She starts to get less talkative to Catch you off guard
            if(tell == 1)
            {
                audio.PlayOneShot(humming, 0.2f);
            }
            else if(tell == 4)
            {
                audio.PlayOneShot(runfast,0.2f);
            }
            else if (tell == 6)
            {
                audio.PlayOneShot(iknowyou,0.2f);
            }
            else if (tell == 11)
            {
                audio.PlayOneShot(findyou,0.2f);
            }
        }
    }

    void Amelia_Attack()
    {
        if(state == 1) // Attack in the normal state
        {
            int attack = Random.Range(1,4) + survivedAttacks;
            if (attack >= 4)
            {
                isDead = true;
                //audio.PlayOneShot(foundyou, 0.5f);
                StartCoroutine(JumpScareSequence());
            }
            else
            {
                attackTresh = Random.Range(20,30) - (survivedAttacks*2);
                whenNextMove = Random.Range(10,25) - (survivedAttacks*2);
            }
        }
        else{ // Attack in the Aggresive state
            int attack = Random.Range(1,3) + survivedAttacks;
            if (attack >= 2)
            {
                isDead = true;
                //audio.PlayOneShot(foundyou, 0.5f);
                StartCoroutine(JumpScareSequence());
            }
            else
            {
                attackTresh = Random.Range(10,20) - (survivedAttacks*2);
                whenNextMove = 5;
            }
        }

        
    }

    IEnumerator JumpScareSequence()
    {
        // 1. Teleport to player's face
        Vector3 facePosition = xrCamera.position + xrCamera.forward * distanceFromFace;
        transform.position = facePosition;
        transform.LookAt(xrCamera.position);
        transform.Rotate(0f, 180f, 0f);

        // 2. Hold the scare
        yield return new WaitForSecondsRealtime(scareHoldTime);

        // 3. Fade to black
        float elapsed = 0f;
        fadeCanvas.alpha = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        // 4. Reset timeScale in case paused, then load death scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(deathSceneName);
    }

    IEnumerator WinSequence()
    {
        // Play death sound, disable Amelia so she vanishes
        //audio.PlayOneShot(death, 0.5f);
        //gameObject.active = false;

        // Brief pause so the sound plays before fading
        yield return new WaitForSecondsRealtime(1.5f);

        // Fade to black then load win scene
        float elapsed = 0f;
        fadeCanvas.alpha = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("WinScene");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Happened");
        if (collision.gameObject == BanshimentItem && !isDefeated)
        {
            isDefeated = true;
            StartCoroutine(WinSequence());
        }
    }
}