using UnityEngine;
using System.Collections;

public class btnStep : MonoBehaviour
{
    private SortierManager sortingManager;
    private UnityEngine.UI.Text text;

    [SerializeField]
    public Transform[] wp = new Transform[15];
    public GameObject schrittIndikator;
    public static Vector3 posSchrittIndikator;

    public Transform wurzelElement;
    public Transform letztesElement;

    public Transform wurzelIndikator;
    public Transform letztesElementIndikator;

    

    private bool go = false;
    private int k = 0;

    // Use this for initialization
    void Start()
    {
        
        GameObject managerObj = GameObject.FindGameObjectWithTag(Tags.SortierManager);
        this.sortingManager = managerObj.GetComponent<SortierManager>();
        this.text = this.GetComponentInChildren<UnityEngine.UI.Text>();    
         
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = this.sortingManager.getStepName();

        if (go){
            schrittIndikator.transform.position =  Vector3.Lerp(schrittIndikator.transform.position, wp[k].position, 5* Time.deltaTime);            
        }
    
    }

    public void btnStep_Click()
    {   
        btnBuildTree.btntree = false;
        

        this.sortingManager.IncreaseStep();
        
       
   

        if (k == 7){
            schrittIndikator.transform.position = new Vector3(100, 1000, 100);
             wurzelIndikator.transform.position = wurzelElement.position;
            letztesElementIndikator.transform.position = letztesElement.position;
            
        } else {
            wurzelIndikator.transform.position = new Vector3(100, 1000, 100);
            letztesElementIndikator.transform.position = new Vector3(100, 1000, 100);
        }
         k++;
        go = true;
     }
}

