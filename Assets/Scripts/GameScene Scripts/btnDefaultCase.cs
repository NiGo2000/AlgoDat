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

    itemCost[0] = 1;  //0.14; //Laufwerk            1
    itemCost[1] = 3; //0.56; //Laptop                   3
    itemCost[2] = 4; //0.84; //HDD                      4
    itemCost[3] = 6; //4.23; //Smartphone               6
    itemCost[4] = 0; //0; //CD                          0
    itemCost[5] = 7; //7.50; //Serverrückwand           7
    itemCost[6] = 10;//26; //RAM                         10
    itemCost[7] = 8;//11.75; //altes Mobiltelefon       8
    itemCost[8] = 0;//0; //Ablenkspule                  0
    itemCost[9] = 8;//11.75; //Chip                    8
    itemCost[10] = 5;//1.41; //Computerstecker         5
    itemCost[11] = 12;//80; //CPU                       12
    itemCost[12] = 11;//27; //Goldstecker               11
    itemCost[13] = 9;//25.85; //Handyleiterplatte      9
    itemCost[14] = 2;//0.19; //Netzteil                2
            
  }



}
