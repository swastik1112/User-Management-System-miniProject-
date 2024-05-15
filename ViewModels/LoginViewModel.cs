using Microsoft.AspNetCore.Mvc.Rendering;

namespace miniProject.ViewModels
{
    public class LoginViewModel
    {
        
        public string LoginName { get; set; }
       
        public string Password { get; set; }

        public bool CheckBox { get; set; }
        
    }
}
