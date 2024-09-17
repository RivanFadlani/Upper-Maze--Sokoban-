using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    public float moveSpeed;
    public float gridSize;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private Vector2 desiredPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        desiredPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mendapatkan input pergerakan
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Menghitung posisi tujuan berdasarkan input pergerakan
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        desiredPosition += movement * gridSize;

        // Mendeteksi apakah petak tujuan sudah terhalang oleh dinding
        Collider2D hitCollider = Physics2D.OverlapCircle(desiredPosition, 0.1f, wallLayer);
        if (hitCollider == null)
        {
            // Jika tidak terhalang, pindahkan pemain ke posisi tujuan
            rb.MovePosition(Vector2.MoveTowards(transform.position, desiredPosition, moveSpeed * Time.deltaTime));
        }
    }
}
