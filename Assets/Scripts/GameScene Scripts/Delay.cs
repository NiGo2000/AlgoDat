using UnityEngine;
using System.Collections;

/// <summary>
/// Delay for some time to show the game object.
/// </summary>
public class Delay : MonoBehaviour
{
    public float showTime;
    bool done = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            if (showTime <= Time.time)
            {
                Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
                 foreach (var item in renderers)
                 {
                     item.enabled = true;
                 }
                done = true;
            }
        }
    }
}
