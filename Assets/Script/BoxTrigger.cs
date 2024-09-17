using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void changesprite()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        changesprite();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        changesprite();
    }
}
