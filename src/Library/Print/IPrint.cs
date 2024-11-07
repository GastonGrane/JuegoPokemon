// -----------------------------------------------------------------------
// <copyright file="IPrint.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library;

public interface IPrint
{
    public void PrintList(List<Pokemon> list);

    public void PrintString(string str);

    public int PrintStringAndReceiveInt(string str);

    public void PrintListAtaque(List<Attack> ataques);

    public int SelectAtaque(string str);
}
