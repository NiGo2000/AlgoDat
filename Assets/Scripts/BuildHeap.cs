using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BuildHeap : MonoBehaviour
{
    [SerializeField]
    public List<Transform> target;
    [SerializeField]
    public List<Transform> start;
    [SerializeField]
    public List<Transform> ItemHolder = new List<Transform>();

    public Transform collTarget;

    public int g = 0;
    public float speed = 12.0f;

   

    void Start()
    {
        StartCoroutine(instantiatedItems());
    }

 


    void Update()
    {
       
    }

    IEnumerator instantiatedItems()
    {

        for (int i = 0; i < ItemHolder.Capacity; i++)
        {
            Transform item = Instantiate(ItemHolder[i]) as Transform;                                                   //Instantiate item one by one
            item.position = start[i].position;

            while (item.position != collTarget.position)
            {
                item.position = Vector3.MoveTowards(item.position, collTarget.position, (speed + 5) * Time.deltaTime);   //From Start to CollisionTrigger
                yield return null;
            }
            //======================================================================================================//
            while (item.position != target[g].position)                                                                  //From CollisionTrigger to TargetPoints
            {
                item.position = Vector3.MoveTowards(item.position, target[g].position, speed * Time.deltaTime);
                yield return null;
            }
            g++;
            yield return new WaitForSeconds(.5f);
        }


    }

   










}
