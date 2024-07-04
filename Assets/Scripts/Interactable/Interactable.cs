using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Nico
public abstract class Interactable : MonoBehaviour
{
    public abstract void OnInteract(Player player);
}
