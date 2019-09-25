using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static event System.Action OnTriggerGorizontBorder;

    [SerializeField] private SpriteRenderer SpriteBall = null;
    [SerializeField] private Rigidbody2D BodyBall = null;

    private float Speed;
    private Vector3 Direction;
    private bool GameRunning = false;

    private void Awake()
    {
        GameController.OnStartGame += GameController_OnStartGame;
        GameController.OnFinishGame += GameController_OnFinishGame;
    }

    private void GameController_OnFinishGame()
    {
        StopCoroutine("SpeedAccelerationRoutine");
        GameRunning = false;
    }

    private void GameController_OnStartGame()
    {
        Initializate();
    }

    private void Initializate()
    {
        gameObject.SetActive(true);
        transform.position = Options.Instance.BallOptions.StartPosition;
        Speed = Options.Instance.BallOptions.StartSpeed;
        Direction = new Vector2(Random.Range(0.2f, 1.0f) * (Random.Range(0, 2) > 0 ? 1 : -1), Random.Range(0, 2) > 0 ? 1 : -1);

        float coefChangeScale = Random.Range(1 - Options.Instance.BallOptions.CoefChangeScale, 1 + Options.Instance.BallOptions.CoefChangeScale);
        transform.localScale = Options.Instance.BallOptions.StartScale * coefChangeScale;

        SpriteBall.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        StartCoroutine(SpeedAccelerationRoutine());
        GameRunning = true;
    }

    private IEnumerator SpeedAccelerationRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Speed += Options.Instance.BallOptions.SpeedAcceleration;
            if (Speed > Options.Instance.BallOptions.MaxSpeed)
            {
                Speed = Options.Instance.BallOptions.MaxSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "GorizontBorder")
        {
            Direction = Vector2.Reflect(Direction, other.transform.right);
        }
        else
        {
            gameObject.SetActive(false);
            OnTriggerGorizontBorder?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (GameRunning)
        {
            BodyBall.MovePosition(transform.position + Direction * Speed * Time.fixedDeltaTime);
        }
    }
    private void OnDestroy()
    {
        GameController.OnStartGame -= GameController_OnStartGame;
        GameController.OnFinishGame -= GameController_OnFinishGame;
    }
}
