using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallSO ballData;
    [SerializeField] private ScreenEdgesSO screenEdges;

    private BallPhysics physics = new BallPhysics();
    public Vector3 Direction { get; set; }

    private void Start()
    {
        BallManager.RegisterBall(this);
        Direction = BallPhysics.GetInitialDirection();

        physics.Initiate(transform, ballData, screenEdges, this);
    }

    private void OnDestroy()
    {
        BallManager.UnregisterBall(this);
    }

    public void DestroyBall()
    {
        BallManager.UnregisterBall(this);
        BallPool.Instance.ReturnBall(gameObject);

        GameObject newBall = BallPool.Instance.GetBall(Vector3.zero);
        BallController newBallController = newBall.GetComponent<BallController>();
        newBallController.Direction = BallPhysics.GetInitialDirection();
    }

    private void Update()
    {
        physics.Frame();
    }
}
