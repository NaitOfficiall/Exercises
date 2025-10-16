using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var afterClean = new StringBuilder();
        bool nextCharToUpper = false;
        
        foreach(char c in identifier)
        {
            if(Char.IsLetter(c))
            {
                 if (!(c >= 'α' && c <= 'ω'))
                {
                    if (nextCharToUpper)
                        afterClean.Append(Char.ToUpper(c));
                    else
                        afterClean.Append(c);
                }
            }
            nextCharToUpper = false;
            if (c == '-')
                nextCharToUpper = true;
            else if(Char.IsWhiteSpace(c))
                afterClean.Append('_');
            else if(Char.IsControl(c))
                afterClean.Append("CTRL");
        }
        return afterClean.ToString();
    }
}
