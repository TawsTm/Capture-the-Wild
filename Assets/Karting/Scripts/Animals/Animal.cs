using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum animalOptions { Giraffe, Elefant };
    public animalOptions chooseAnimal;
    public string Name { get; set; }
    public int Id { get; set; }

    void Start() {
        AnimalCounter.AddAnimal(this);
    }
}
