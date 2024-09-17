using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    AudioManager audioManager;

    // Start is called before the first frame update
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            audioManager.PlaySFX(audioManager.endPointSFX);
            WinCondition.winCondition.boxComplete.Add(gameObject.name);
            WinCondition.winCondition.checkWin();
        }
    }

}
