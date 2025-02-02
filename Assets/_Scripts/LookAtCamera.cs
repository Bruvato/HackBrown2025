using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        //transform.LookAt(Camera.main.transform);

        //Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
        //transform.LookAt(transform.position + dirFromCamera);

        transform.forward = -Camera.main.transform.forward;
    }

}
