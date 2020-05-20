using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    NavMeshAgent _navmeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navmeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(_navmeshAgent == null){
            Debug.LogError("Nav mesh agent component is not attached");
        }
        else {
            setDestination();
        }
        
    }

    private void setDestination(){
        if(_destination != null){
            // Vector3 targetVector = _destination.transform.position;
            // _navmeshAgent.SetDestination(targetVector);
            // _navmeshAgent.SetDestination(_destination.position);
            _navmeshAgent.destination = _destination.position;
        }
        if ((this.transform.position - _navmeshAgent.destination).magnitude < .1f)
        {
            _navmeshAgent.isStopped = true;
        }
    }

}
