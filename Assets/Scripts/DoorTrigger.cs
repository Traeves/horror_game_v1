using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [Header("Door Animators")]
    [SerializeField] private Animator LeftDoor = null;
    [SerializeField] private Animator RightDoor = null;
    [Header("Door Triggers")]
    [Tooltip("Which animation does this trigger signal")]
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                LeftDoor.Play("LeftDoorOpen", 0, 0.0f);
                RightDoor.Play("RightDoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if(closeTrigger)
            {
                LeftDoor.Play("LeftDoorClose", 0, 0.0f);
                RightDoor.Play("RightDoorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
