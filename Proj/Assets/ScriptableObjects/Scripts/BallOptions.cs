
using UnityEngine;

[CreateAssetMenu]
public class BallOptions : ScriptableObject
{
    public Vector3 StartPosition = Vector3.zero;
    public Vector3 StartScale = Vector3.one;
    public float StartSpeed = 1;
    public float SpeedAcceleration = 5;
    public float MaxSpeed = 40;
    public float CoefChangeScale = 0.1f;
}
