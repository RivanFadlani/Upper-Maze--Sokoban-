using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movementSpeed;
    public float distanceToMove;
    public Animator animator;
    private bool moveToPoint = false;
    private Vector3 endPosition;

    AudioManager audioManager;

    // Start is called before the first frame update
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        endPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (!moveToPoint)
        {
            animator.SetFloat("Speed", 0f);
        }

        // animator.SetFloat("Horizontal", endPosition.x);
        // animator.SetFloat("Vertical", endPosition.y);
        // animator.SetFloat("Speed", endPosition.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        ableToMove();
    }

    void ableToMove() {
        if(moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                moveToPoint = false;
            }
        }
    }

    void movement() 
    {
        // if (!moveToPoint)
        {
            if (Input.GetKeyDown(KeyCode.A)) //kiri
            {
                audioManager.PlaySFX(audioManager.footstep);
                endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
                SetAnimationParameters(endPosition - transform.position);
                moveToPoint = true;
            }
            if (Input.GetKeyDown(KeyCode.D)) //kanan
            {
                audioManager.PlaySFX(audioManager.footstep);
                endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                SetAnimationParameters(endPosition - transform.position);
                moveToPoint = true;
            }
            if (Input.GetKeyDown(KeyCode.W)) //atas
            {
                audioManager.PlaySFX(audioManager.footstep);
                endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                SetAnimationParameters(endPosition - transform.position);
                moveToPoint = true;
            }
            if (Input.GetKeyDown(KeyCode.S)) //bawah
            {
                audioManager.PlaySFX(audioManager.footstep);
                endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                SetAnimationParameters(endPosition - transform.position);
                moveToPoint = true;
            }
        }
    }

    void SetAnimationParameters(Vector3 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
}
