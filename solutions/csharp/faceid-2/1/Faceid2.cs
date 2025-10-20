using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    protected bool Equals(FacialFeatures other)
    {
        return EyeColor == other.EyeColor && PhiltrumWidth.Equals(other.PhiltrumWidth);
    }
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FacialFeatures)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

     protected bool Equals(Identity other)
    {
        return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
    }
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Identity)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private static readonly Identity adminPerson = new Identity ("admin@exerc.ism", new FacialFeatures("green" , 0.9m));
    private HashSet<Identity> registredIdentity = new();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(adminPerson);

    public bool Register(Identity identity) => !IsRegistered(identity) && registredIdentity.Add(identity);

    public bool IsRegistered(Identity identity) => registredIdentity.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);

}
