using UnityEngine;

public class endlessRunner : MonoBehaviour
{
    [SerializeField] private float vbegin = 4f;
    [SerializeField] private float g = -5f;
    [SerializeField] private Animator animator;

    private enum State { running, jumping }
    private State myState = State.running;

    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float tmax = 1.667f;
    private float t = 0f;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        myState = State.running;
        velocity = Vector3.zero;
        animator.SetTrigger("ren");
    }

    private void Update()
    {
        if (myState == State.running && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            myState = State.jumping;
            t = 0f;
            g = -2f * vbegin / tmax;
            velocity.y = vbegin;
            animator.SetTrigger("Jump");
        }

        if (myState == State.jumping)
        {
            t += Time.deltaTime;
            velocity.y += g * Time.deltaTime;

            if (t >= tmax)
            {
                myState = State.running;
                velocity.y = 0f;
                animator.SetTrigger("ren");
            }
        }

        transform.position += velocity * Time.deltaTime;
    }
}
