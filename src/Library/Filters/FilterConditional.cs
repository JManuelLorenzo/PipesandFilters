using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters;

public class FilterConditional : IFilter
{
    private CognitiveAPI _cognitiveApi;
    public bool Resultado { get; private set; }

    public FilterConditional(CognitiveAPI cognitiveApi)
    {
        _cognitiveApi = cognitiveApi;
    }

    // Implementación del filtro que revisa si la imagen contiene una cara
    public void Filter(Image image)
    {
        // Utilizar la API Cognitiva para reconocer la imagen
        Resultado = _cognitiveApi.Recognize(image);
    }
}