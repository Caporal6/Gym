using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestCollision : MonoBehaviour
{
    public string[] Sentences; // Tableau de chaînes de caractères pour stocker les phrases du dialogue
    public GameObject Button;
    [SerializeField]
    private GameObject _slider;
    private Scrollbar _sliderComponent;
    public TMPro.TextMeshProUGUI TextComponent;
    private int points = 0;
    private float elapsedTime = 0f;
    private float _randomZone;
    private float _randomOffset;

    public bool rentrer = false;

    private void Start()
    {
        _sliderComponent = _slider.GetComponent<Scrollbar>();

        _randomZone = Random.Range(0f, 0.9f);
        _randomOffset = _randomZone + 0.1f;

        Debug.Log(_randomZone);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && rentrer)
        {
            _slider.SetActive(true);
            _sliderComponent.value += 0.1f;

            /*
            Dialogue.Instance.Sentences[0] = "Bonjour ! Je suis un PNJ !"; // Définit la première phrase du dialogue
            Dialogue.Instance.StartDialogue();
            Debug.Log("Collision avec le joueur détectée !");
            */
        }

        if (_sliderComponent.value >= _randomZone && _sliderComponent.value <= _randomOffset)
        {
            elapsedTime += Time.deltaTime; 

            if (elapsedTime >= 1f) 
            {
                points += 1; 
                elapsedTime = 0f; 
            }
        }

        if (_slider.activeSelf && _sliderComponent.value > 0)
        {
            _sliderComponent.value -= 0.5f * Time.deltaTime;
        }

        TextComponent.text = $"Points : {points}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
        // Vérifie si le collider a le tag "Player"
        if (collision.CompareTag("Player"))
        {
            rentrer = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
        _slider.SetActive(false);
        TextComponent
        rentrer = false;
    }

}
