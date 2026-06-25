// ///////////////////////////
//           MAIN
// ///////////////////////////

/* Ruta de Testeo: C:\Users\DELL\Documents\FACET */
string ruta = verificarRuta();

listarContenido(ruta);

// //////////////////////////
//        FUNCIONES
// //////////////////////////

/// Solicita al usuario una ruta de directorio y valida que exista
string verificarRuta()
{
    string path= "";
    bool esValido = false;

    while(!esValido)
    {
        Console.Write("Ingrese la ruta del directorio a analizar: ");
        path = Console.ReadLine(); 

        if (path == "") 
        {
            Console.WriteLine("Error: La ruta no puede ser vacia. Intente de nuevo.");
            continue;
        }

        if (Directory.Exists(path))
        {
            esValido = true;
        }
        else
        {
            Console.WriteLine("Error: La ruta ingresada no existe. Intente de nuevo");
        }
    }

    return path;
}

/// Recibe una ruta y lista tanto carpetas como archivos ubicados en dicha ruta
void listarContenido(string path)
{
    string[] carpetas = Directory.GetDirectories(path);
    string[] archivos = Directory.GetFiles(path);
    FileInfo info;
    double tamañoKB;

    Console.WriteLine("===============================================");
    Console.WriteLine($" ANALIZANDO: {path}");
    Console.WriteLine("===============================================\n");

    Console.WriteLine("CARPETAS ENCONTRADAS:");
    foreach(string carpeta in carpetas)
    {
        Console.WriteLine($"- {Path.GetFileName(carpeta)}");
    }
    Console.WriteLine("");
    
    // Creo una nueva instancia para cada archivo, y con la propiedad Lenght obtengo su tamaño
    // Divido en 1024.0 para obtener un resulta decimal y su valor en KB (originalmente en Bytes)
    Console.WriteLine("ARCHIVOS ENCONTRADOS:");
    foreach(string archivo in archivos)
    {
        info = new(archivo);
        tamañoKB = info.Length / 1024.0;
        Console.WriteLine($"- {info.Name} | {tamañoKB:F2} KB");
    }
    Console.WriteLine("");

    Console.WriteLine("===============================================\n");
}