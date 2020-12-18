using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TestScript : MonoBehaviour
{
    public FloatEvent floatEvent;
    public Vector3Event vector3Event;
    
    public AnimationCurve animationCurve;
    public float animationDuration = 2;
    
    public Togglable<int> togglableInt = new Togglable<int>(5,true);
    public Togglable<string> togglableString= new Togglable<string>("Test",true);
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        StartCoroutine(ButtonScaleTransition());
    }

    public IEnumerator ButtonScaleTransition()
    {
        float timeElapsed = 0;
        while (timeElapsed<animationDuration)
        {
            timeElapsed += Time.deltaTime;
            float y = animationCurve.Evaluate(Mathf.Clamp01(timeElapsed / animationDuration));
            floatEvent.Invoke(y);
            vector3Event.Invoke(Vector3.one*y);
            yield return null;
        }

    }
    
    [System.Serializable]
    
    public class FloatEvent : UnityEvent<float>
    {
        
    }
    
    [System.Serializable]
    
    public class Vector3Event : UnityEvent<Vector3>
    {
        
    }
    
    [System.Serializable]
    public class Togglable<T>
    {
        public T value;
        public bool visible;

        public Togglable(T value, bool visible)
        {
            this.value = value;
            this.visible = visible;
        }
    }
}

