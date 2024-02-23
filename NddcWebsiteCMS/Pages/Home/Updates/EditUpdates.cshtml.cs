using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Updates
{
    public class EditUpdatesModel : PageModel
    {
		private readonly IUpdatesData updateDb;
        public MyUpdateModel Update { get; set; }
        public EditUpdatesModel(IUpdatesData updateDb)
        {
			this.updateDb = updateDb;
		}
        public void OnGet(int? Id)
        {
            Update = updateDb.UpdatesDetails(Id.Value);

		}
		public IActionResult OnPost(int? Id)
		{
			Update.Id = Id.Value;
			updateDb.EditUpdate(Update);

			return RedirectToPage("AllUpdates");
		}
	}
}
