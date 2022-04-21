using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class State
{
    public enum STATE { IDLE,PATROL,ATTACk,CHASE,DEATH};
    
    public enum EVENTS {ENTER,UPDATE,EXIT};
    public STATE state;
    public EVENTS eventState;
    public GameObject npc;
    public NavMeshAgent agent;
    public  Animator animator;
    public Transform playerPosition;
    public State nextState;
    float visualDistance, visualAngle, shootingDistance;
    public State(GameObject _npc,NavMeshAgent _agent,Animator _animator, Transform _playerPosition)
    {
        this.npc = _npc;
        this.agent = _agent;
        this.animator = _animator;
        this.playerPosition = _playerPosition;
       // eventState = Event > ENTER;

    }
    public virtual void EnterMethod()
    {
        eventState = EVENTS.ENTER;
    }
    public virtual void UpdateMethod()
    {
        eventState = EVENTS.UPDATE;
    }
    public virtual void ExitMethod()
    {
        eventState = EVENTS.EXIT;
    }
    public State Process()
    {
        if(eventState==EVENTS.ENTER)
        {
            EnterMethod();
        }

        if (eventState == EVENTS.UPDATE)
        {
            UpdateMethod();
        }

        if (eventState == EVENTS.EXIT)
        {
           ExitMethod();
            return nextState;
        }
        return this;
    }
}
public class Idle : State
{
public Idle(GameObject _npc, NavMeshAgent _agent, Animator _animator, Transform _playerPosition): base(_npc,_agent,_animator,_playerPosition)
    {
        state = STATE.IDLE;
    }
    public override void EnterMethod()
    {
        animator.SetTrigger("isIdle");
        base.EnterMethod();
    }
    public override void UpdateMethod()
    {
        if(Random.Range(0,100)<5)
        {
            nextState=new patroll(npc,agent,animator,playerPosition)
           eventState = EVENTS.EXIT;
        }
        base.UpdateMethod();
    }
    public override void ExitMethod()
    {
        animator.ResetTrigger("isIdle")
        base.ExitMethod();
    }
}
public class patroll : State
{
    int currentIndex = -1;
    public patroll(GameObject _npc, NavMeshAgent _agent, Animator _animator, Transform _playerPosition) : base(_npc, _agent, _animator, _playerPosition)
}