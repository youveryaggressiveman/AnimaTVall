using AnimaTV.Persistance.Entity;
using AnimaTV.Persistance.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimaTV.Core.Services.Errors;
using AnimaTV.Core.Services.Errors.NullReferenceException;
using AnimaTV.Persistance.Mongo.Model;

namespace AnimaTV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly animatv_kernelContext _context;
        private readonly IAuthService _authService;
        private readonly IErrorService _errorService;

        public UsersController(animatv_kernelContext context, IAuthService authService, IErrorService errorService)
        {
            _context = context;
            _authService = authService;
            _errorService = errorService;
        }

        [Route("getUserByToken")]
        [HttpPost]
        public async Task<IActionResult> GetUserByToken(string token)
        {
            if ((_errorService as NullReferenceExceptionService).CheckError(new object[] {token}))
            {
                return Ok((_authService as AuthService).GetCashedUser(token));
            }

            throw new NullReferenceException();
        }

        [Route("auth")]
        [HttpPost]
        public async Task<IActionResult> Auth(string login, string password, bool isSave)
        {
            if (!(_errorService as NullReferenceExceptionService).CheckError(new object[] {login, password, isSave}))
            {
                throw new NullReferenceException();
            }

            var targetList = await _context.Users.Where(u => u.NickName == login).ToListAsync<User>();


            (_authService as AuthService).RegisterUserList(targetList);
            try
            {
                var user = _authService.Auth(login, password, isSave);

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return Ok(user.Token);
            }
            catch (Exception ex)
            {

                throw new OperationCanceledException(ex.Message);
            }

        }

        [HttpPost]
        [Route("registr")]
        public async Task<IActionResult> Registration(User user)
        {
            if (!(_errorService as NullReferenceExceptionService).CheckError(new object[] { user }))
            {
                throw new NullReferenceException();
            }

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var token = await Auth(user.NickName, user.Password, false);

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }

        // TODO: Продумать работу с монго и SQL для обновления инофрмации о пользователе
        [HttpPut]
        [Route("updateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody]User updateUser, [FromBody]Address address)
        {
            if (!(_errorService as NullReferenceExceptionService).CheckError(new object[] { updateUser, address }))
            {
                throw new NullReferenceException();
            }

        }
    }
}
