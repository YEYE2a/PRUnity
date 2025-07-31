using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    private Vector3 puntoReaparicion;

    private bool enSuelo = false;
    private bool estaMuerto = false;
    public bool estaAtacando = false;
    private SpawnManager spawnManager;


    private float inputMovimiento = 0f;

    void Start()
    {
        spawnManager = Object.FindFirstObjectByType<SpawnManager>();
        puntoReaparicion = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (estaMuerto) return;

        inputMovimiento = 0f;
        if (Input.GetKey(KeyCode.A)) inputMovimiento = -1f;
        if (Input.GetKey(KeyCode.D)) inputMovimiento = 1f;

        if (inputMovimiento > 0) sprite.flipX = false;
        else if (inputMovimiento < 0) sprite.flipX = true;

        enSuelo = IsGrounded();
        animator.SetBool("caminar", Mathf.Abs(inputMovimiento) > 0.1f && enSuelo);
        animator.SetBool("salto", !enSuelo);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Disparar();
        }
    }

    void FixedUpdate()
    {
        if (estaMuerto) return;
        // Aquí se mueve el personaje con física
        rb.linearVelocity = new Vector2(inputMovimiento * velocidad, rb.linearVelocity.y);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider2D.bounds.center,
            boxCollider2D.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Default")
        );
        return hit.collider != null;
    }

    public void RecibirDaño(int cantidad)
    {
        if (estaMuerto) return;

        estaMuerto = true;
        animator.SetTrigger("morir");

        Invoke("Reaparecer", 1f);
    }

    void Reaparecer()
    {
        transform.position = puntoReaparicion;
        estaMuerto = false;
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger("revivir");
        GameManager.instancia?.ReiniciarPuntaje();
        FindAnyObjectByType<SpawnManager>()?.ReposicionarAInicio();
        FindAnyObjectByType<spawnEnemigo>()?.ReposicionarAInicio();
        FindAnyObjectByType<CoinGenerator>()?.ReposicionarAInicio();


    }

    void Disparar()
    {
        if (estaAtacando) return;

        estaAtacando = true;
        animator.SetTrigger("atacar");

        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        if (sprite.flipX)
        {
            Vector3 escala = bala.transform.localScale;
            escala.x *= -1;
            bala.transform.localScale = escala;

            Bala scriptBala = bala.GetComponent<Bala>();
            if (scriptBala != null)
            {
                scriptBala.velocidad *= -1;
            }
        }

        Invoke("FinAtaque", 0.3f);
    }

    void FinAtaque()
    {
        estaAtacando = false;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            RecibirDaño(1); 
        }
    }
}



