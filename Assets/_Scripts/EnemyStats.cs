using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] public float speed;//frequency of dashes
    [SerializeField] public float maxSpeed;
    [SerializeField] public float moveDist;//force of dashes
    [SerializeField] public float dragMultiplier;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public string initialMovementMode;//chase, orbit, swarm boss, drifting
    // [SerializeField] public float orbitRadius, retreatRadius;
    [SerializeField] public string enemyType; //chaser, shooter, big guy, drone, boss





}
