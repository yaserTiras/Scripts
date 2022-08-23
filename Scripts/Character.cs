using UnityEngine;

public enum PlayerType
{
    Player,
    Zombie
}

public abstract class Character : MonoBehaviour
{

    public virtual void FixedUpdate()
    {
        
    }

    public abstract void GameStarted(bool? status);

    public abstract void GameEnded(bool? status);


    public abstract void Initilize();


    public virtual void OnEnable()
    {
        GameManager.instance.onGameStarted += GameStarted;
        GameManager.instance.onGameStarted += GameEnded;
        GameManager.instance.initializePlayers += Initilize;
    }

    public virtual void OnDisable()
    {
        GameManager.instance.onGameStarted -= GameStarted;
        GameManager.instance.onGameStarted -= GameEnded;
        GameManager.instance.initializePlayers -= Initilize;
    }
}
