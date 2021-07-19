using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] shapes;
    private SpriteRenderer _spriteRenderer;

    private ShapesList.Shapes _shape;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _shape = ShapesList.Shapes.Circle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _shape = ShapesList.Shapes.Rectangle;
            _spriteRenderer.sprite = shapes[0];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _shape = ShapesList.Shapes.Triangle;
            _spriteRenderer.sprite = shapes[1];
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _shape = ShapesList.Shapes.Circle;
            _spriteRenderer.sprite = shapes[2];
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

        if (_shape == obstacle.Shape)
        {
            StartCoroutine(ChangeColorOnHitObstacle(Color.green));
            StartCoroutine(ChangeScaleOnHitObstacle(new Vector3(1.5f, 1.5f, 1f)));

            obstacle.DestroyObstacle();
        }
        else
        {
            SceneSwitch.Instance.LoadGameScene();
        }
    }

    private IEnumerator ChangeColorOnHitObstacle(Color newColor)
    {
        _spriteRenderer.color = newColor;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.color = Color.white;
    }

    private IEnumerator ChangeScaleOnHitObstacle(Vector3 newScale)
    {
        transform.localScale = newScale;
        yield return new WaitForSeconds(0.15f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
