using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject shopCanvas;

    public void PauseHandler()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShopHandler()
    {
        shopCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
