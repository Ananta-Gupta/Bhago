using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Vector2 targetPos;
    public float xincrement;

    public float speed;
    private readonly float minPos = -1.5f;
    private readonly float maxPos = 1.5f;

    public int health = 3;

    private void Start()
    {
        targetPos = new Vector2(0, -2);
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minPos)
        {
            targetPos = new Vector2(transform.position.x - xincrement, -2);
        }else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxPos)
        {
            targetPos = new Vector2(transform.position.x + xincrement, -2);
        }
    }
}
