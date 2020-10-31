using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
