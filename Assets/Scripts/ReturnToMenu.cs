﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void returnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}