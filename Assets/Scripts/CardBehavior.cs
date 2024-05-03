using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
   public Sprite faceUpSprite;

   public void Switch(){
    GetComponent<SpriteRenderer>().sprite = faceUpSprite;
   }
   
}
