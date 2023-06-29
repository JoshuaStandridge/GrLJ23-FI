using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKey(KeyCode.E)) {
                //Debug.Log(inkJSON.text);
                DialManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
