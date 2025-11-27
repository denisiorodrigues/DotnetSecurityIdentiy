using Microsoft.AspNetCore.Authorization;

namespace DotnetSecurityIdentiy.Api.Athorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int age)
        {
            Age = age;
        }

        public int Age { get; private set; }
    }
}
