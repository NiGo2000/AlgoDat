using UnityEngine;
using System.Collections;

public class SortierManager : MonoBehaviour
{
    public System.Collections.Generic.List<int> targetList;
    public System.Collections.Generic.List<GameObject> lineNodes;
    public System.Collections.Generic.List<GameObject> treeNodes;
    public bool stop = false;

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

                            AddStep4BuildSubHeap(targetIndex);
                        }
                        else
                        {
                            schrittInfo.treeNodeTarget.transform.position = schrittInfo.treeNodeTargetPosition;
                            schrittInfo.lineNodeTarget.transform.position = schrittInfo.lineNodeTargetPosition;
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
      
            treeNodeTarget.transform.position = Vector3.Lerp(
                schrittInfo.treeNodeTargetPosition, schrittInfo.treeNodeChildPosition, schrittInfo.passedInterval / schrittInfo.interval);
            treeNodeChild.transform.position = Vector3.Lerp(
                schrittInfo.treeNodeChildPosition, schrittInfo.treeNodeTargetPosition, schrittInfo.passedInterval / schrittInfo.interval);
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
            int targetIndex = initializationSteps - targetStep;

            AddStep4BuildSubHeap(targetIndex);

        }
        else
        {
            int sortingStepIndex = targetStep - initializationSteps;
            if (sortingStepIndex % 2 == 1) // Tausche.
            {
                int tailIndex = count - (sortingStepIndex + 1) / 2;
                SchrittInfo schrittInfo = new SchrittInfo(0, tailIndex, SchrittTypen.Tausche, this);
                this.stepQueue.Enqueue(schrittInfo);
            }
            else // build sub heap.
            {
                AddStep4BuildSubHeap(0);
            }
        }
    }

    private void AddStep4BuildSubHeap(int targetIndex)
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

    public string GetNextStepName()
    {
        if (this.targetList.Count <= 0) { return "Benutzer Fehler"; }

        int targetStep = this.targetStep;

        int count = this.targetList.Count;
        int initializationSteps = count / 2 - 1;
        if (targetStep < initializationSteps) { return "Build Heap"; }

        int TauscheSteps = count - 1;
        int buildSubHeapSteps = count - 1;
        if (targetStep >= initializationSteps + TauscheSteps + buildSubHeapSteps) { return "Fertig"; }

        int sortingStepIndex = targetStep - initializationSteps;

        if (sortingStepIndex % 2 == 0) // Tausche
        { return "Tausche"; }
        else
        { return "Versickere"; }
    }
}
