using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager) 
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}
