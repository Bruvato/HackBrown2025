using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
    Enemy owner;
    Rigidbody rb;
    private bool running;
    private Transform playerTransform;
    private float distanceToPlayer;
    void Awake() 
    { 
        owner = gameObject.GetComponent<Enemy>(); 
        rb = gameObject.GetComponent<Rigidbody>();

        running = false;

    }
    void Start(){
        playerTransform = Player.Instance.transform;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Update()
    {
        Quaternion toPlayer = new();
        toPlayer.SetLookRotation(playerTransform.position-transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toPlayer, owner.rotationSpeed*Time.deltaTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(-(rb.linearVelocity*owner.dragMultiplier));
        if(!running)
        StartCoroutine(Dash());
    }
    private IEnumerator Dash() //pushes the ship forward with force proportional to moveDist and frequency = speed Hz
    {
        
        running = true;
        yield return new WaitForSeconds(1/owner.speed+Random.Range(-1,1));
        rb.AddForce(Vector3.Cross(owner.moveDist*transform.forward, Vector3.up));

        running = false;

    }
    public void DestroySelf(){
        Destroy(GetComponent<EnemyOrbit>());
    }
    
}
