using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public static BallPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            pool.Enqueue(ball);
        }
    }

    public GameObject GetBall(Vector3 position)
    {
        GameObject ball = pool.Count > 0 ? pool.Dequeue() : Instantiate(ballPrefab);

        ball.transform.position = position;
        ball.SetActive(true);

        return ball;
    }

    public void ReturnBall(GameObject ball)
    {
        ball.SetActive(false);
        pool.Enqueue(ball);
    }
}
