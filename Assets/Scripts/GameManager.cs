using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerState player;

    [SerializeField] private CardDatabase _cardDatabase;

    public GameObject playerObject;

    public float gameTime=60f;

    public Canvas generationOptions;

    public Text endText;

    public Canvas endScreen;
    
    public GameObject cardPrefab;

    public Text timer;

    private int enemyCard;

    //private Canvas option;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        playerObject.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[player.cardIndex];

        if (player.numOfGenerations!=1)
        {
            gameTime = gameTime / 2;
            for (int i = 1; i <= player.playerCards.Count; i++)
            {
                GameObject card = Instantiate(cardPrefab) as GameObject;
                card.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[player.playerCards[i-1]];
                if (player.numOfGenerations == 2)
                {
                    card.transform.position = new Vector3(0, -3, 0);
                }
                else
                {
                    card.transform.position = new Vector3(-1.5f+i, -3, 0);
                }
                
            }
            for (int i = 1; i <= player.enemyCards.Count; i++)
            {
                GameObject card = Instantiate(cardPrefab) as GameObject;
                card.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[player.enemyCards[i-1]];
                card.transform.position = new Vector3(-1.5f+i, 3, 0);
            }
        }
        
        
        /*player.exp = 0;
        player.cardIndex = 0;
        player.totalNumOfCards = 0;
        for (int i = 0; i < 13; i++)
        {
            player.cardsDistribution[i] = 0;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = Convert.ToInt16(gameTime).ToString();
        
        if (player.exp >= player.expNeeded)
        {
            player.cardIndex++;
            playerObject.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[player.cardIndex];
            player.exp -= player.expNeeded;
        }

        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            if (player.numOfGenerations == 1)
            {
                enemyCard = Random.Range(0, 13);
                player.enemyCards.Add(enemyCard);
                if (enemyCard < 9)
                {
                    player.enemyScore += enemyCard + 1;
                }
                else
                {
                    player.enemyScore += 10;
                }
                
                StartAnotherGeneration();
            }
            else
            {
                Time.timeScale = 0;
                generationOptions.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void StartAnotherGeneration()
    {
        //Time.timeScale = 1;
        
        List<int> genes=new List<int>();
        int temp;
        
        player.playerCards.Add(player.cardIndex);
        
        if (player.cardIndex < 9)
        {
            player.totalValueOfGenerations += player.cardIndex + 1;
        }
        else
        {
            player.totalValueOfGenerations += 10;
        }
        

        for (int cardIndex = 0; cardIndex < 13; cardIndex++)
        {
            temp = player.cardsDistribution[cardIndex];
            while (temp > 0)
            {
                genes.Add(cardIndex);
                temp--;
            }
            
        }
        player.exp = 0;
        player.numOfGenerations++;
        player.cardIndex = genes[Random.Range(0, player.totalNumOfGenes)];
        
        
        SceneManager.LoadScene(0);
    }

    public void Stand()
    {
        generationOptions.GetComponent<Canvas>().enabled = false;
        endScreen.GetComponent<Canvas>().enabled = true;
        enemyCard = Random.Range(0, 13);
        GameObject card = Instantiate(cardPrefab) as GameObject;
        card.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[enemyCard];
        card.transform.position = new Vector3(0.5f, 3, 0);
        player.enemyCards.Add(enemyCard);
        
        card = Instantiate(cardPrefab) as GameObject;
        card.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[player.cardIndex];
        card.transform.position = new Vector3(-1.5f+player.numOfGenerations, -3, 0);
        
        player.playerCards.Add(player.cardIndex);
        
        if (player.cardIndex < 9)
        {
            player.totalValueOfGenerations += player.cardIndex + 1;
        }
        else
        {
            player.totalValueOfGenerations += 10;
        }
        
        if (enemyCard < 9)
        {
            player.enemyScore += enemyCard + 1;
        }
        else
        {
            player.enemyScore += 10;
        }

        if (player.totalValueOfGenerations > 21)
        {
            endText.GetComponent<Text>().enabled = true;
            Debug.Log("You lost");
        }
        else{
            if (player.enemyScore < 17)
            {
                card = Instantiate(cardPrefab) as GameObject;
                card.GetComponent<SpriteRenderer>().sprite = _cardDatabase.cards[enemyCard];
                card.transform.position = new Vector3(1.5f, 3, 0);
                
                if (enemyCard < 9)
                {
                    player.enemyScore += enemyCard + 1;
                }
                else
                {
                    player.enemyScore += 10;
                }
                
            }
            Debug.Log(player.enemyScore);
            
            endText.GetComponent<Text>().enabled = true;
            if (player.enemyScore > 21)
            {
                endText.text = "You won";
                Debug.Log("You won");
            }
            else
            {
                if ((21 - player.totalValueOfGenerations) > (21 - player.enemyScore))
                {
                    
                    Debug.Log("You lost");
                }
                else if((21 - player.totalValueOfGenerations) < (21 - player.enemyScore))
                {
                    endText.text = "You won";
                    Debug.Log("You won");
                }
                else
                {
                    endText.text = "Push";
                    Debug.Log("Push");
                }
            }
        }
        playerStateInit();
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void playerStateInit()
    {
        player.exp = 0;
        player.numOfGenerations = 1;
        
        player.cardIndex = 0;
        player.totalNumOfGenes = 0;
        player.totalValueOfGenerations = 0;
        player.enemyScore = 0;
        player.enemyCards.Clear();
        player.playerCards.Clear();
        gameTime = 60f;
        for (int i = 0; i < 13; i++)
        {
            player.cardsDistribution[i] = 0;
        }
    }

}


