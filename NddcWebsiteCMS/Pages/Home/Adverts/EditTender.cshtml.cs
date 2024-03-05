using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class EditTenderModel : PageModel
    {
        private readonly ITendersData tenderDb;
        private readonly IAzureStorage storage;

        [BindProperty(SupportsGet = true)]
        public MyTenderModel Tender { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile Upload { get; set; }

        public EditTenderModel(ITendersData tenderDb, IAzureStorage storage)
        {
            this.tenderDb = tenderDb;
            this.storage = storage;
        }
        public void OnGet(int? Id)
        {
            Tender = tenderDb.ViewTenderDetails(Id.Value);
        }
        public async Task<IActionResult> OnPost(int? Id)
        {
            if (Upload is not null)
            {
                string fileName = "Tenders/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
                MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
                Tender.DocumentUrl = response.Blob.Uri;
            }
            Tender.Id = Id.Value;
            tenderDb.EditTender(Tender);
            return RedirectToPage("Tenders");
        }
    }
}
