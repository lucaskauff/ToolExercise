﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

[Serializable]
public class Ingredient
{
    public string name;
    public int amount;
    public IngredientUnit unit;
}

public class Recipe : MonoBehaviour
{
    public Ingredient potionResult;
    public Ingredient[] potionArray;
}