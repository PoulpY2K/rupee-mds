using UnityEngine;

[CreateAssetMenu(fileName = "RupeeData", menuName = "RupeeData", order = 0)]
public class RupeeData : ScriptableObject
{
    public Color color;
    public int score;
    public float speed;
    public AudioClip collectClip;
}