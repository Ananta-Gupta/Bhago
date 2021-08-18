using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed;

    public float endY;
    public float startY;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
