using Domain.DTOs.User;
using Domain.Interfaces.Services.IUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskeenAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// إنشاء مستخدم جديد.
        /// </summary>
        /// <param name="dto">بيانات المستخدم لإنشاءه.</param>
        /// <returns>معرف المستخدم الجديد.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int?>> Create([FromBody] UserCommandDTO dto)
        {
            try
            {
                var userId = await _userService.CreateAsync(dto);

                if (userId.HasValue)
                    return StatusCode(201, userId); // Created

                return StatusCode(400, "فشل إنشاء المستخدم."); // Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع: {ex.Message}");
            }
        }

        /// <summary>
        /// تحديث بيانات مستخدم موجود.
        /// </summary>
        /// <param name="dto">بيانات المستخدم المحدثة.</param>
        /// <returns>True إذا تم التحديث بنجاح.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Update([FromBody] UserCommandDTO dto)
        {
            try
            {
                var result = await _userService.UpdateAsync(dto);

                if (result)
                    return StatusCode(200, true); // OK

                return StatusCode(404, "المستخدم غير موجود."); // Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع: {ex.Message}");
            }
        }

        /// <summary>
        /// حذف مستخدم حسب المعرف.
        /// </summary>
        /// <param name="userId">معرف المستخدم.</param>
        /// <returns>True إذا تم الحذف بنجاح.</returns>
        [HttpDelete("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete([FromRoute] int userId)
        {
            try
            {
                var result = await _userService.DeleteAsync(userId);

                if (result)
                    return StatusCode(200, true); // OK

                return StatusCode(404, "المستخدم غير موجود."); // Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع: {ex.Message}");
            }
        }

        /// <summary>
        /// استرجاع مستخدم حسب المعرف.
        /// </summary>
        /// <param name="userId">معرف المستخدم.</param>
        /// <returns>بيانات المستخدم.</returns>
        [HttpGet("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserReadDTO?>> Get([FromRoute] int userId)
        {
            try
            {
                var user = await _userService.GetAsync(userId);

                if (user != null)
                    return StatusCode(200, user); // OK

                return StatusCode(404, "المستخدم غير موجود."); // Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع: {ex.Message}");
            }
        }

        /// <summary>
        /// استرجاع جميع المستخدمين.
        /// </summary>
        /// <returns>قائمة بجميع المستخدمين.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserReadDTO>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                if (users == null || users.Count == 0)
                    return StatusCode(404, "لا يوجد مستخدمين."); // Not Found
                return StatusCode(200, users);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع: {ex.Message}");
            }
        }


    }
}
