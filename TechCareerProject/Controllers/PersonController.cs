using Microsoft.AspNetCore.Mvc;
using TechCareerProject.Models;

namespace TechCareerProject.Controllers
{
    public class PersonController : Controller
    {

        public ActionResult VerifyUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(PersonModel person)
        {
            try
            {

                using (VerifyID.KPSPublicSoapClient client =
                    new VerifyID.KPSPublicSoapClient(VerifyID.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12))
                {
                    bool result = client.TCKimlikNoDogrulaAsync(Convert.ToInt64(person.IdNumber), person.Name, person.Surname, person.BirthYear).Result.Body.TCKimlikNoDogrulaResult;
                    if (!result)
                    {
                        return View("Fail");
                    }
                    else
                    {
                        return View("Success");
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }



        }


    }



}
