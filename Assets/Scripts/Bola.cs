using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool puedoLanzar = true;
    private int lives = 3;
    private int score = 0;

    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private GameObject pala;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoLanzar == true)
        {
            //1. Me desemparento.
            transform.SetParent(null);
            //2. Bola pasa a dinámico (con físicas)
            rb.isKinematic = false;
            //3. Se aplica un impulso.
            rb.AddForce(new Vector2(1, 1).normalized * 10, ForceMode2D.Impulse);
            puedoLanzar = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("ZonaDeMuerte"))
        {
            ResetearBola();
        }
    }

    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("Bloque"))
        {
            Destroy(elOtro.gameObject);
            score++;
            textoScore.text = "Score: " + score;
        }
    }

    private void ResetearBola()
    {
        //0. Suprimimos la velocidad que traigamos.
        rb.velocity = Vector2.zero;
        //1. Paso de nuevo a cinemático (no físicas)
        rb.isKinematic = true;
        //2. Volvemos a emparentar la bola.
        transform.SetParent(pala.transform);
        //3. Recolocamos la bola.
        transform.localPosition = new Vector3(0, 1, 0);
        puedoLanzar = true;
        lives--;
        textoVidas.text = "Lives: " + lives;
    }
}
