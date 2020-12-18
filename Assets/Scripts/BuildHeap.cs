using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BuildHeap : MonoBehaviour
{
    [SerializeField]
    public Transform[] target = new Transform[15];
    [SerializeField]
    public Transform[] curr = new Transform[15];
    public Transform collTarget;

    public int g = 0;
    public float speed = 12.0f;


    void Start()
    {

        StartCoroutine(MoveItems());       //Starts routine to move objects

    }




    void Update()
    {


    }


    IEnumerator MoveItems()                 //Move sequence
    {

        foreach (Transform cp in curr)                                                                                  //From Startpoint to CollisionTrigger
        {
            while (cp.position != collTarget.position)
            {
                cp.position = Vector3.MoveTowards(cp.position, collTarget.position, (speed + 5) * Time.deltaTime);
                yield return null;
            }

            //------------------------------------------------------------------------------------------------------------//

            while (curr[g].position != target[g].position)                                                               //From CollisionTrigger to TargetPoints
            {
                curr[g].position = Vector3.MoveTowards(curr[g].position, target[g].position, speed * Time.deltaTime);
                yield return null;
            }
            g++;
            yield return new WaitForSeconds(.5f);
        }
    }

}
