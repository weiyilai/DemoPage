using DemoPage.Repository.Entities;

namespace DemoPage.Models
{
    public class DemoPageViewModel
    {
        public OgImage OgImage { get; set; }

        public string OgImageTag()
        {
            if (OgImage.LocalMirrorFile)
            {
                return GetExt();
            }
            else
            {
                return GetLocalExt();
            }
        }

        private string GetExt()
        {
            if (string.IsNullOrWhiteSpace(OgImage.Ext))
            {
                return $"/File/image/{OgImage.Name}{OgImage.Ext}";
            }
            else
            {
                return $"/File/image/{OgImage.Name}-ogimge{OgImage.Ext}";
            }
        }

        private string GetLocalExt()
        {
            if (string.IsNullOrWhiteSpace(OgImage.LocalExt))
            {
                return $"/File/image/{OgImage.Name}{OgImage.Ext}";
            }
            else
            {
                return $"/File/image/{OgImage.Name}-ogimge{OgImage.LocalExt}";
            }
        }
    }
}
