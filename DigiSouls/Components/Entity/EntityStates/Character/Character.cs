using DigiSouls.Components.Entity.Character;

namespace DigiSouls.Components.Entity.EntityStates.Character
{
    public class Character : Entity
    {
        private CharacterBody characterBody;

        public Character()
        {
            this.characterBody = new CharacterBody();
            this.AddComponent(characterBody);
            this.stateMachine = new EntityStateMachine(new CharacterIdleState(this.characterBody));
        }
    }
}
