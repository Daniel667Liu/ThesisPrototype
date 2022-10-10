using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{


    public CustomerBaseType[] customers;
    public int customerIndex = 0;
    public SpriteRenderer itemSpriteRender;
    private CustomerBaseType currentCustomer;
    private Fungus.Flowchart currentFlowchart;
    //get the reference of every game states, used for input info from the scene
    gameBaseState currentState;
    gameStartState gameStartState = new gameStartState();
    gameIngameState gameIngameState = new gameIngameState();
    gameEndState gameEndState = new gameEndState();



    //vars that control how fast people stand up
    
    
    void Start()
    {
        //change current state for test
        currentState = gameStartState;
        currentState.EnterState(this);
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        currentState.UpdateState(this);
    }

    public void transitState( gameBaseState next) //used for transit into next game state
    {
        currentState.ExitState(this);
        next.EnterState(this);
        currentState = next;
    }

    //for transfer the game from titile scene into gamePlay scene
    public void GameStart() 
    {
        
        transitState(gameIngameState);
    }

    //for transfer the game from gamePlay scene to end title scene
    public void GameFinish() 
    {
        transitState(gameEndState);
        
    }

    //for restart the whole game
    public void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //for quit the game in windows build

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void CustomerComeIn(CustomerBaseType customer) 
    {
        currentCustomer = customer;

        //create the flowchart according to customer, dialogs contained in the flowchart
        Fungus.Flowchart flowchart = Instantiate(customer.flowchart);
        currentFlowchart = flowchart;

        //enable to render the sprite and change the sprite for item
        itemSpriteRender.enabled = true;
        itemSpriteRender.sprite = customer.itemSprite;
    }

    //
    public void HandedDrink(CustomerBaseType customer) 
    {
        Fungus.Flowchart flowchart = Instantiate(customer.afterFlowchart);
        currentFlowchart = flowchart;
    }

    //call after hand over the drink, gice different feedbacks
    public void customerReaction(int satisfaction) 
    {
        switch (satisfaction) 
        {
            case 0:
                currentFlowchart.ExecuteBlock("Reaction0");
                break;
            case 1:
                currentFlowchart.ExecuteBlock("Reaction1");
                break;
            case 2:
                currentFlowchart.ExecuteBlock("Reaction2");
                break;
        } 
    }

}
