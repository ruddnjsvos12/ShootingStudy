using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    override public void Start()
    {
        _character.PlayAnimation("death", () =>
        {
            GameObject.Destroy(_character.gameObject);
            if (_character.GetCharacterType() == Character.CharType.NPC)
                _character.GenerateBoss();
        });
    }
}
