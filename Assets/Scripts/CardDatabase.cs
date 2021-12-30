using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardsDatabase")]
public class CardDatabase : ScriptableObject
{
    public List<Sprite> cards;
}