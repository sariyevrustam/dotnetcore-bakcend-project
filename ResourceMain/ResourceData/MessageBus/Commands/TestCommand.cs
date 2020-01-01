using ResourceDomainCore.Commands;

namespace ResourceData.MessageBus.Commands
{
    public class TestCommand : Command
    {
        public string Token { get; set; }
        public TestCommand(string token)
        {
            Token = token;
        }
    }
}
