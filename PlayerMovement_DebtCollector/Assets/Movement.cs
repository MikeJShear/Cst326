using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;

    private Rigidbody rbody;
 
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        transform.Translate(movement * speed * Time.deltaTime);

    }
}
