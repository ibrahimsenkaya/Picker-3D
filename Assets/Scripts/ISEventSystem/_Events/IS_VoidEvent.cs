using IS.EventManager;
using UnityEngine;

[CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void Event")]
public class IS_VoidEvent : DefaultEvent<Void>
{
    public void Raise() => Raise(new Void());

}    
