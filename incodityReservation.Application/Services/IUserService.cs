using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace incodityReservation.Application.Services
{
    public interface IUserService
    {
        Task Register(RegisterUserDto userDto);
        Task<bool> Login(LoginUserDto userDto);
    }

    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Display(Name = "ثبت نام کاربر")]
        public async Task Register(RegisterUserDto userDto)
        {
            try
            {
                var findUser = _userManager.FindByNameAsync(userDto.UserName).GetAwaiter().GetResult();
                if (findUser != null)
                    throw new Exception("Duplicate Username");

                var findRole = await _roleManager.FindByNameAsync("Customer");
                if (findRole is null)
                {
                    Role role = new()
                    {
                        Name = "Customer",
                        NormalizedName = "Customer",
                        Description = "Customer"
                    };
                    await _roleManager.CreateAsync(role);
                }

                User user = new()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    Image = null
                };
                var createUser = await _userManager.CreateAsync(user,userDto.PassWord);
                if (createUser.Succeeded)
                {
                    var userAddRole = await _userManager.AddToRoleAsync(user, "Customer");
                    await _userManager.AddClaimsAsync(user, new[]
                    {
                        new Claim(JwtClaimTypes.Name, user.FirstName + " " + user.LastName),
                        new Claim(JwtClaimTypes.Email, user.Email),
                        new Claim(JwtClaimTypes.GivenName,user.FirstName),
                        new Claim(JwtClaimTypes.FamilyName,user.LastName),
                        new Claim(JwtClaimTypes.Role,"Customer"),
                    });
                }
            }
            catch(Exception ex) 
            {

            }
        }

        [Display(Name = "ورود کاربر")]
        public async Task<bool> Login(LoginUserDto userDto)
        {
            bool result = false;
            var findUser = _userManager.FindByNameAsync(userDto.UserName).GetAwaiter().GetResult();
            if (findUser == null)
                return result;

            var signResult = await _signInManager.PasswordSignInAsync(findUser, userDto.Password, userDto.RememberMe, lockoutOnFailure: true);
            if (signResult.Succeeded)
                result = true;

            return result;

        }
    }
}
