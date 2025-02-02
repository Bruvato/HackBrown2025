using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class EnemyFloat : MonoBehaviour
{
    Enemy owner;
    Rigidbody rb;
    private bool running;
    private Transform playerTransform;
    void Awake() 
    { 
        owner = gameObject.GetComponent<Enemy>(); 
        rb = gameObject.GetComponent<Rigidbody>();

        running = false;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = Player.Instance.transform;
        
    }
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
        //Debug.Log("Dash");
        running = true;
        yield return new WaitForSeconds(1/owner.speed+Random.Range(-1,1));

        running = false;

    }
    public void DestroySelf(){
        Destroy(GetComponent<EnemyFloat>());
    }
    
}
