using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnIndicator : MonoBehaviour
{
  [SerializeField]
  public Button treebtn;
  public Button buildheapbtn;
  public Button btnTausch;
  public Button btnVersickere;

  void Start()
  {

    treebtn.GetComponent<Image>().color = Color.red;
    buildheapbtn.GetComponent<Image>().color = Color.red;
    btnTausch.GetComponent<Image>().color = Color.red;
    btnVersickere.GetComponent<Image>().color = Color.red;


  }

  // Update is called once per frame
  void Update()
  {
    if (btnBuildTree.btntree)
    {
      treebtn.GetComponent<Image>().color = Color.green;
    }
    else
    {
      treebtn.GetComponent<Image>().color = Color.red;
    }

    if (SortierManager.btnheapbuild)
    {
      buildheapbtn.GetComponent<Image>().color = Color.green;
    }
    else
    {
      buildheapbtn.GetComponent<Image>().color = Color.red;
    }

    if (SortierManager.btnversickern)
    {
      btnVersickere.GetComponent<Image>().color = Color.green;
    }
    else
    {
      btnVersickere.GetComponent<Image>().color = Color.red;
    }

    if (SortierManager.btntausch)
    {
      btnTausch.GetComponent<Image>().color = Color.green;
    }
    else
    {
      btnTausch.GetComponent<Image>().color = Color.red;
    }
  }
}
