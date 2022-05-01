using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    enum PlayerState
    {
        Idle,
        Run,
        Pick,
        Attack
    }

    private StateMachine stateMachine;

    private Dictionary<PlayerState, IState> dicState = new Dictionary<PlayerState, IState>();

    // pick up ����
    [SerializeField] float range;
    bool pickUpActivated = false;

    RaycastHit hitInfo;

    [SerializeField] LayerMask layerMask;

    // �κ��丮 ����
    [SerializeField] Inventory inventory;

    // ���� ����
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        IState idle = new StateIdle();
        IState run = new StateRun();
        IState pick = new StatePick();
        IState attack = new StateAttack();

        dicState.Add(PlayerState.Idle, idle);
        dicState.Add(PlayerState.Run, run);
        dicState.Add(PlayerState.Pick, pick);
        dicState.Add(PlayerState.Attack, attack);

        stateMachine = new StateMachine(idle);
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();

        stateMachine.DoOperateUpdate();
    }

    void KeyboardInput()
    {
        // ��� ������ ��쿡�� �޸��� ����.
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (stateMachine.CurrentState == dicState[PlayerState.Idle])
            {
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
        }
        else stateMachine.SetState(dicState[PlayerState.Idle]);

        // ���� ������ ��� �ݱ� �Ұ���.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(stateMachine.CurrentState == dicState[PlayerState.Idle] || stateMachine.CurrentState == dicState[PlayerState.Run])
            {
                stateMachine.SetState(dicState[PlayerState.Pick]);
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            if (stateMachine.CurrentState == dicState[PlayerState.Idle] || stateMachine.CurrentState == dicState[PlayerState.Run])
            {
                stateMachine.SetState(dicState[PlayerState.Attack]);
            }
        }
    }

    // pick up �Լ�
    public void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item") ItemInfoAppear();
        }
        else ItemInfoDisappear();
    }

    void ItemInfoAppear()
    {
        pickUpActivated = true;
    }

    void ItemInfoDisappear()
    {
        pickUpActivated = false;
    }

    public void CanPickUp()
    {
        if(pickUpActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName);
                inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                ObjectPool.instance.objectPoolList[0].Enqueue(hitInfo.transform.gameObject);
                hitInfo.transform.gameObject.SetActive(false);
                ItemInfoDisappear();
            }
        }
    }
}
