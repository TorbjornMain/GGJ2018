using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Pawn possessedPawn;

    public void PossessPawn(Pawn target)
    {
        
        if(target.controller != null)
        {
            target.controller.UnpossessPawn();
        }
        possessedPawn = target;
        target.controller = this;
    }

    public void UnpossessPawn()
    {
        possessedPawn.controller = null;
        possessedPawn = null;
    }
}
