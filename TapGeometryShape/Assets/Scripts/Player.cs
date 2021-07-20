using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] shapes;
    private SpriteRenderer _spriteRenderer;

    private ShapesList.Shapes _shape;

    [SerializeField] private GameObject[] hearts;
    private const int MaxLifes = 3;
    private int _lifes;

    [SerializeField] private GameObject[] componentsToDisableOnDeath;
    [SerializeField] private GameObject deathMenu;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _shape = ShapesList.Shapes.Circle;

        _lifes = MaxLifes;

        deathMenu.SetActive(false);
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

            Score.IncreaseScore();
        }
        else
        {
            if (_lifes > 1)
            {
                _lifes--;
                ResetHearts();

                StartCoroutine(ChangeColorOnHitObstacle(Color.red));
                StartCoroutine(ChangeScaleOnHitObstacle(new Vector3(0.5f, 0.5f, 1f)));
            }
            else
            {
                _spriteRenderer.enabled = false;

                for (int i = 0; i < componentsToDisableOnDeath.Length; i++)
                {
                    componentsToDisableOnDeath[i].SetActive(false);
                }

                deathMenu.SetActive(true);
            }
        }

        obstacle.DestroyObstacle();
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

    private void ResetHearts()
    {
        if (_lifes == 2)
        {
            hearts[0].SetActive(false);
        }
        else if (_lifes == 1)
        {
            hearts[1].SetActive(false);
        }
    }
}
