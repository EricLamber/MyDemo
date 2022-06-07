using UnityEngine;

public class WallForEnemy : MonoBehaviour
{
    private bool IsWall;

    public bool Wall()
    {
        return IsWall;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            IsWall = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            IsWall = false;
    }
}
