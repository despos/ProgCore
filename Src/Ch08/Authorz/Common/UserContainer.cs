namespace Authorz.Common
{
    public class UserContainer
    {
        public UserContainer(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
