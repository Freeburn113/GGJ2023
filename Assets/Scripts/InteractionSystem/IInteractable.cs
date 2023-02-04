using System.Collections;
using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

public interface IInteractable
{
   public bool Interact(InteractionType attemptWithType);
}
