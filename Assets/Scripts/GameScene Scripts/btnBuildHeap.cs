using UnityEngine;
using System.Collections;

public class btnBuildHeap : MonoBehaviour
{
    private SortierManager sortManager;
    private UnityEngine.UI.Text text;

    // Use this for initialization
    void Start()
    {
        GameObject managerObj = GameObject.FindGameObjectWithTag(Tags.SortierManager);
        this.sortManager = managerObj.GetComponent<SortierManager>();

        this.text = this.GetComponentInChildren<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btnBuildHeap_Click()
    {
        this.sortManager.IncreaseStep();
        this.text.text = this.sortManager.GetNextStepName();
    }
}
