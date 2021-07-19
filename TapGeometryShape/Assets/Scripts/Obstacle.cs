using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    public ShapesList.Shapes Shape;

    public void DestroyObstacle()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(transform.position.x, movementSpeed * Time.deltaTime);
    }

}
