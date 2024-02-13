using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public Paddle leftPaddle;
    public Paddle rightPaddle;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;
    private Vector3 ballStartPos;

    private const int scoreToWin = 11;

    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(-1f);
                leftPaddle.ResetCounter(); // Reset counter in left paddle\
                rightPaddle.ResetCounter(); // Reset counter in right paddle
            }
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");
            if (leftPlayerScore == scoreToWin)
            {
                Debug.Log("Left player wins!");
            }
            else
            {
                ResetBall(1f);
                leftPaddle.ResetCounter(); // Reset counter in left paddle
                rightPaddle.ResetCounter(); // Reset counter in right paddle
            }
        }
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;
        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();
        ball.GetComponent<TrailRenderer>().Clear();
    }
}