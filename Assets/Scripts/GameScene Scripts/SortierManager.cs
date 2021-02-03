using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SortierManager : MonoBehaviour
{
    public System.Collections.Generic.List<int> targetList;
    public System.Collections.Generic.List<GameObject> lineNodes;
    public System.Collections.Generic.List<GameObject> treeNodes;
    public bool stop = false;
    public static bool btnversickern = false;
    public static bool btntausch = false;
    public static bool btnheapbuild = false;
    public GameObject image;
    public GameObject imageFertig;


    System.Collections.Generic.Queue<SchrittInfo> stepQueue;

    int targetStep = -1;


    void Awake()
    {
        if (this.targetList == null)
        {
            this.targetList = new System.Collections.Generic.List<int>();
        }

        if (this.lineNodes == null)
        {
            this.lineNodes = new System.Collections.Generic.List<GameObject>();
        }

        if (this.treeNodes == null)
        {
            this.treeNodes = new System.Collections.Generic.List<GameObject>();
        }

        if (this.stepQueue == null)
        {
            this.stepQueue = new System.Collections.Generic.Queue<SchrittInfo>();
        }
    }

    // Use this for initialization
    void Start()
    {
      
    }
   
    // Update is called once per frame
    void Update()
    {
        
        if (this.stop) { return; }

        System.Collections.Generic.Queue<SchrittInfo> queue = this.stepQueue;
        if (queue.Count > 0)
        {
            SchrittInfo schrittInfo = queue.Peek();

            schrittInfo.passedInterval += Time.deltaTime;

            MoveInTree(schrittInfo);

            if (schrittInfo.passedInterval >= schrittInfo.interval)
            {
                queue.Dequeue();

                switch (schrittInfo.stepType)
                {
                    case SchrittTypen.Error:
                        break;
                    case SchrittTypen.Tausche:
                        if (schrittInfo.targetIndex != schrittInfo.childIndex)
                        {
                           
                            this.treeNodes.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);
                            this.lineNodes.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);
                            this.targetList.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);

                            Color sortedColor = new Color(255, 255, 0);
                            schrittInfo.treeNodeTarget.GetComponentInChildren<TextMesh>().color = sortedColor;
                            TextMesh[] textMeshes = schrittInfo.lineNodeTarget.GetComponentsInChildren<TextMesh>();
                            foreach (var item in textMeshes)
                            {
                                item.color = sortedColor;
                            }
                            
                        }
                        else
                        {
                            throw new System.Exception("this should not happen.");
                        }
                        break;
                    case SchrittTypen.Versickere:
                        if (schrittInfo.targetIndex != schrittInfo.childIndex)
                        {
                            
                          
                            
                            this.treeNodes.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);
                            this.lineNodes.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);
                            this.targetList.TauscheElement(schrittInfo.targetIndex, schrittInfo.childIndex);

                            int targetIndex = schrittInfo.childIndex;

                            buildHeap(targetIndex);
                        }
                        else
                        {   
                           
                            schrittInfo.treeNodeTarget.transform.position = schrittInfo.treeNodeTargetPosition;
                            //schrittInfo.lineNodeTarget.transform.position = schrittInfo.lineNodeTargetPosition;
                           
                        }
                        break;
                    default:
                        break;
                }
                
            }

            
        }
    
}

    private void MoveInTree(SchrittInfo schrittInfo)
    {
        System.Collections.Generic.Queue<SchrittInfo> queue = this.stepQueue;

        GameObject treeNodeTarget = schrittInfo.treeNodeTarget;
        GameObject treeNodeChild = schrittInfo.treeNodeChild;
       if (treeNodeTarget == treeNodeChild)
        {
             {                                                                             /**
                                                                                                item wird geschüttelt, wenn bereits an richtiger stelle ohne sortierung
                                                                                                **/
                Vector3 newPosition = schrittInfo.treeNodeTargetPosition;
                const float range = 0.5f;
                newPosition.x += Random.Range(-range, range);
                newPosition.y += Random.Range(-range, range);
                newPosition.z += Random.Range(-range, range);
                treeNodeTarget.transform.position = newPosition;
            }
    } else
    {
         treeNodeTarget.transform.position = Vector3.Lerp(
                schrittInfo.treeNodeTargetPosition, schrittInfo.treeNodeChildPosition, schrittInfo.passedInterval / schrittInfo.interval);
            treeNodeChild.transform.position = Vector3.Lerp(
                schrittInfo.treeNodeChildPosition, schrittInfo.treeNodeTargetPosition, schrittInfo.passedInterval / schrittInfo.interval);
    }

    
    }


    int GetSortedCount()
    {
        int targetStep = this.targetStep;
        int count = targetList.Count;
        int initializationSteps = count / 2 - 1;
        int TauscheSteps = count - 1;
        int buildSubHeapSteps = count - 1;

        if (targetStep <= initializationSteps) { return 0; }
        if (targetStep > initializationSteps + TauscheSteps + buildSubHeapSteps) { return count; }

        int sortedCount = (targetStep - initializationSteps) / 2;

        return sortedCount;
    }

    public void IncreaseStep()
    {
        if (this.stepQueue.Count > 0) { return; }

        this.targetStep++;

        int targetStep = this.targetStep;
        System.Collections.Generic.List<int> targetList = this.targetList;
        int count = targetList.Count;

        int initializationSteps = count / 2 - 1;
        int TauscheSteps = count - 1;
        int buildSubHeapSteps = count - 1;
        if (targetStep > initializationSteps + TauscheSteps + buildSubHeapSteps) { return; }

        if (targetStep <= initializationSteps) // initialize heap.
        {
            // btnheapbuild = true;
            // btntausch = false;
            // btnversickern = false;
            int targetIndex = initializationSteps - targetStep;

            buildHeap(targetIndex);
        }
        else
        {
            int sortingStepIndex = targetStep - initializationSteps;
            if (sortingStepIndex % 2 == 1) // Tausche.
            {
                // btnheapbuild = false;
                // btntausch = true;
                // btnversickern = false;
                int tailIndex = count - (sortingStepIndex + 1) / 2;
                SchrittInfo schrittInfo = new SchrittInfo(0, tailIndex, SchrittTypen.Tausche, this);
                this.stepQueue.Enqueue(schrittInfo);
            }
            else // build sub heap.
            {
                // btnheapbuild = false;
                // btntausch = false;
                // btnversickern = true;
                buildHeap(0);
            }
             btnheapbuild = false;
             btntausch = false;
             btnversickern = false;
        }
    }

    private void buildHeap(int targetIndex)
    {
        System.Collections.Generic.List<int> targetList = this.targetList;
        System.Collections.Generic.List<GameObject> treeNodes = this.treeNodes;
        int unSortedCount = treeNodes.Count - GetSortedCount();
        int targetValue = targetList[targetIndex];

        int leftChildValue = targetValue;
        if (targetIndex * 2 + 1 < unSortedCount)
        {
            leftChildValue = targetList[targetIndex * 2 + 1];
        }

        int rightChildValue = targetValue;
        if (targetIndex * 2 + 2 < unSortedCount)
        {
            rightChildValue = targetList[targetIndex * 2 + 2];
        }

        int childIndex = targetIndex;
        int max = targetValue;
        if (targetIndex * 2 + 1 < unSortedCount && max < leftChildValue)
        {
            childIndex = targetIndex * 2 + 1;
            max = leftChildValue;
        }
        if (targetIndex * 2 + 2 < unSortedCount && max < rightChildValue)
        {
            childIndex = targetIndex * 2 + 2;
            max = rightChildValue;
        }

        if (targetIndex * 2 + 1 < unSortedCount)
        {
            SchrittInfo schrittInfo = new SchrittInfo(targetIndex, childIndex, SchrittTypen.Versickere, this);
            this.stepQueue.Enqueue(schrittInfo);
        }
    }

   
    private void AktiviereBild()
    {

        image.SetActive(true);
        imageFertig.SetActive(true);
    }

    public string getStepName()
    {
        if (this.targetList.Count <= 0) { return "Build Tree noch nicht gestartet!"; }

        int targetStep = this.targetStep;

        int count = this.targetList.Count;
        int initializationSteps = count / 2 - 1;
        if (targetStep < initializationSteps) 
        {  btnheapbuild = true; return "Build Heap"; }

        int TauscheSteps = count - 1;
        int buildSubHeapSteps = count - 1;
        if (targetStep >= initializationSteps + TauscheSteps + buildSubHeapSteps) {
            AktiviereBild();
            return "Fertig";

        }

    

    int sortingStepIndex = targetStep - initializationSteps;

        if (sortingStepIndex % 2 == 0) // Tausche
        {   btntausch = true; btnheapbuild = false; return "Tausche"; }
        else
        { btnversickern = true; return "Versickere"; }

    }





}
