namespace Core.Domain.Helpers;

public static class EstatusHelp
{
    public static bool Estatus(bool Todos, bool Estatus)
    {
        if (!Todos)
        {
            return true;
        } 
        
        return Estatus;
    }
}