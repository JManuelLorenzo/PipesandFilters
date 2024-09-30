
using CompAndDel.Filters;
namespace CompAndDel.Pipes
 {
     public class PipeConditional : IPipe
     {
         protected FilterConditional filtro;  // Cambiar a FilterConditional
         protected IPipe nextPipeOne;
         protected IPipe nextPipeTwo;
 
         public PipeConditional(FilterConditional filtro, IPipe nextPipe1, IPipe nextPipe2)
         {
             this.nextPipeOne = nextPipe1;
             this.nextPipeTwo = nextPipe2;
             this.filtro = filtro;
         }
 
         public IPicture Send(IPicture picture)
         {
             // Aplicar el filtro a la imagen
             picture = this.filtro.Filter(picture);
 
             // Usar el resultado del filtro para decidir qué pipe seguir
             if (filtro.Resultado)
             {
                 return this.nextPipeOne.Send(picture);
             }
             else
             {
                 return this.nextPipeTwo.Send(picture);
             }
         }
     }
 }
