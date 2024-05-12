namespace com.Halkyon.Input
{
    public class InputActions : ExtendedMonoBehaviour
    {
        public PlayerInputActions.StrategyPlayerActions StrategyPlayer;

        private void Awake()
        {
            PlayerInputActions playerInputActions = new PlayerInputActions();
            StrategyPlayer = playerInputActions.StrategyPlayer;
            StrategyPlayer.Enable();
        }
    }
}