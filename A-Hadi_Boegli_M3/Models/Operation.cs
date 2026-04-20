using System;

public class Operation
{
    public int Id_Operation { get; set; }
    public int Id_Recette { get; set; }
    public string Nom { get; set; }
    public int PositionMoteur { get; set; }
    public int Temps_attente { get; set; }
    public bool Cycle_verin { get; set; }
    public bool Quittance { get; set; }
    public bool Sens_moteur { get; set; } // false = avant, true = arrière
}
