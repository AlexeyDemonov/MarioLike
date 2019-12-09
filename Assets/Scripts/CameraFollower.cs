using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;

    public float MinX;
    public float MaxX;

    [Tooltip("Used only with 'Lerping' option")]
    public float MoveSpeed;

    public bool InFixedUpdate;
    public bool Lerping;

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        if (!InFixedUpdate)
            FollowTarget();
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        if (InFixedUpdate)
            FollowTarget();
    }

    void FollowTarget()
    {
        var targetX = Target.position.x;

        if (targetX < MinX)
            targetX = MinX;

        if (targetX > MaxX)
            targetX = MaxX;

        if (targetX != this.transform.position.x)
        {
            Vector3 newPosition = new Vector3(targetX, this.transform.position.y, this.transform.position.z);

            if (Lerping)
            {
                float delta = InFixedUpdate ? Time.fixedDeltaTime : Time.deltaTime;
                this.transform.position = Vector3.Lerp(this.transform.position, newPosition, MoveSpeed * delta);
            }
            else
                this.transform.position = newPosition;
        }
    }
}