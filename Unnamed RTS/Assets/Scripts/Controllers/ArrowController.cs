using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    public float delay = 0.5f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}