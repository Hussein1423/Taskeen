using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.DTOs
{
    public class AuthResultDto
    {
        // أخطاء (إذا فشلت العملية)

        public bool IsSuccess { get; set; }
        public string Message { get; set; }     
        
        public AuthResultDto(bool isSuccess,string Message)
        {
                       IsSuccess = isSuccess;
                       this.Message = Message;
        }
    }
}
