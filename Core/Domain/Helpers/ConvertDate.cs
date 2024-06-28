namespace Core.Domain.Helpers;

public static class ConvertDate
{
    public static int DateToYear(DateTime date)
    {
        //Resta los años
        int age = DateTime.Today.Year - date.Year;
            
        //Resta un año si el mes actual es menor al mes de nacimiento
        if(DateTime.Today.Month < date.Month)
            age -= 1;
        //Si el mes actual es igual al mes de nacimiento y si el día actual es menor o igual al día de nacimiento
        else if (DateTime.Today.Month == date.Month && DateTime.Today.Day <= date.Day){
            age -= 1;
        }
        
        return age;
    }
}