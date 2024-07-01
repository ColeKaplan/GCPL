using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    public GameObject menuScreen;
    public void Return() {
        menuScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
