using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static List<Animal> animals = new List<Animal>();

    /*Used to set the winning condition of how many animals need to be collected*/
    private static int animalsToCollect = 2;
    private static int animalsCollected = 0;

    public void OnEnable()
    {
        // This is needed to clear all missing Animals (If collected animals should be stored, the animals should not be cleared)
        animalsCollected = 0;
        //animals.Clear();
    }

    void Start() {
    }

    public static void RemoveAnimal(Animal _animal) {
        // Debug.Log("Removed " + _animal.Name);
        animals.Remove(_animal);
        animalsCollected += 1;
        AnimalBadgeManager.ActivateAnimalBadge(_animal.Name);
        for(int i = 0; i < animals.Count; i++) {
            if(animals[i].Name == _animal.Name) {
                animals.Remove(animals[i]);
                Debug.Log("Removed another one");
            }
        }
    }

    public bool AreAllObjectivesCompleted()
    {
        if (animals.Count == 0) {
            Debug.Log("No animals left to find");
            return true;
        } else if (animalsCollected < animalsToCollect) {
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
