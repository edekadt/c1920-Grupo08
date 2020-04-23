﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject healthBar, shieldBar, shieldHolder, controlsMenu, pauseMenu, dialogueBubble;
    public TextMeshProUGUI bubbleText;
    private string dialogue;
    private float typeSpeed = 0.1f;
    private Slider healthS, shieldS;
    bool paused;

    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    void Start()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(paused);
        controlsMenu.SetActive(false);
        dialogueBubble.SetActive(false);
        healthS = healthBar.GetComponent<Slider>();
        shieldS = shieldBar.GetComponent<Slider>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (paused)
            {
                paused = false;
                pauseMenu.SetActive(false);
                controlsMenu.SetActive(false);
                Time.timeScale = 1f;
            }

            else
            {
                paused = true;
                pauseMenu.SetActive(true);
                controlsMenu.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    public void UpdateHealthBar(float maxHP, float currentHP)
    {
        healthS.maxValue = maxHP;

        healthS.value = currentHP;
    }

    public void UpdateShieldBar(float maxShield, float currentShield)
    {
        shieldS.maxValue = maxShield;

        shieldS.value = currentShield;
    }
    public void UpdateShieldHolder() { }

    public void Dialogue(string text)
    {
        dialogue = text;
        dialogueBubble.SetActive(true);
        bubbleText.text = "";
        StartCoroutine(Type());
    }

    private IEnumerator Type()
    {
        foreach (char c in dialogue.ToCharArray())
        {
            bubbleText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(1.5f);

        dialogueBubble.SetActive(false);
    }

    public void MainMenuButtor()
    {
        GameManager.instance.MainMenu();
    }

    public void ExitButton() 
    {
        GameManager.instance.Exit();
    }

    public void ControlsMenuButton() 
    {
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackButton() 
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
