namespace TodoListPlus.Identity.Seeds
{
    /// <summary>
    /// 创建用户种子
    /// </summary>
    public static class CreateFirstUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationFirstUser = new ApplicationUser
            {
                Email = "heichengzi2024@outlook.com",
                FirstName = "hei",
                LastName = "chengzi",
                UserName = "heichengzi",
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(applicationFirstUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationFirstUser, "995810782Asd");
            }
        }
    }
}
