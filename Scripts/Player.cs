using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using DG.Tweening;

public class Player : Character
{
    public PlayerType playerType;
    private Vector3 target;
    private float runSpeed = 1f;
    private bool isControlled = false;
    private AnimationController anim;
    private Rigidbody rb;
    private GameObject bridgeStickPrefab;
    private List<GameObject> stickPool;
    private NavMeshAgent agent;
    private Vector3 moveDir;


    public override void FixedUpdate()
    {
        if (!GameManager.isGameStarted)
            return;

        Move();
    }


    private void Move()
    {
        if (playerType == PlayerType.Player)
        {
            if (isControlled)
            {
                moveDir.x += InputManager.instance.deltaX;
                moveDir.x = Mathf.Clamp(moveDir.x, GameplaySettings.instance.bridgeWidth * -1f, GameplaySettings.instance.bridgeWidth);
                moveDir.y = rb.position.y;
                moveDir.z += runSpeed * Time.deltaTime;
                target = Vector3.Lerp(target, moveDir, 10f * Time.deltaTime);
                rb.position = Vector3.Lerp(rb.position, target, 10f * Time.deltaTime);
            }
        }
        else
        {

        }
    }

    private void SetState(bool setTo)
    {
        isControlled = setTo;
        agent.enabled = !setTo;
        rb.isKinematic = !setTo;

        if (setTo)
        {

            DOTween.To(x => runSpeed = x, runSpeed, GameplaySettings.instance.runSpeedWhenControlled, 0.5f);
        }
        else
        {
            DOTween.To(x => runSpeed = x, runSpeed, GameplaySettings.instance.runSpeed, 0.5f);
        }

        ManageAgent();
    }

    private void ManageAgent()
    {

    }

    public override void Initilize()
    {
        runSpeed = GameplaySettings.instance.runSpeed;
        anim = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        if (playerType == PlayerType.Player)
        {
            stickPool = new List<GameObject>();

            GameObject obj;
            for (int i = 0; i < 60; i++)
            {
                obj = Instantiate(bridgeStickPrefab);
                obj.SetActive(false);
                stickPool.Add(obj);
            }
        }   
    }



    public override void GameEnded(bool? status)
    {

    }

    public override void GameStarted(bool? status)
    {

    }
}
