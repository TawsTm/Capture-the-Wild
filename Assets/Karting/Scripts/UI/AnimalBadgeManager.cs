using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBadgeManager : MonoBehaviour
{
    public static List<AnimalBadge> animalBadges = new List<AnimalBadge>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ActivateAnimalBadge(string _animalName) {
        for(int i = 0; i < animalBadges.Count; i++) {
            if(animalBadges[i].Name == _animalName) {
                animalBadges[i].ActivateBadge();
                return;
            }
        }
    }

    public static void AddAnimal(AnimalBadge _animalBadge) {
        animalBadges.Add(_animalBadge);
        //Debug.Log(_animal.Name);
    }
}
