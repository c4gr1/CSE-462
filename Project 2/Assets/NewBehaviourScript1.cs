using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kamerayý yatay eksende döndürme
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Kamerayý dikey eksende döndürme (isteðe baðlý)
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);
    }
}

