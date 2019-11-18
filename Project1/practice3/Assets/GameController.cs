using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject BallTemplate;
    public Text FirstPlayerScore;
    public Text SecondPlayerScore;
    private int LastPlayer = -1;

    private int FirstPlayerScoreCounter = 0;
    private int SecondPlayerScoreCounter = 0;

    void OnTriggerExit(Collider collider)
    {
        GameObject gameObject = collider.gameObject;

        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = collider.gameObject;

            if (ball.transform.position.x < transform.position.x)
            {
                LastPlayer = 2;
                SecondPlayerScoreCounter++;
                SecondPlayerScore.text =
                    SecondPlayerScoreCounter.ToString();
            }
            else
            {
                LastPlayer = 1;
                FirstPlayerScoreCounter++;
                FirstPlayerScore.text =
                    FirstPlayerScoreCounter.ToString();
            }

            ball.GetComponent<BallController>().LastPlayer = LastPlayer;

            Instantiate(ball, new Vector3(0, 0.5f, 0), Quaternion.identity);

            Destroy(ball);
        }
    }
    
}
