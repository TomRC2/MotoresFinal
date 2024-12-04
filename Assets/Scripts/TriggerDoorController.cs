using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Text ObjetiveText;
    public Animator doorAnimator;
    public string openTriggerName = "DoorOpen";
    public string closeTriggerName = "DoorClose";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "OpenTrigger")
            {
                doorAnimator.SetTrigger(openTriggerName);
            }
            else if (gameObject.name == "CloseTrigger")
            {
                doorAnimator.SetTrigger(closeTriggerName);
                ObjetiveText.text = "Objetive: Finish The Dealers";
            }
        }
    }
}