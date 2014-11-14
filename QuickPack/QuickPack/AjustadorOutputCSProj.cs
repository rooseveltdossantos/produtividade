using System;
using System.IO;
using System.Xml.Linq;
using Inventti.Core._4._0.Extensions;

namespace QuickPack
{
    public class AjustadorOutputCSProj
    {
        public EventHandler<OutputCSProjProcessado> OnOutputCSProjProcessado { get; set; }

        public void Ajustar(string projectFileName, string basePath)
        {
            var csProj = XDocument.Load(projectFileName, LoadOptions.None);
            var outputs = csProj.ObterXElements("/Project/PropertyGroup/OutputPath");
            basePath = ObterPastaRelativa(projectFileName, basePath);
            foreach (var output in outputs)
            {
                if (OnOutputCSProjProcessado != null)
                    OnOutputCSProjProcessado(this, new OutputCSProjProcessado(projectFileName, output.Value, basePath));
                output.SetValue(basePath);
            }
            csProj.Save(projectFileName);
        }

        private string ObterPastaRelativa(string projectFileName, string basePath)
        {
            Uri uriProjectPath = new Uri(Path.GetFullPath(projectFileName));
            Uri uriBasePath = new Uri(basePath);
            Uri uriRelativa = uriProjectPath.MakeRelativeUri(uriBasePath);
            return uriRelativa.ToString();
        }
    }

    public class OutputCSProjProcessado : EventArgs
    {
        public OutputCSProjProcessado(string projectFileName, string originalValue, string newValue)
        {
            NewValue = newValue;
            OriginalValue = originalValue;
            ProjectFileName = projectFileName;
        }

        public string ProjectFileName { get; private set; }
        public string OriginalValue { get; private set; }
        public string NewValue { get; private set; }
    }
}
