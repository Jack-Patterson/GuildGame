namespace com.Halcyon.Core.AI.OldCharacter.Character.Tasks
{
    public class PrintTask : Task
    {
        private string _message;

        public PrintTask(Character character) : base(character)
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