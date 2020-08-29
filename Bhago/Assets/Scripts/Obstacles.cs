using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public Animator animator;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            animator.SetTrigger("Shake");
            collision.GetComponent<PlayerManager>().health -= damage;
            Destroy(gameObject);
        }
    }
}
