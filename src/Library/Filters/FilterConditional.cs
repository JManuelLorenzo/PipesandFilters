using System;
using System.IO;
using CompAndDel;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        private CognitiveFace _cognitiveApi;
        private PictureProvider _pictureProvider; // Usar PictureProvider para guardar la imagen
        public bool Resultado { get; private set; }

        public FilterConditional(CognitiveFace cognitiveApi)
        {
            _cognitiveApi = cognitiveApi;
            _pictureProvider = new PictureProvider(); // Instanciar PictureProvider
        }

        public IPicture Filter(IPicture picture)
        {
            // Generar un nombre único para el archivo temporal
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.jpg");

            // Guardar la imagen en un archivo temporal usando PictureProvider
            _pictureProvider.SavePicture(picture, tempFilePath);

            // Usar la ruta del archivo para la API de reconocimiento facial
            _cognitiveApi.Recognize(tempFilePath);

            // Verificar si se encontraron caras o gafas
            Resultado = _cognitiveApi.FaceFound || _cognitiveApi.GlassesFound;

            // Eliminar el archivo temporal después de su uso
            File.Delete(tempFilePath);

            return picture;  // Devuelve la imagen procesada o sin procesar según el filtro
        }
    }
}