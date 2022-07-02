using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum animalOptions { Zebra, Elefant, Antilope, Buffalo, Gepard, Giraffe, Gnu, Hyaene, Krokodil, Loewe, Nashorn, Nilpferd, Strauss, Wildschwein };
    public animalOptions chooseAnimal;
    public string Name {get; set;}
    public float ScreenTime {get; set;}

    public static List<Animal> animals = new List<Animal>();

    FeedbackFlashHUD m_FeedbackFlashHUD;

    void Awake() {
        Name = chooseAnimal.ToString();
        AnimalManager.AddAnimal(this);
    }

    void Start() {
        m_FeedbackFlashHUD = FindObjectOfType<FeedbackFlashHUD>();
		DebugUtility.HandleErrorIfNullFindObject<FeedbackFlashHUD, Animal>(m_FeedbackFlashHUD, this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AnimalManager.RemoveAnimal(this, false);
            m_FeedbackFlashHUD.FlashWarning();
        }
    }
}
