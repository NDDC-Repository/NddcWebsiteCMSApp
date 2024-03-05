using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Publications
{
    public class EditPublicationsModel : PageModel
    {
        private readonly IPublicationsData pubDb;
        private readonly IAzureStorage storage;
        [BindProperty(SupportsGet = true)]
        public MyPublicationModel Publication { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public EditPublicationsModel(IPublicationsData pubDb, IAzureStorage storage)
        {
            this.pubDb = pubDb;
            this.storage = storage;
        }
        public void OnGet(int? Id)
        {
            //Publication = pubDb.p(Id.Value);
        }
        //public async Task<IActionResult> OnPost(int? pubId)
        //{
        //    if (Upload is not null)
        //    {
        //        string fileName = "Photos/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
        //        MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
        //        Publication.PubUploadUrl = response.Blob.Uri;
        //    }

        //    Publication.Id = pubId.Value;
        //    //pubDb.UpdateSightsAndIcons(Publication);

        //    return RedirectToPage("AllPublications");
        //}
    }
}
