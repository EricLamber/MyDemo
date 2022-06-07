using UnityEngine;

public class Sensor_Prototype : MonoBehaviour 
{
    private bool IsColllisionTrigered;
    private bool IsIgnoring;

    public bool Ignoring()
    {
        return IsIgnoring; 
    }

    public bool State()
    {
        return IsColllisionTrigered;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsIgnoring = other.tag is "Platform" or "WallForEnemy" or "Fruit";
        IsColllisionTrigered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsIgnoring = other.tag is "Platform" or "WallForEnemy" or "Fruit";
        IsColllisionTrigered = false;
    }
}
