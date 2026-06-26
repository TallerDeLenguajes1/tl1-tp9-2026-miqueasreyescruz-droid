// ///////////////////////////
//           MAIN
// ///////////////////////////

string ruta = verificarRuta();

listarContenido(ruta);

crearReporteFile(ruta);
crearReporteStream(ruta);

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
        Console.Write("-> Ingrese la ruta del directorio a analizar: ");
        path = Console.ReadLine(); 

        if (path == "") 
        {
            Console.WriteLine("Error: La ruta no puede ser vacia. Intente de nuevo.\n");
            continue;
        }

        if (Directory.Exists(path))
        {
            esValido = true;
        }
        else
        {
            Console.WriteLine("Error: La ruta ingresada no existe. Intente de nuevo.\n");
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
    
    // Creo una nueva instancia para cada archivo (info), y con la propiedad Lenght obtengo su tamaño
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

// Recibe una ruta, y crea en dicha ruta un archivo reporte_archivos_file.csv  
// Uso el objeto File
void crearReporteFile(string path)
{
    string rutaFinal = Path.Combine(path,"reporte_archivo_file.csv"); // Creo la ruta donde se creara el archivo
    List<string> lineas = new List<string> ();  // Creo una lista, donde guardare las lineas que tendra el arhivo
    FileInfo info;

    // Agrego la cabacera 
    lineas.Add("Nombre del Archivo;Tamaño (KB);Ultima Modificacion");

    // Para cada archivo, agrego una linea
    foreach(var archivo in Directory.GetFiles(path))
    {
        info = new(archivo);
        lineas.Add($"{info.Name};{info.Length / 1024.0:F2} KB;{info.LastWriteTime}");
    }

    File.WriteAllLines(rutaFinal, lineas);
}

// Recibe una ruta, y crea en dicha ruta un archivo reporte_archivos_stream.csv  
// Usa la clase Stream
void crearReporteStream(string path)
{
    string rutaFinal = Path.Combine(path,"reporte_archivo_stream.csv");
    using StreamWriter escritor = new StreamWriter(rutaFinal);
    FileInfo info;

    escritor.WriteLine("Nombre del Archivo;Tamaño (KB);Ultima Modificacion");

    foreach(var archivo in Directory.GetFiles(path))
    {
        info = new(archivo);
        escritor.WriteLine($"{info.Name};{info.Length / 1024.0:F2} KB;{info.LastWriteTime}");
    }
}