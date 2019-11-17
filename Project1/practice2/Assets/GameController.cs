using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject BallTemplate;
    public Text FirstPlayerScore;
    public Text SecondPlayerScore;

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
                SecondPlayerScoreCounter++;
                SecondPlayerScore.text = 
                    SecondPlayerScoreCounter.ToString();
            }
            else
            {
                FirstPlayerScoreCounter++;
                FirstPlayerScore.text =
                    FirstPlayerScoreCounter.ToString();
            }

            Destroy(ball);
            Instantiate(BallTemplate);
        }
    }
    
}
