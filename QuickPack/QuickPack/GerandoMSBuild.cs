using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace QuickPack
{
    public class GerandoMSBuild
    {
        private const string ModeloMSBuildStart =
@"<?xml version='1.0' encoding='utf-8' ?>

<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>";

        private const string ModeloMSBuildEnd =
@"</Project>";



        private const string ModeloTarget =
@"\t<Target Name='Compile{0}'>
\t\t<MSBuild Projects='{1}' Targets='Compile' />
\t<Target/>";

        public GerandoMSBuild()
        {
        }

        public string Gerar(IEnumerable<string> arquivosParaGeracao)
        {
            var result = new StringBuilder(7 * 1024);
            
            result.Append(AdicionarConteudo(ModeloMSBuildStart));
            
            foreach (var caminhoCompletoParaArquivo in arquivosParaGeracao)
                result.Append(AdicionarConteudo(TargetPara(caminhoCompletoParaArquivo)));
            
            result.Append(AdicionarConteudo(ModeloMSBuildEnd));
            
            return result.ToString();
        }

        private string TargetPara(string caminhoCompletoArquivo)
        {
            string nomeTarget = GerarNomeDaTarget(caminhoCompletoArquivo);
            return string.Format(ModeloTarget, nomeTarget, caminhoCompletoArquivo);
        }

        private string GerarNomeDaTarget(string caminhoCompletoArquivo)
        {
            string nomeDoArquivo = Path.GetFileNameWithoutExtension(caminhoCompletoArquivo);
            while ((int i = nomeDoArquivo.IndexOf('.') ) != -1)
            
            throw new System.NotImplementedException();
        }

        private char AdicionarConteudo(string conteudo)
        {
            throw new System.NotImplementedException();
        }
    }
}