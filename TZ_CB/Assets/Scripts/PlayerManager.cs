using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] Animator animator;

    private Camera _camera;
    private Vector3 _mouseStartPos, _playerStartPos;
    private Finish _finish;
    private float _playerSpeed = 2f;

    public bool moveByTouch, gameState;


    private void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _camera = Camera.main;
    }

    private void Update()
    {
        MoveThePlayer();
        animator.SetFloat("SpeedZ", _playerSpeed);
    }

    private void MoveThePlayer()
    {

        transform.Translate(Vector3.forward * _playerSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && gameState)
        {
            moveByTouch = true;

            var plane = new Plane(Vector3.up, 0f);

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance + 1f);
                _playerStartPos = transform.position;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;

        }

        if (moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                var mousePos = ray.GetPoint(distance + 1f);

                var move = mousePos - _mouseStartPos;

                var control = _playerStartPos + move;

                //platform out of bounds
                //control.x = Mathf.Clamp(control.x, -2.1f, 2.1f);

                transform.position = new Vector3(Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * _playerSpeed), transform.position.y, transform.position.z);
            }
        }
    }

    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Finish()
    {
        _playerSpeed = 0f;
        _finish.FinishRoad();
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Finish();
        }
    }
}
