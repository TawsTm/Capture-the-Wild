using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static List<Animal> animals = new List<Animal>();
    public static List<string> collectedAnimals = new List<string>();

    /*Used to set the winning condition of how many animals need to be collected*/
    private static int animalsToCollect = 5;

    public void OnEnable()
    {
        // This is needed to clear all missing Animals (If collected animals should be stored, the animals should not be cleared)
        collectedAnimals.Clear();
        //animals.Clear();
    }

    void Start() {
    }

    public static void RemoveAnimal(Animal _animal, bool fotographed) {
        // Debug.Log("Removed " + _animal.Name);
        if(fotographed) {
            animals.Remove(_animal);
            if(!collectedAnimals.Contains(_animal.Name)) {
                collectedAnimals.Add(_animal.Name);
                AnimalBadgeManager.ActivateAnimalBadge(_animal.Name);
            }
            for(int i = 0; i < animals.Count; i++) {
                if(animals[i].Name == _animal.Name) {
                    animals.Remove(animals[i]);
                    Debug.Log("Removed another one");
                }
            }

        } else {
            animals.Remove(_animal);
        }
    }

    public bool AreAllObjectivesCompleted()
    {
        if (animals.Count == 0) {
            Debug.Log("No animals left to find");
            return true;
        } else if (collectedAnimals.Count < animalsToCollect) {
            return false;
        }

        // found no uncompleted objective
        return true;
    }

    public static void AddAnimal(Animal _animal) {
        
        animals.Add(_animal);
        Debug.Log(_animal.Name);
    }

    public static bool hasMember(Animal _animal) {
        if(animals.Contains(_animal)) {
            return true;
        }
        return false;
    }
}
