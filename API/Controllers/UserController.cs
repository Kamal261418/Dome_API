using API.Dtos;
using API.Errors;
using AutoMapper.Internal;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor
            , IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<AppUser>(userDto);
            var userPassword = userDto.Passord;
            user.EmailConfirmed = false;
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user, userPassword);
            if (result.Succeeded)
            {
                var userCertificates = new List<UserCertificate>();
                foreach (var certificate in userDto.certificates)
                {
                    var certificateMap = _mapper.Map<Certificate>(certificate);
                    _unitOfWork.Repository<Certificate>().Add(certificateMap);
                    await _unitOfWork.Complete();

                    userCertificates.Add(new UserCertificate { UserId = user.Id, CertificateId = certificateMap.Id });

                }

                foreach (var item in userCertificates)
                {
                    _unitOfWork.Repository<UserCertificate>().Add(item);

                }
                await _unitOfWork.Complete();



                return Ok(userDto);
            }

            return BadRequest(new ApiResponse(400, "Problem on creating user"));

        }


        [HttpGet("GetWithCertificate")]
        public async Task<ActionResult<List<AppUser>>> GetWithCertificate()
        {
            var spec = new UserListSpecification();
            var users = await _unitOfWork.Repository<AppUser>().ListAsync(spec);
    ;
            return  users.Where(x=>x.userCertificates.Count()>5).ToList();
        }

    }
}
