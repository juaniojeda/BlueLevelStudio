using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform paddleTransform;
    public float paddleSpeed = 5f;
    public float paddleWidth = 3f;
    public float paddleHeight = 0.5f;
    public float screenLeft = -8f;
    public float screenRight = 8f;

    private PaddlePhysics paddlePhysics = new PaddlePhysics();

    private void Update()
    {
        paddlePhysics.Frame();
    }

    private void Start()
    {
        paddlePhysics.Initiate(paddleTransform, paddleSpeed, paddleWidth, paddleHeight, screenLeft, screenRight);
    }
}