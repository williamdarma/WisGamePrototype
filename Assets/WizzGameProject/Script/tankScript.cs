using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //rb2D.velocity = new Vector2(2, 0);
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroy"))
        {
            gameObject.SetActive(false);
        }
    }
}
