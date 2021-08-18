using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int health = 3;

    public Text healthText;
    public GameObject gameOver;

    private void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
