// ////////////////////
//        MAIN
// ////////////////////

string ruta = verificarRuta();

// ////////////////////
//     FUNCIONES
// ////////////////////

// Verica que la ruta sea valida (no este vacia y exista), y devuelve la ruta.
string verificarRuta()
{
    string ruta= "";
    bool esValido = false;

    while(!esValido)
    {
        if (ruta == "") 
        {
            Console.WriteLine("Error: La ruta no puede ser vacia. Intente de nuevo.");
            continue;
        }

        if (Directory.Exists(ruta))
        {
            esValido = true;
        }
        else
        {
            Console.WriteLine("Error: La ruta ingresada no existe. Intente de nuevo");
        }
    }

    return ruta;
}