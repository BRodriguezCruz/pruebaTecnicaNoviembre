using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class CelularController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Celular.GetAll();
            ML.Celular celular = new ML.Celular();

            if (result.Correct)
            {
                celular.Celulares = result.Objects;
            }

            return View(celular);
        }


        [HttpGet]
        public IActionResult Form(int? idCelular)
        {
            ML.Result result = new ML.Result();
            ML.Celular celular = new ML.Celular();

            if (idCelular == 0 || idCelular == null)
            {
                //DDL MARCA
            }
            else
            {
                result = BL.Celular.GetById(idCelular.Value);

                if (result.Correct)
                {
                    celular = (ML.Celular)result.Object;
                }
                //DDL MARCA
            }
            return View(celular);
        }

        [HttpPost]
        public IActionResult Form(ML.Celular celular)
        {
            ML.Result result = new ML.Result();

            if (celular.IdCelular == 0)
            {
                result = BL.Celular.Add(celular);
                
                if(result.Correct)
                {
                    ViewBag.Message = "REGISTRADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROR, NO SE AGREGO EL CELULAR";
                }
            }
            else
            {
                result = BL.Celular.Update(celular);

                if (result.Correct)
                {
                    ViewBag.Message = "ACTUALIZADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROR, NO SE ACTUALIZO EL CELULAR";
                }
            }
            return PartialView("Modal");
        }


        public IActionResult Delete(int idCelular)
        {
            ML.Result result = BL.Celular.Delete(idCelular);

            if (result.Correct)
            {
                ViewBag.Message = "ELIMINADO CON EXITO";
            }
            else
            {
                ViewBag.Message = "ERROR, NO SE ELIMINO EL REGISTRO";
            }
            return PartialView("Modal");
        }
    }
}
