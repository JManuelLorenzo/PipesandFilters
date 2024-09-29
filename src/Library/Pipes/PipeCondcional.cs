/*namespace CompAndDel.Pipes;


public class PipeConditional : IPipe
{
    protected IFilter filtro;
    protected IPipe nextPipeOne;
    protected IPipe nextPipeTwo;
    
    

    public PipeConditional(IFilter filtro, IPipe nextPipe1, IPipe nextPipe2)
    {
        this.nextPipeOne = nextPipe1;
        this.nextPipeTwo = nextPipe2;
        this.filtro = filtro;
    }
    public IPicture Send(IPicture picture)
    {
        picture = this.filtro.Filter(picture);
        if (resultado == true){
            return this.nextPipeOne.Send(picture);}
        else
        {
            return this.nextPipeTwo.Send(picture);
        }
    }
}
/*