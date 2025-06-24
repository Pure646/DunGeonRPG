using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface Baseing
{
    void Hello();
}
public class InterFace : Baseing
{
    public void Hello()
    {
        Debug.Log("Hello ?!?");
    }
}
public class Hiiiiiii : Baseing
{
    public void Hello()
    {
        Debug.Log("Hi !!");
    }
}
