using UnityEngine;

public class Damage : MonoBehaviour
{
    private byte IsDamaged;

    public byte IsDamageTaken()
    {
        return IsDamaged;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
            IsDamaged ++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
            IsDamaged = 0;
    }
}
