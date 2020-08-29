using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().health -= damage;
            Debug.Log(collision.GetComponent<PlayerManager>().health);
            Destroy(gameObject);
        }
    }
}
