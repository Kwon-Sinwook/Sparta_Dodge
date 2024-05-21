using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DescriptionButton : MonoBehaviour
{
    public void StartDescription()
    {
        SceneManager.LoadScene("DescriptionScene");
    }
}
