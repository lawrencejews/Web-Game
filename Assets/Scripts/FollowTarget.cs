using UnityEngine;

public class FollowTarget : MonoBehaviour
{

  [SerializeField] Transform m_target;
  [SerializeField] float m_retargetingSpeed = 2f;
  RollingMovement m_rollingMovement;

  void Start()
    {
    // Gather components
    m_rollingMovement = GetComponent<RollingMovement>();

  }

    
    void FixedUpdate()
    {
    // Point the direction vector toward the target.
    Vector3 m_targetDirection = m_target.position - transform.position;

    // If the sphere is close, set the retarget speed to be high
    // otherwise, use the typicl retargeting speed
    float retargetSpeed = Vector3.SqrMagnitude(m_targetDirection) < 0.1f ? 1000f : m_retargetingSpeed;

    // Linearly interporate the movement vector from the current direction to the target 
    // where T (time) is fixed delta time multiplied by the retargeting speed.
    m_rollingMovement.m_movementDirection = Vector3.Lerp(m_rollingMovement.m_movementDirection,
                                                        m_targetDirection.normalized,
                                                        Time.fixedDeltaTime * retargetSpeed);
  }
}
