/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RollerAgent_SH_ : Agent
{
    Rigidbody rb;
    public float speed = 10f;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   // public Transform Target;

    public override void OnEpisodeBegin()
    {
          if (this.transform.localPosition.y < 0)
          {
              // if the agent falls, set its momentum to zero
              this.rb.angularVelocity = Vector3.zero;
              this.rb.velocity = Vector3.zero;
              //  this.transform.localPosition = new Vector3(0, 0.5f, 0);
          }

          Target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);

        player.localPosition = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        player.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.z);
    }

    public float forceMultiplier = 10;

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rb.AddForce(controlSignal * forceMultiplier);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached Target
        if (distanceToTarget > 1.42f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Fell of the Platform
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}

*/
