using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YtApis.Modal;
using static YtApis.Modal.AppDbModal;

namespace YtApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly AppDbContext appDbContext;
        public class apiResponse
        {
            public object Result { get; set; }
            public string Message { get; set; }
        }
        public UserController(AppDbContext _dbcontext) {
        appDbContext = _dbcontext;
        }
        [HttpGet("GetUsers")]
        public apiResponse GetUsers()
        {
            var users = appDbContext.Users.ToList();
            return new apiResponse { Message="Success",Result = users};
        }
        [HttpPost("AddUser")]

        public apiResponse AddUser(Users obj)
        {
            var userExists = appDbContext.Users.Where(x => x.Email == obj.Email).FirstOrDefault();
            if(userExists == null)
            {
                Users addUser = new Users();
                addUser.Email = obj.Email;
                addUser.Name = obj.Name;
                addUser.Mobile = obj.Mobile;
                appDbContext.Users.Add(addUser);
                appDbContext.SaveChanges();
                return new apiResponse { Message = "User Added", Result = addUser };
            }
            else
            {
                userExists.Mobile = obj.Mobile;
                userExists.Name = obj.Name;
                appDbContext.SaveChanges();
                return new apiResponse { Message="User already exists!", Result= userExists };
            }

        }

        [HttpGet("DeleteUserByID")]
        public apiResponse DeleteUserByID(int ID)
        {
            var user = appDbContext.Users.Where(x => x.ID == ID).FirstOrDefault();
            if (user != null)
            {
                appDbContext.Users.Remove(user);
                appDbContext.SaveChanges();
                return new apiResponse { Message = "User Deleted!"};
            }
            else
            {
                return new apiResponse { Message = "Not Found!" };
            }
        }
    }
}
