using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BuildTree : MonoBehaviour
{
    [SerializeField]
    public Transform start;
    public Transform Gripper;
    public Transform collTarget;

    public List<Transform> target;
    public List<Transform> ItemHolder = new List<Transform>();

    public Vector3 offset;
    
    public Button resetBtn;
    public Button progressLevelOrderBtn;
    public GameObject comment;

    public int g = 0;
    public float speed = 22.0f;
   


    void Start()
    {
    

        Button resBtn = resetBtn.GetComponent<Button>();
        resBtn.onClick.AddListener(TaskOnClick);

        Button proBtn1 = progressLevelOrderBtn.GetComponent<Button>();
       
    }

 


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Destroy(comment);
            StartCoroutine(instantiateAndMoveItems());
        }
    }

    IEnumerator instantiateAndMoveItems()
    {
        while (true && g < ItemHolder.Capacity)
        {
 
                for (int i = 0; i < ItemHolder.Capacity; i++)
                {
      
                    Transform item = Instantiate(ItemHolder[i]) as Transform;                                                      //Instantiate item one by one
                    item.position = start.position;
           
              
                    while (item.position != collTarget.position)
                    {   
                       Gripper.position = item.position+offset;                                                                  //Gripper 
                       item.position = Vector3.MoveTowards(item.position, collTarget.position, (speed + 10) * Time.deltaTime);   //From Start to CollisionTrigger              
                       yield return null;
                    }
              
                    //======================================================================================================//
                    while (item.position != target[g].position)                                                                  
                    {
                        item.position = Vector3.MoveTowards(item.position, target[g].position, (speed+10) * Time.deltaTime);    //From CollisionTrigger to TargetPoints
                        yield return null;
                    }
                    g++;
                }

                yield return 0;
        }
        TurnGreen();
       
    }


    void TaskOnClick()                                                         // For testing it resets the gamescene
    {
        SceneManager.LoadScene("GameScene");
    }
    public void TurnGreen()
    {
        ColorBlock colors = progressLevelOrderBtn.colors;
        colors.normalColor = Color.green;
        progressLevelOrderBtn.colors = colors;
    }


}
