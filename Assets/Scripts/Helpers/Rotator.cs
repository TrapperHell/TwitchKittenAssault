using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotateSpeed = 5f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, this.RotateSpeed * Time.deltaTime));
    }
}