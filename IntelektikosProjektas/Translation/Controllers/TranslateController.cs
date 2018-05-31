using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using IntelektikosProjektas.Models;

namespace IntelektikosProjektas.Translation.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index()
        {
            return View("Translation/Views/TextTranslateUploadPage.cshtml");
        }

        public IActionResult Translations()
        {
            TranslationModel translation = new TranslationModel();
            List<TranslationModel> translations = translation.getList();
            return View("Translation/Views/TextTranslatePage.cshtml", translations);
        } 


        public string saveText(string text)
        {
            Translatable translatable = new Translatable(text);
            return "executing: Controller Translate: saveText()" + System.Environment.NewLine + translatable.saveText();
        }

        public string saveTranslation(string text, int id)
        {
            TranslationModel translationModel = new TranslationModel(text, id);
            return "executing: Controller Translate: saveText()" + System.Environment.NewLine + translatable.saveText();
        }
    }
}