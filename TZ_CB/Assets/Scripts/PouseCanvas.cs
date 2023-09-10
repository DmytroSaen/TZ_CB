using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseCanvas : MonoBehaviour
{
    public void ContinueHandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
