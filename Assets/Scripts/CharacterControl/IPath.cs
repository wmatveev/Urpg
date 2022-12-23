using UnityEngine;

namespace CharacterControl
{
    public interface IGetPath
    {
        Vector3 GetNextPosition();
    }
}