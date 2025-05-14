using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TestCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject _sliderPerso;

    [SerializeField]
    private GameObject _sliderObjectif;

    public string[] Sentences; // Tableau de cha�nes de caract�res pour stocker les phrases du dialogue
    public GameObject Button;
    private Scrollbar _sliderPersoComponent;
    private Scrollbar _sliderObjectifComponent;
    public  TMP_Text TextComponent;
    private int points = 0;
    private float elapsedTime = 0f;
    private float elapsedTimeFunc = 0f;
    private float _randomZone;
    private float _randomOffset;


    public bool rentrer = false;

    private void Start()
    {
        _sliderPersoComponent = _sliderPerso.GetComponent<Scrollbar>();
        _sliderObjectifComponent = _sliderObjectif.GetComponent<Scrollbar>();

        RandomZone();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && rentrer)
        {
            _sliderPerso.SetActive(true);
            _sliderObjectif.SetActive(true);
            _sliderPersoComponent.value += 0.1f;

            /*
            Dialogue.Instance.Sentences[0] = "Bonjour ! Je suis un PNJ !"; // D�finit la premi�re phrase du dialogue
            Dialogue.Instance.StartDialogue();
            Debug.Log("Collision avec le joueur d�tect�e !");
            */
        }

        PointsCardio(1f);

        ObjectifCardio(5f);

        if (_sliderPerso.activeSelf && _sliderPersoComponent.value > 0)
        {
            _sliderPersoComponent.value -= 0.5f * Time.deltaTime;
        }

        TextComponent.text = $"Points : {points}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);

        // V�rifie si le collider a le tag "Player"
        if (collision.CompareTag("Player"))
        {
            rentrer = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
        _sliderPerso.SetActive(false);
        _sliderObjectif.SetActive(false);
        _sliderPersoComponent.value = 0;

        rentrer = false;
    }


    private void PointsCardio(float seconde)
    {
        if (_sliderPersoComponent.value >= (_randomZone - 0.05f) && _sliderPersoComponent.value <= _randomOffset)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= seconde)
            {
                points += 1;
                elapsedTime = 0f;
            }
        }
    }

    private void ObjectifCardio(float seconde)
    {
        if (_sliderPersoComponent.value >= (_randomZone - 0.05f) && _sliderPersoComponent.value <= _randomOffset)
        {
            elapsedTimeFunc += Time.deltaTime;

            if (elapsedTimeFunc >= seconde)
            {
                RandomZone();
                elapsedTimeFunc = 0f;
            }
        }
    }

    private void RandomZone()
    {
        _randomZone = Random.Range(1, 9);
        _randomOffset = _randomZone + 1;
        _randomZone = _randomZone / 10f;
        _randomOffset = _randomOffset / 10f;
        _sliderObjectifComponent.value = _randomZone;
    }
}
