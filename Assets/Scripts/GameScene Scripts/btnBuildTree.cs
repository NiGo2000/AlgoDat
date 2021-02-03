using UnityEngine;
using System.Collections;

public class btnBuildTree : MonoBehaviour
{
  public Transform nodePrefab;
  public UnityEngine.UI.Text btnStepText;
  public Transform lineManager;
  public Transform treeManager;
  public Transform trichter;
  public Transform gripper;
  public Vector3 offset;
  private float speed = 0.4f;

  private SortierManager sortManager;
  private bool done = true;
  private bool grip = false;
  private System.Collections.Generic.List<int> array;
  private int g = 0;
  private int k = 0;

  public Renderer rend;
  public static bool btntree = false;

  public GameObject RecycleButton;

  void Start()
  {

    RecycleButton.SetActive(false);
    GameObject managerObj = GameObject.FindGameObjectWithTag(Tags.SortierManager);
    this.sortManager = managerObj.GetComponent<SortierManager>();

    if (array == null)
    {
      array = new System.Collections.Generic.List<int>();
    }

  }


  void Update()
  {     

    if (done) {  return; }

    this.sortManager.stop = true;

    System.Collections.Generic.List<int> targetList = new System.Collections.Generic.List<int>();
    System.Collections.Generic.List<GameObject> lineNodes = new System.Collections.Generic.List<GameObject>();

    float now = Time.time;

    for (int index = 0; index < this.lineManager.transform.childCount && index < this.array.Count; index++)
    {
      Transform child = this.lineManager.transform.Find(index.ToString());
      if (child != null)
      {
        if (int.TryParse(child.name, out index))
        {
          Transform lineNode = Instantiate(btnDefaultCase.itemHolder[g]) as Transform;
          lineNode.position = child.position;
          lineNodes.Add(lineNode.gameObject);
          targetList.Add(this.array[index]);
          g++;   

            foreach (Transform ln in lineNode)
            {
                ln.position = new Vector3(1000,1000,1000);
            }
            
          
        }
        
      }
    }

    
    System.Collections.Generic.List<GameObject> treeNodes = new System.Collections.Generic.List<GameObject>();
    float startTime = Time.time;

    for (int index = 0; index < this.treeManager.transform.childCount && index < this.array.Count; index++)
    {
            
      Transform child = this.treeManager.transform.Find(index.ToString());
      if (child != null)
      {

        string name = getLineName(index);
        GameObject lineNode = lineNodes[index];
        Transform treeNode = Instantiate(btnDefaultCase.itemHolder[k]) as Transform;
        treeNode.position = lineNode.transform.position;
        treeNode.name = getTreeName(index);
        k++;
        {
          Move moveToTrichter = treeNode.gameObject.AddComponent<Move>();
          moveToTrichter.startTime = startTime;
          moveToTrichter.endTime = startTime + speed;
          moveToTrichter.startPosition = treeNode.position;
          moveToTrichter.endPosition = trichter.position;
        }
        {
          
          Move GripperToTrichter = gripper.gameObject.AddComponent<Move>();
          GripperToTrichter.startTime = startTime;
          GripperToTrichter.endTime = startTime + speed;
          GripperToTrichter.startPosition = treeNode.position + offset;
          GripperToTrichter.endPosition = trichter.position + offset;
        }
        startTime += speed;
        {
          Move moveToTree = treeNode.gameObject.AddComponent<Move>();
          moveToTree.startTime = startTime;
          moveToTree.endTime = startTime + speed;
          moveToTree.startPosition = trichter.position;
          moveToTree.endPosition = child.position;
        }

        startTime += speed;

        treeNodes.Add(treeNode.gameObject);
      }
      this.gameObject.SetActive(false);
     
    }

    this.sortManager.targetList = targetList;
    this.sortManager.lineNodes = lineNodes;
    this.sortManager.treeNodes = treeNodes;

    this.done = true;
    this.sortManager.stop = false;

    this.btnStepText.text = this.sortManager.getStepName();

    }

  public void btnBuildTree_Click()
  {
    
    btntree = true;
    int[] prices = btnDefaultCase.itemCost;

    foreach (var price in prices)
    {
      this.array.Add(price);
    }

    this.done = false;

    RecycleButton.SetActive(true);
    }

    public static string getLineName(int index)
    {
        string name = string.Format("line {0}", index);
        return name;
    }

    public static string getTreeName(int index)
    {
        string name = string.Format("tree node {0}", index);
        return name;
    }


}
