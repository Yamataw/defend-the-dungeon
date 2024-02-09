using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speed = 0.25f; 
    private bool moveRight = true;

    void Update()
    {
        float movement = speed * Time.deltaTime;

        if (moveRight)
        {
            transform.Translate(Vector3.right * movement);
        }
        else
        {
            transform.Translate(Vector3.left * movement);
        }

        if (transform.position.x >= 6.0f) 
        {
            moveRight = false;
        }

        if (transform.position.x <= -6.0f)
        {
            moveRight = true;
        }
    }
}
