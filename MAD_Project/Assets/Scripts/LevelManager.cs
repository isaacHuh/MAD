using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int level = 1;
    // Start is called before the first frame update
    void Start() {
        Debug.Log(LevelManager.level);
    }
}
