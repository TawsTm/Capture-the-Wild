using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum animalOptions { Giraffe, Elefant };
    public animalOptions chooseAnimal;
    public string Name {get; set;}
    public float ScreenTime {get; set;}

    void Awake() {
        Name = chooseAnimal.ToString();
        AnimalCounter.AddAnimal(this);
    }

    /**public Animal(string _name) {
        Name = _name;
    }*/
}
