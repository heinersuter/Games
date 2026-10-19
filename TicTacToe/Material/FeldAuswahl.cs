namespace TicTacToe.Material;

public static class FeldAuswahl
{
    public static IReadOnlyDictionary<Feld, Wert?> LeereFelder(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Value == null)
            .ToDictionary();
    }

    public static IReadOnlyDictionary<Feld, Wert?> SpalteA(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A1 or Feld.A2 or Feld.A3)
            .ToDictionary();
    }

    public static IReadOnlyDictionary<Feld, Wert?> SpalteB(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.B1 or Feld.B2 or Feld.B3)
            .ToDictionary();
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> SpalteC(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.C1 or Feld.C2 or Feld.C3)
            .ToDictionary();
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> Zeile1(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A1 or Feld.B1 or Feld.C1)
            .ToDictionary();
    }

    public static IReadOnlyDictionary<Feld, Wert?> Zeile2(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A2 or Feld.B2 or Feld.C2)
            .ToDictionary();
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> Zeile3(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A3 or Feld.B3 or Feld.C3)
            .ToDictionary();
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> DiagonaleObenLinksNachUntenRechts(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A1 or Feld.B2 or Feld.C3)
            .ToDictionary();
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> DiagonaleObenRechtsNachUntenLinks(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.C1 or Feld.B2 or Feld.A3)
            .ToDictionary();
    }
    
    public static IReadOnlyList<IReadOnlyDictionary<Feld,Wert?>> AlleSpalten(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return new List<IReadOnlyDictionary<Feld, Wert?>>
        {
            alleFelder.SpalteA(),
            alleFelder.SpalteB(),
            alleFelder.SpalteC(),
        };
    }
    
    public static IReadOnlyList<IReadOnlyDictionary<Feld,Wert?>> AlleZeilen(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return new List<IReadOnlyDictionary<Feld, Wert?>>
        {
            alleFelder.Zeile1(),
            alleFelder.Zeile2(),
            alleFelder.Zeile3(),
        };
    }
    
    public static IReadOnlyList<IReadOnlyDictionary<Feld,Wert?>> AlleDiagonalen(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return new List<IReadOnlyDictionary<Feld, Wert?>>
        {
            alleFelder.DiagonaleObenLinksNachUntenRechts(),
            alleFelder.DiagonaleObenRechtsNachUntenLinks(),
        };
    }
    
    public static IReadOnlyDictionary<Feld, Wert?> Ecken(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .Where(feld => feld.Key is Feld.A1 or Feld.C1 or Feld.A3 or Feld.C3)
            .ToDictionary();
    }
    
    public static KeyValuePair<Feld, Wert?> Mitte(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder
            .First(feld => feld.Key is Feld.B2);
    }

    
    public static IReadOnlyList<IReadOnlyDictionary<Feld,Wert?>> AlleLinien(this IReadOnlyDictionary<Feld, Wert?> alleFelder)
    {
        return alleFelder.AlleSpalten()
            .Concat(alleFelder.AlleZeilen())
            .Concat(alleFelder.AlleDiagonalen())
            .ToList();
    }
}