using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDialogState : gameBaseState
{
    
    public override void EnterState(GameStateManager stateManager)
    {
        int index = stateManager.customerIndex;
        stateManager.CustomerComeIn(stateManager.customers[index]);
    }
    public override void UpdateState(GameStateManager stateManager)
    {

    }

    public override void ExitState(GameStateManager stateManager)
    {

    }
}
