namespace com.Halcyon.Core.Interaction.Character.Tasks
{
    public class PrintTask : Task
    {
        private string _message;

        public PrintTask(Interaction.Character.Character character) : base(character)
        {
        }

        public override void Execute()
        {
            Print(_message);
            CompleteTask();
        }

        public override void Reset()
        {
            _message = "";
        }

        public void SetPrintMessage(string message)
        {
            _message = message;
        }
    }
}