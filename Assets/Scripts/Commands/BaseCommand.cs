namespace Assets.Scripts.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public string UserName { get; set; }
    }
}