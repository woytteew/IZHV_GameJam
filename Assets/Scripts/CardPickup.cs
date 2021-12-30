using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickup : MonoBehaviour
{
    [SerializeField] PlayerState player;
    public int cardValue;
    public int cardIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.cardIndex != 12)
            {
                player.exp += cardValue;
                player.cardsDistribution[cardIndex]++;
                player.totalNumOfGenes++;
                Destroy(this.gameObject);
            }
            
        }
    }
}
