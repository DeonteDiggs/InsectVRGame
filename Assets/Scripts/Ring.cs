using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float shrinking_rate;
    [SerializeField] private float shrinking_limit;
    [SerializeField] private float shrinking_interval;
    [SerializeField] private float shrinking_time_interval;
    [SerializeField] private float scale_factor;
    
    private Vector3 target_scale_vect;
    private bool is_shrinking;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetShrinkingInterval());
    }

    // Update is called once per frame
    void Update()
    {
        if(is_shrinking)
        {
            Shrink();
        }
    }

    IEnumerator SetShrinkingInterval()
    {
        is_shrinking = false;
           target_scale_vect = new Vector3(transform.localScale.x - shrinking_interval , transform.localScale.y 
        , transform.localScale.z - shrinking_interval);
        yield return new WaitForSeconds(shrinking_time_interval); 
        is_shrinking = true;
        
    }

    void Shrink()
    {
        if(transform.localScale.x > shrinking_limit && transform.localScale.z > shrinking_limit)
        {
            if(transform.localScale.x != target_scale_vect.x && transform.localScale.z != target_scale_vect.z)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale , target_scale_vect , shrinking_rate * Time.deltaTime);
                return;
            }
            StartCoroutine(SetShrinkingInterval());
            return;
        }
        is_shrinking = false;
    }

}
