using UnityEngine;
using System.Collections;

public class btnStep : MonoBehaviour
{
    private SortierManager sortingManager;
    private UnityEngine.UI.Text text;

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

    }

    public void btnStep_Click()
    {
        this.sortingManager.IncreaseStep();
        this.text.text = this.sortingManager.GetNextStepName();
    }
}
