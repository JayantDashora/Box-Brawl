using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float lerpSpeed = 10.0f;

    private bool isRotating = false;
    private float startTouchX;
    private Quaternion targetRotation;

    void Update()
    {
        HandleInput();
        UpdateRotation();
    }

    void HandleInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartRotation(touch.position.x);
                    break;

                case TouchPhase.Moved:
                    RotateCamera(touch.position.x);
                    break;

                case TouchPhase.Ended:
                    EndRotation();
                    break;
            }
        }
    }

    void StartRotation(float touchX)
    {
        isRotating = true;
        startTouchX = touchX;
        targetRotation = transform.rotation; // Set the target rotation to the current rotation
    }

    void RotateCamera(float touchX)
    {
        if (isRotating)
        {
            float deltaX = touchX - startTouchX;

            float rotationY = deltaX * rotationSpeed * Time.deltaTime;

            targetRotation *= Quaternion.Euler(Vector3.up * rotationY);

            startTouchX = touchX;
        }
    }

    void EndRotation()
    {
        isRotating = false;
    }

    void UpdateRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lerpSpeed * Time.deltaTime);
    }
}
