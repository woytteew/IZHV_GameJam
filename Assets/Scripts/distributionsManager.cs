using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class distributionsManager : MonoBehaviour
{
    [SerializeField] PlayerState player;

    public Text ace;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text six;
    public Text seven;
    public Text eight;
    public Text nine;
    public Text ten;
    public Text jack;
    public Text queen;
    public Text king;

    // Update is called once per frame
    void Update()
    {
        if (player.totalNumOfGenes != 0)
        {
            ace.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[0]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            two.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[1]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            three.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[2]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            four.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[3]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            five.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[4]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            six.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[5]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            seven.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[6]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            eight.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[7]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            nine.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[8]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString() +"%";
            ten.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[9]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            jack.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[10]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            queen.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[11]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%";
            king.text = Convert.ToInt32((Convert.ToDouble(player.cardsDistribution[12]) / Convert.ToDouble(player.totalNumOfGenes)) * 100).ToString()+"%"; 
        }
        
        
    }
}
