using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. Nos movemos libremente.
        float inputH = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(inputH, 0, 0) * velocidad * Time.deltaTime);

        //2. Delimito el movimimento por si me salgo de los márgenes.
        float xDelimitada = Mathf.Clamp(transform.position.x, -4.25f, 4.25f);
        transform.position = new Vector3(xDelimitada, transform.position.y, transform.position.z);
    }
}
