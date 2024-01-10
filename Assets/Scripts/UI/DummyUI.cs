using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyUI : MonoBehaviour
{   
    private void Update() {
        Debug.Log("Score : " + GameData.score + "                          " + "Health : " + GameData.health);
    }
    
}
