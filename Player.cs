using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Zmienna wpływa na renderowanie obrazka ketczupa
    // Używam tej zmiennej, aby zamigotwać graczem po otrzymaniu obrażeń 
    public SpriteRenderer spriterenderer;
    public int MaxHealth = 100;
    private int CurrentHealth;
    public SliderInHealth HealthBar;
    // zmienna ograniczająca ruch gracza
    public float Mapborder;
    //---------------------------------------------
    // Glowna wysokosc skoku gracza
    public float JumpHight;
    //---------------------------------------------
    Rigidbody2D rb;
    public float MoveSpeed;
    public float MaxSpeed;
    //---------------------------------------------
    public bool isGrounded;
    // Zmienne do wyrycia podłoża
    public Transform feetPos;
    public float checkRadious;
    public LayerMask whatisGround;
    //---------------------------------------------
    // Dwie zmienne potrzebne do mechanizmu wykrycia
    // dwóch skoków (boost)
    private bool firstJump;
    private bool secondJump;
    // Dwie zmienne do przechowywania czasu między skokiem
    // na platformach
    private float startTime;
    private float endTime;
    // O ile zwiększych Y i X prędkość gracza (boost)
    public float Yboost;
    public float Xboost;
    // Czas w którym gracz musi skoczyć na drugą platforme
    // aby otrzymać boost
    public float boostTimeBorder;
    // Czy gracz posiada boost
    public bool isBoosted;
    // Aktualny boost gracza
    private float YBoostCurrent;
    private float XBoostCurrent;
    // Zmienne określające jaką największą wartość boosta
    // może posiadać gracz
    public float MaxBoostX;
    public float MaxBoostY;
    //---------------------------------------------
    // Zmienna przechowująca ostatnią prędkość gracza
    // Zmienna jest potrzebna aby odpowiednio odbić gracza od granicy
    Vector2 lastVelocity;
    // Zmienna aby gracz nie mógł się poruszyć po odbiciu od ściany
    private bool stop;
    //----------------------------------------------
    // dust - Partcle dymu przy chodzeniu
    // boost - pierwszy ogień przy boostcie
    // smoke -  dym po ogniu przy boostcie
    public ParticleSystem dust;
    public ParticleSystem boost;
    public ParticleSystem smoke;
    
    void Start()
    {      
        rb = GetComponent<Rigidbody2D>();
        stop = false;
        firstJump = false;
        secondJump = false;
        startTime = 0;
        endTime = 0;
        YBoostCurrent = Yboost;
        XBoostCurrent = Xboost;

        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }
    private void FixedUpdate()
    { 
       isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious, whatisGround);     
    }
   
    void Update()
    {
        // Ciągłe pobieranie vektora prędkości gracza i przypisywanie go do zmiennej 
        lastVelocity = rb.velocity;
        
        // jeżeli gracz jest w powierzu i prędkośc jest równa 0.3f to przestań emitować dym
        // 0.3 bo trochę wcześniej nż 0 trzeba wyłaczyć dym
        if(!isGrounded && rb.velocity.y == 0.3f)
            smoke.Stop();
        
        // Jeżeli gracz jest na ziemi to może skoczyć
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !stop)
        {
            if (rb.velocity.y < JumpHight)
                rb.velocity = Vector2.up * JumpHight;

         //   Audio.PlayJump();
            playerBoost();
        }
        
        // Ruch gracza w prawo
        if (Input.GetKey(KeyCode.D) && !stop)
        {
            // nie można przekroczyć maxSpeed
            if ( rb.velocity.x <= MaxSpeed)
            rb.velocity += new Vector2(MoveSpeed, 0);
        }

        // Ruch gracza w lewo 
        if (Input.GetKey(KeyCode.A) && !stop)
        {
            if( rb.velocity.x >= -MaxSpeed)
            rb.velocity += new Vector2(-MoveSpeed, 0);
        }

        // Jeżeli gracz jest na ziemi i się rusza uruchom animację chodzenia
        if (rb.velocity.x != 0 && isGrounded)
        {
            Anim.Running(true);
        }

        //  Jeżeli gracz jest na ziemi i się nie rusza to uruchom animację stania
        if (rb.velocity.x == 0 && isGrounded)
            Anim.Running(false);

        if (!isGrounded)
            dust.Stop();
        if(isGrounded && rb.velocity.x!=0)
            dust.Play();



        //Animacja chodzenia w prawo i lewo
        // anim.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

    }

    //Funkcja po zebraniu przez gracza coina usuwa go
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))                                    
        {
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {

        CurrentHealth -= damage;
        //aktualnizacja suwaka
        HealthBar.SetHealth(CurrentHealth);

        /*
        object.TransparencyAfterDamage();
        player.Invoke("TransparencyBeforeDamage", 0.1f);
        player.Invoke("TransparencyAfterDamage", 0.2f);
        player.Invoke("TransparencyBeforeDamage", 0.3f);
        player.Invoke("TransparencyAfterDamage", 0.4f);
        player.Invoke("TransparencyBeforeDamage", 0.5f);
        */
        
    }
    public void TransparencyAfterDamage()
    {
        spriterenderer.enabled = false;
      
    }
    public void TransparencyBeforeDamage()
    {
        spriterenderer.enabled = true;
    }

    // Funkcja dodająca boosta do gracza
    public void playerBoost()
    {

        if (endTime - startTime < boostTimeBorder && endTime - startTime > 0 && firstJump && secondJump)
        {
            if (isBoosted && YBoostCurrent <= MaxBoostY)
                YBoostCurrent += Yboost;

            if (isBoosted && XBoostCurrent <= MaxBoostY)
                XBoostCurrent += Xboost;


            if (rb.velocity.x >= 0)
                rb.velocity += new Vector2(XBoostCurrent, YBoostCurrent);
            if (rb.velocity.x <= 0)
                rb.velocity += new Vector2(-XBoostCurrent, YBoostCurrent);

            isBoosted = true;
            boost.Play();

            var main = smoke.main;
            main.duration = YBoostCurrent / 4;
            main.startLifetime = YBoostCurrent / 4 - 0.3f;
            smoke.Play();
            firstJump = false;
            secondJump = false;
        }
        else if ((endTime - startTime > boostTimeBorder || endTime - startTime < 0) && firstJump && secondJump)
        {
            YBoostCurrent = Yboost;
            XBoostCurrent = Xboost;

            isBoosted = false;
            boost.Stop();

            firstJump = false;
            secondJump = false;
        }

        if (firstJump && !secondJump)
        {
            secondJump = true;
            endTime = Time.time;
        }
        if (!firstJump && !secondJump)
        {
            firstJump = true;
            startTime = Time.time;
        }
    }
    // Funkcja odbijąjąca gracza od granicy
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);

            
            StartCoroutine(ExampleCoroutine());
        }
    }
    // Opóźnienie, program zatrzymuje się tutaj na chwile
    IEnumerator ExampleCoroutine()
    {
        stop = true;
        yield return new WaitForSeconds(0.2f);
        stop = false;
    }
   
}
