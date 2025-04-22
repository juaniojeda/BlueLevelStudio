using UnityEngine;

[CreateAssetMenu(fileName = "ScreenEdges", menuName = "ScriptableObjects/ScreenEdgesSO")]
public class ScreenEdgesSO : ScriptableObject
{
    public float left = -8f;
    public float right = 8f;
    public float up = 5f;
    public float down = -5f;
}