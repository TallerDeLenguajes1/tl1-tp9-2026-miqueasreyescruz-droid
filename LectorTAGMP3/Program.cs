// ===========================
//         ESPACIOS
// ===========================

using InfoCancion;

// ===========================
//           MAIN   
// ===========================

Console.WriteLine("============================");
Console.WriteLine("  LECTOR DE ARCHIVOS ID3v1  ");
Console.WriteLine("============================");

string ruta = verificarRuta();



// ===========================
//         FUNCIONES
// ===========================

/// Usamos la misma funcion, pero con una modificacion para tambien verificar la extencion del archivo
string verificarRuta()
{
    string path= "";
    string extension = "";
    bool esValido = false;

    while(!esValido)
    {
        Console.Write("-> Ingrese la ruta del archivo: ");
        path = Console.ReadLine(); 

        if (path == "") 
        {
            Console.WriteLine("Error: La ruta no puede ser vacia. Intente de nuevo.\n");
            continue;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("Error: La ruta ingresada no existe. Intente de nuevo.\n");
            continue;
        }

        extension = Path.GetExtension(path);
        if (extencion.ToLower() == ".mp3")
        {
            esValido = true;
        }
        else
        {
            Console.WriteLine("Error: El archivo debe ser formato \".mp3\" . Intente de nuevo.\n");
        }
    }

    return path;
}