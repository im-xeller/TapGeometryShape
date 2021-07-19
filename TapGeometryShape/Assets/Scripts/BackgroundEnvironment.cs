using UnityEngine;

public class BackgroundEnvironment : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private void OnEnable()
    {
        Invoke("DestroyEnvironment", 3f);
    }

    private void DestroyEnvironment()
    {
        Destroy(gameObject);
    }
}
