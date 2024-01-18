using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem clickEffect;

    Vector3 targetPoint = new Vector3(0, 1, 0);

    void Update()
    {
        UserInput();
        // Debug.Log(GameData.score);
        if(GameData.health <= 0){
            Destroy(gameObject);
        }
            
    }

    private void UserInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if ((Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Crate")))){
                targetPoint = hit.point;
                
                if(MovePlayer(targetPoint)){
                    animator.SetTrigger("Running");
                }

            }

            if(touch.phase == TouchPhase.Began){
                Instantiate(clickEffect,new Vector3(targetPoint.x , 1 , targetPoint.z),Quaternion.identity);
            }
            
        }

        if(MovePlayer(targetPoint)){
            // Move the player if no wall is in between.
            Vector3 direction = (new Vector3(targetPoint.x,transform.position.y,targetPoint.z) - transform.position).normalized;
            transform.forward = direction;
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPoint.x, 1, targetPoint.z), movementSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position,targetPoint) < 1f){
                transform.forward = direction;
                animator.SetTrigger("Idling");
            }
        }
    }

    private bool MovePlayer(Vector3 target)
    {
        Vector3 origin = new Vector3(transform.position.x, 1, transform.position.z);
        Vector3 direction = target - origin;
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Wall"))
        {
            return false; // Do not move if there is a wall in between.
        }
        else{
            return true;
        }
    }

}
