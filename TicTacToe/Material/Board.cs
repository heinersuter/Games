namespace TicTacToe.Material;

public class Board
{
    private readonly Dictionary<Feld, Wert?> _felder = new() 
    { 
        { Feld.A1, null },
        { Feld.B1, null },
        { Feld.C1, null },
        { Feld.A2, null },
        { Feld.B2, null },
        { Feld.C2, null },
        { Feld.A3, null },
        { Feld.B3, null },
        { Feld.C3, null },
    };
    
    public Wert? LetzterZug { get; private set; }

    public Wert? Sieger { get; private set; }
    
    public bool IstVoll => _felder.All(f => f.Value != null);
    
    public IReadOnlyDictionary<Feld, Wert?> Felder => _felder;
    
    public bool SetzeFeld(Feld feld, Wert wert)
    {
        if (wert == LetzterZug)
        {
            Console.WriteLine("Der Spieler ist nicht am Zug.");
            return false;
        }
        
        if (Sieger != null)
        {
            Console.WriteLine("Das Spiel ist bereits beendet.");
            return false;
        }
        
        if (_felder[feld] != null)
        {
            Console.WriteLine("Das Feld ist bereits besetzt.");
            return false;
        }

        _felder[feld] = wert;
        LetzterZug = wert;
        WertGeändert();
        return true;
    }

    private void WertGeändert()
    {
        Sieger = SiegerPrüfung.PrüfeSieger(this);
    }
}