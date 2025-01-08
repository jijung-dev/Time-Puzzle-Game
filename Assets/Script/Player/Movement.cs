using UnityEngine;

public class Movement : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector2.up);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2.right);
        }
    }
    void Move(Vector2 dir)
    {
        if (!Physics2D.Raycast(transform.position, dir, 1, LayerMask.GetMask("Wall")))
            transform.position += (Vector3)dir;
    }
}
