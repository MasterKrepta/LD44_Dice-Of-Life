﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public void LaunchGame() {
        SceneManager.LoadScene(1);
    }
}
