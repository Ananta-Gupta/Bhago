using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Vector2 targetPos;
    public float xincrement;

    public float speed;
    private readonly float minPos = -1.5f;
    private readonly float maxPos = 1.5f;

    public int health = 3;

    public Text healthText;
    public GameObject gameOver;

    private void Start()
    {
        targetPos = new Vector2(0, -2);
    }

    private void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPos.x < 0 && transform.position.x > minPos)
                targetPos = new Vector2(transform.position.x - xincrement, -2);
            else if (touchPos.x > 0 && transform.position.x < maxPos)
                targetPos = new Vector2(transform.position.x + xincrement, -2);
        }

        /*if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minPos)
        {
            targetPos = new Vector2(transform.position.x - xincrement, -2);
        }else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxPos)
        {
            targetPos = new Vector2(transform.position.x + xincrement, -2);
        }*/
    }
}
