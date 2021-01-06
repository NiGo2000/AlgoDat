using UnityEngine;
using System.Collections;

public class btnDefaultCase : MonoBehaviour
{

  public static int[] itemCost = new int[15];
  public static Transform[] itemHolder = new Transform[15];
  [SerializeField]
  public Transform[] setItemHolder = new Transform[15];


  void Awake()
  {

    for (int i = 0; i < setItemHolder.Length; i++)
    {
      itemHolder[i] = setItemHolder[i];
    }

  }
  public void btnDefaultCase_Click()
  {
    //Test data
    itemCost[0] = 32;
    itemCost[1] = 53;
    itemCost[2] = 3;
    itemCost[3] = 65;
    itemCost[4] = 99;
    itemCost[5] = 42;
    itemCost[6] = 17;
    itemCost[7] = 333;
    itemCost[8] = 133;
    itemCost[9] = 33;
    itemCost[10] = 733;
    itemCost[11] = 633;
    itemCost[12] = 833;
    itemCost[13] = 443;
    itemCost[14] = 213;

  }


}
