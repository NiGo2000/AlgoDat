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
    public GameObject TxtBuildTree;
    public GameObject txtBuildHp;
    public GameObject txtTausch;
    public GameObject txtVersickere;

    public GameObject OnVersickere;
    public GameObject OnTausche;
    public GameObject OnBuildTree;
    public GameObject OnBuildHeap;

    public GameObject OffVersickere;
    public GameObject OffTausche;
    public GameObject OffBuildTree;
    public GameObject OffBuildHeap;



    private void AktiviereBuildTreeTxt() {

        TxtBuildTree.SetActive(true);
        OnBuildTree.SetActive(true);

        OffBuildTree.SetActive(false);

    }

    private void AktiviereBuildHp() {

        txtBuildHp.SetActive(true);
        OnBuildHeap.SetActive(true);

        OffBuildHeap.SetActive(false);

    }

    private void AktiviereTauschTxt() {

        txtTausch.SetActive(true);
        OnTausche.SetActive(true);

        OffTausche.SetActive(false);

    }

    private void AktiviereVersickereTxt() {

        txtVersickere.SetActive(true);
        OnVersickere.SetActive(true);

        OffVersickere.SetActive(false);

    }
    private void DeBuildTree()
    {

        TxtBuildTree.SetActive(false);
        OffBuildTree.SetActive(true);

        OnBuildTree.SetActive(false);

    }
    private void DEBuildheap()
    {

        txtBuildHp.SetActive(false);
        OffBuildHeap.SetActive(true);

        OnBuildHeap.SetActive(false);


    }
    private void DETauschTxt()
    {

        txtTausch.SetActive(false);
        OffTausche.SetActive(true);

        OnTausche.SetActive(false);

    }
    private void DEVersickereTxt()
    {

        txtVersickere.SetActive(false);
        OffVersickere.SetActive(true);

        OnVersickere.SetActive(false);

    }

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
            AktiviereBuildTreeTxt();
    }
    else
    {
      treebtn.GetComponent<Image>().color = Color.red;
            DeBuildTree();
    }

    if (SortierManager.btnheapbuild)
    {
      buildheapbtn.GetComponent<Image>().color = Color.green;
            AktiviereBuildHp();
        }
    else
    {
      buildheapbtn.GetComponent<Image>().color = Color.red;
            DEBuildheap();
    }

    if (SortierManager.btntausch)
    {
      btnVersickere.GetComponent<Image>().color = Color.green;
            AktiviereVersickereTxt();


    }
    else
    {
      btnVersickere.GetComponent<Image>().color = Color.red;
      DEVersickereTxt();


    }

    if (SortierManager.btnversickern)
        {
      btnTausch.GetComponent<Image>().color = Color.green;
            AktiviereTauschTxt();
    }
    else
    {
      btnTausch.GetComponent<Image>().color = Color.red;
            DETauschTxt();
        }
  }
}
