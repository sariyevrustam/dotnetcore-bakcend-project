using ResourceDomainCore.Commands;

namespace ResourceDomain.Commands
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
