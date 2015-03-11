using System;
using System.IO;

namespace Services.EmailServices.TemplateRepository.Implementation
{
    public class TemplateRepository : ITemplateRepository
    {
        private const string TemplateFolder = "Templates";

        public string QuestionAboutAdvert()
        {
            const string templateName = "QuestionAboutAdvertTemplate.cshtml";
            string partPath = String.Format("{0}/{1}", TemplateFolder, templateName);

            string path = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, partPath));
            return path;
        }

        public string Question()
        {
            const string templateName = "QuestionTemplate.cshtml";
            string partPath = String.Format("{0}/{1}", TemplateFolder, templateName);

            string path = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, partPath));

            return path;
        }

        public string OfferFromUser()
        {

            const string templateName = "OfferFromUser.cshtml";
            string partPath = String.Format("{0}/{1}", TemplateFolder, templateName);

            string path = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, partPath));

            return path;
        }
    }
}