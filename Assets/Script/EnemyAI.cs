using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed= 4f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;//
    bool isProvoked = false;// dau tien chua bi khieu khich
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();   
        }
        else if(distanceToTarget <= chaseRange)//khoang cach den target be hon pham vi giua player vs enemy
        {
            isProvoked = true;//bi khieu khich nen tan cong 
        }
        
    }

    public void OnDamageEnemy()
    {
        isProvoked = true;
    }
    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)//neu khoang cach lon hon thi di tim muc tieu
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)// neu khoang cach be hon thi tan cong muc tieu
        {
            AttackTarget();
        }
       
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");//chuyen sang trang thai move trong anima
        navMeshAgent.SetDestination(target.position);//thi di tim den muc tieu da dinh huong
        
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        //Debug.Log(name + " has seeked anh is destroying" + target.name);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));//
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, turnSpeed * Time.deltaTime);
        Debug.Log("roll roll");
    }

    void OnDrawGizmosSelected()//vong tron khoag cach
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
