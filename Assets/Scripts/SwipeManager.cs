using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector2 targetPos;

    public float xIncrement;

    public float speed;
    private readonly float minPos = -1f;
    private readonly float maxPos = 1f;

    public void Start()
    {
        targetPos = new Vector2(0, -4);
    }

    private void Update()
    {
        if (swipeControls.SwipeLeft && player.transform.position.x > minPos)
            targetPos = new Vector2(player.transform.position.x - xIncrement, -4);
        if (swipeControls.SwipeRight && player.transform.position.x < maxPos)
            targetPos = new Vector2(player.transform.position.x + xIncrement, -4);

        player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos, speed * Time.deltaTime);
    }
}
