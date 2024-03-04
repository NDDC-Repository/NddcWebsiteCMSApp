using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class AddTendersModel : PageModel
    {
        private readonly ITendersData tenderDb;
        private readonly IAzureStorage storage;

        [BindProperty]
        public MyTenderModel Tender { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile Upload { get; set; }
        public AddTendersModel(ITendersData tenderDb, IAzureStorage storage)
        {
            this.tenderDb = tenderDb;
            this.storage = storage;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            string fileName = "Tenders/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
            MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            Tender.DocumentUrl = response.Blob.Uri;

            tenderDb.AddTender(Tender);
            return RedirectToPage("Tenders");
        }
    }
}
