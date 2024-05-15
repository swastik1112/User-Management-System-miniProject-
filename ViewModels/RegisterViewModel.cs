using Microsoft.AspNetCore.Mvc.Rendering;

namespace miniProject.ViewModels
{
    public class RegisterViewModel
    {
        public int UserNo { get; set; }
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CityNo { get; set; }
        public IEnumerable<SelectListItem> City { get; set; }
    }
}
