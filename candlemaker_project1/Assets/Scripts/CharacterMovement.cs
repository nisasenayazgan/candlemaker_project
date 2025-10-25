using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Hız
    private Animator anim;
    private SpriteRenderer sprite;
    private bool candleLit = false; // Mum yanıp yanmadığını tutar
    public FireLightController candleLight; // Inspector’dan atanacak
    private Rigidbody2D rb; // Rigidbody referansı

    void Start()
    {
        
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody referansı

        // Player her zaman görünür olsun
        Color c = sprite.color;
        c.a = 1f; // Player alpha = 1
        sprite.color = c;
    

        Debug.Log("SpriteRenderer: " + sprite + ", Sprite: " + sprite.sprite);

    }

    void Update()
    {
        // 1️⃣ İlk click: mumu yak
        if (!candleLit && Input.GetMouseButtonDown(0))
        {
            candleLight.LightUp(); // Mum ışığını fade-in başlat
            candleLit = true;      // Karakter artık hareket edebilir

            // Siyah overlay fade-out başlasın
            FindObjectOfType<FadeController>().StartFadeOut();
        }

        // 2️⃣ Mum yanmadıysa hareket etme
        if (!candleLit)
            return; // Mum yanmadan önce karakter sabit kalır

        // 3️⃣ Karakter hareketi
        float move = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
            sprite.flipX = false; // Sağa bak
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
            sprite.flipX = true; // Sola bak
        }

        // Rigidbody ile güvenli hareket (Y sabit)
        Vector2 newPos = rb.position + Vector2.right * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPos);

        // Animator'a bilgi gönder (Idle ↔ Walk)
        if (anim != null)
            anim.SetBool("isWalking", move != 0);
    }
}
