using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = false;

        #region Standalone Input
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
            {
                swipDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipDelta.magnitude > 50)
        {
            float x = swipDelta.x;
            float y = swipDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipDelta = Vector2.zero;
        isDraging = false;
    }
    public Vector2 SwipeDelta { get { return swipDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
}
