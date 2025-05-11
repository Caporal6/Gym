using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent; 
    public string[] Sentences; 
    public float TypingSpeed; 
    private int index; 
    public static Dialogue Instance; 

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        TextComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            if (TextComponent.text == Sentences[index]) 
            {
                NextSentence(); 
            }
            else
            {
                StopAllCoroutines(); 
                TextComponent.text = Sentences[index]; 
            }
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true); 
        index = 0; 

        StartCoroutine(Type()); 
    }
    IEnumerator Type()
    {
        foreach (char letter in Sentences[index].ToCharArray()) 
        {
            TextComponent.text += letter; 
            yield return new WaitForSeconds(TypingSpeed); 
        }
    }

    public void NextSentence()
    {
        if (index < Sentences.Length - 1) 
        {
            index++; 
            TextComponent.text = string.Empty; 
            StartCoroutine(Type()); 
        }
        else
        {
            EndDialogue(); 
            gameObject.SetActive(false); 
        }
    }

    void EndDialogue()
    {
        Debug.Log("Fin du dialogue"); 
        TextComponent.text = string.Empty; 
    }
}
