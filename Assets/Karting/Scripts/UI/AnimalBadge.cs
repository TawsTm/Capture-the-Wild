using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalBadge : MonoBehaviour
{
    public enum animalBadgeOptions { Zebra, Elefant, Antilope, Buffalo, Gepard, Giraffe, Gnu, Hyaene, Krokodil, Loewe, Nashorn, Nilpferd, Strauss, Wildschwein };
    public animalBadgeOptions chooseAnimalBadge;
    public string Name {get; set;}
    private Image image;

    void Awake() {
        Name = chooseAnimalBadge.ToString();
        image = GetComponent<Image>();
        image.color = new Color(1,0,0,1);
        AnimalBadgeManager.AddAnimal(this);
    }

    public void ActivateBadge() {
        image.color = new Color(0,1,0,1);
    }
}
