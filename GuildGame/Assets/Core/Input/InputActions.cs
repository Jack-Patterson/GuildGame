namespace com.Halkyon.Input
{
    public class InputActions : ExtendedMonoBehaviour
    {
        public PlayerInputActions.StrategyPlayerActions Player;

        private void Awake()
        {
            PlayerInputActions playerInputActions = new PlayerInputActions();
            Player = playerInputActions.StrategyPlayer;
            Player.Enable();
        }
    }
}