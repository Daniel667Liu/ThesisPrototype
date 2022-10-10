using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAfterDialogState : gameBaseState
{
    
    public override void EnterState(GameStateManager stateManager)
    {
        
    }
    public override void UpdateState(GameStateManager stateManager)
    {

    }

    public override void ExitState(GameStateManager stateManager)
    {
        //after all interactions with one customer, index +1
        stateManager.customerIndex += 1;
    }
}
