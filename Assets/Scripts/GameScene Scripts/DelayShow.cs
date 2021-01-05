using UnityEngine;
using System.Collections;

/// <summary>
/// Delay for some time to show the game object.
/// </summary>
public class DelayShow : MonoBehaviour
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
               // this.GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
                Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
                 foreach (var item in renderers)
                 {
                     item.enabled = true;
                 }
                //TextMesh[] textMeshes = this.GetComponentsInChildren<TextMesh>();
                // foreach (var item in textMeshes)
                // {
                //     item.GetComponent<Renderer>().enabled = true;
                // }

                // {
                //     Transform valueNode = this.transform.Find("Value");
                //     valueNode.GetComponent<Renderer>().enabled = true;
                //     TextMesh textMesh = valueNode.GetComponentInChildren<TextMesh>();
                //     textMesh.GetComponent<Renderer>().enabled = true;
                // }
                // {
                //     Transform indexNode = this.transform.Find("Index");
                //     indexNode.GetComponent<Renderer>().enabled = true;
                //     TextMesh textMesh = indexNode.GetComponentInChildren<TextMesh>();
                //     textMesh.GetComponent<Renderer>().enabled = true;
                // }

                done = true;
            }
        }
    }
}
