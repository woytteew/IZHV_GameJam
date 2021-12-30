using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]
public class PlayerState : ScriptableObject
{
    public int cardIndex;
    public int exp;
    public float speed;
    public int expNeeded;
    public List<int> cardsDistribution;
    public int totalNumOfGenes;
    public int numOfGenerations;
    public int totalValueOfGenerations;
    public List<int> playerCards;
    public List<int> enemyCards;
    public int enemyScore;
}