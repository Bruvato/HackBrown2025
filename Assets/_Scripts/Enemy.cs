using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats enemyStatsScriptableObject;
    EnemyMoveStateMachine moveStateMachine = new EnemyMoveStateMachine();
    [HideInInspector] private GameObject player;

    [HideInInspector]
    public float speed, moveDist,
    maxSpeed, dragMultiplier, rotationSpeed, distanceToPlayer;
    private bool chasing, floating, orbiting, retreating;
    private string movementMode, enemyType;
    private string lastMode;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GetComponent<HealthComponent>().OnDeath += Enemy_OnDeath;

        enemyType = enemyStatsScriptableObject.enemyType;

        speed = enemyStatsScriptableObject.speed;

        maxSpeed = enemyStatsScriptableObject.maxSpeed;

        moveDist = enemyStatsScriptableObject.moveDist;

        dragMultiplier = enemyStatsScriptableObject.dragMultiplier;

        rotationSpeed = enemyStatsScriptableObject.rotationSpeed;

        // orbitRadius = enemyStatsScriptableObject.orbitRadius;
        // retreatRadius = enemyStatsScriptableObject.retreatRadius;

        gameObject.GetComponent<Rigidbody>().maxLinearVelocity = maxSpeed;

        movementMode = enemyStatsScriptableObject.initialMovementMode;
        switch (movementMode)
        {
            case "chase":
                moveStateMachine.ChangeState(new EnemyChaseState(this));
                break;
            case "orbit":
                moveStateMachine.ChangeState(new EnemyOrbitState(this));
                break;

        }
    }

    private void Enemy_OnDeath(object sender, System.EventArgs e)
    {
        GameManager.Instance.UpdateEnemyCount();
        Destroy(gameObject);
    }


    void Start()
    {
        player = Player.Instance.gameObject;

    }

    void Update()
    {
        moveStateMachine.Update();

        distanceToPlayer = (transform.position - player.transform.position).magnitude;
        //Debug.Log(enemyType);

        switch (enemyType)
        {
            case "chaser":
                break;
            case "Boss":
                break;
            case "shooter":
                if (distanceToPlayer < 6)
                {
                    changeMovementMode("retreat");
                }
                else if (distanceToPlayer < 9)
                {
                    changeMovementMode("orbit");
                }
                else
                {
                    changeMovementMode("chase");
                }
                break;
            case "bigGuy":
                if (distanceToPlayer < 15)
                {
                    changeMovementMode("retreat");
                }
                else if (distanceToPlayer > 30)
                {
                    changeMovementMode("chase");
                }
                else
                {
                    changeMovementMode("float");
                }
                break;

        }
    }
    void typePathing()
    {


    }

    void changeMovementMode(string mode)
    {
        if (lastMode != mode)
        {
            lastMode = mode;
            switch (mode)
            {
                case "chase":
                    moveStateMachine.ChangeState(new EnemyChaseState(this));
                    break;
                case "orbit":
                    moveStateMachine.ChangeState(new EnemyOrbitState(this));
                    break;
                case "retreat":
                    moveStateMachine.ChangeState(new EnemyRetreatState(this));
                    break;
                case "float":
                    moveStateMachine.ChangeState(new EnemyFloatState(this));
                    break;

            }
        }
    }

    public void Damage(float damageAmount)
    {
        GetComponent<HealthComponent>().Damage(damageAmount);
    }


}
