using UnityEngine;

namespace com.Halcyon.API.Core.Character.Tasks;

public class MoveTask : CharacterTask<Vector3>
{
    public MoveTask(ICharacterTask nextTask) : base(nextTask)
    {
    }

    protected override void Start()
    {
        throw new NotImplementedException();
    }

    protected override void Perform(Vector3 data)
    {
        throw new NotImplementedException();
    }

    protected override void Complete(ICharacterTask characterTask)
    {
        throw new NotImplementedException();
    }
}