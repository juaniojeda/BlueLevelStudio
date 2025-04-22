using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "ScriptableObjects/BallSO")]
public class BallSO : ScriptableObject
{
    public float radius = 0.5f;
    public float speed = 5f;
}
