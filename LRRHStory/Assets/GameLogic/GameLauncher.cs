using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class GameLauncher : MonoBehaviour
{
    void Awake()
    {
        XFrameworkLauncher.instance.BeginFramework();
    }

    // Start is called before the first frame update
    void Start()
    {
        XFrameworkLauncher.instance.Start();
    }

    // Update is called once per frame
    void Update()
    {
        XFrameworkLauncher.instance.Update();
    }
}
