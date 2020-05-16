﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{    
    [SerializeField] private string frase;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()!=null)
        {            
           GameManager.instance.OnDialogue(frase);
           Destroy(this.gameObject);
        }
    }
}
