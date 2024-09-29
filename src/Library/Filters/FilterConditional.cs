using System;
using System.Drawing;
using CompAndDel;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters;

public class FilterConditional : IFilter
{
    private CognitiveFace _cognitiveApi;
    public bool Resultado { get; private set; }

    public FilterConditional(CognitiveFace cognitiveApi)
    {
        _cognitiveApi = cognitiveApi;
    }

    // Implementación del filtro que revisa si la imagen contiene una cara
    public void Filter(Picture image)
    {
        // Utilizar la API Cognitiva para reconocer la imagen
        
        Resultado = _cognitiveApi.Recognize(image);
    }
}