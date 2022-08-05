using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project_comp2084.Models;
using Project_comp2084.Data;
using Project_comp2084.Controllers;

namespace Project_comp2084.Tests
{
    public class ClientControllerTests:TestsHelp
    {
        [Fact]
        public async Task Index_Return_viewResult_Add_ClientList()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new ClientsController(testDb);
                var result = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(result);
                Assert.IsAssignableFrom<IEnumerable<Client>>(resVr.ViewData.Model);
            }
        }
        [Fact]
        public async Task Add_and_Remove()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new ClientsController(testDb);
                var fakeclients = MakeFakeclients(4);
                foreach (var client in fakeclients)
                {
                    var res = await testCtrl.Create(client);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
                var indRes = await testCtrl.Index();
                var indResVr = Assert.IsType<ViewResult>(indRes);

                var returnedclients = Assert.IsAssignableFrom<IEnumerable<Client>>(indResVr.ViewData.Model);
                foreach (var client in fakeclients)
                {
                    Assert.Contains(client, returnedclients);
                }

                foreach (var client in returnedclients)
                {
                    var res = await testCtrl.DeleteConfirmed(client.ClientId);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);


                }

            }


        }

    }
}
