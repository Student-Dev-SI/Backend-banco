using System.IO;
using System.Net.Http.Headers;
using backend.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories {
    public class UploadImageRepository : ControllerBase{
        public string Upload (IFormFile arquivo, string savingFolder) {

            if (savingFolder == null)
            {
                savingFolder = Path.Combine("ResourceImage");
            }

            var pathToSave = Path.Combine (Directory.GetCurrentDirectory (), savingFolder);

            if (arquivo.Length > 0) {

                var fileName = ContentDispositionHeaderValue.Parse (arquivo.ContentDisposition).FileName.Trim ('"');
                var fullPath = Path.Combine (pathToSave, fileName);
                // var folder = Path.Combine( "ResourceImage", savingFolder, fileName);

                using (var stream = new FileStream (fullPath, FileMode.Create)) {
                    arquivo.CopyTo (stream);
                }

                return fileName;
            } else {
                //Entrar aqui caso o usuario não coloque nenhuma imagem
                // return "ResourceImage\\Usuarios\\AvatarPadrao.png";
                return null;
            }

        }
    }
}

