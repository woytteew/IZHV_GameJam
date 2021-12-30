using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] CardDatabase cardDatabase;

    public GameObject cardPrefab;

    public float spawnDelay = 1f;
    // Start is called before the first frame update
    private Vector2 screenBounds;

    void Start()
    {
        //screenBounds=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,screenBounds.heigh))
        screenBounds = new Vector2(Screen.width, Screen.height);

        StartCoroutine(Spawning());
    }

    private void SpawnCard()
    {
        GameObject temp = Instantiate(cardPrefab) as GameObject;
        Vector2 spawnPosition = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        
        temp.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10));
        int cardIndex = Random.Range(0, 13);
        temp.GetComponent<SpriteRenderer>().sprite = cardDatabase.cards[cardIndex];

        temp.GetComponent<CardPickup>().cardIndex = cardIndex;
        if (cardIndex > 9) cardIndex = 9;
        temp.GetComponent<CardPickup>().cardValue = cardIndex + 1;


    }

    IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnCard();
        }
    }

}
