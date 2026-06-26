// ===========================
//         ESPACIOS
// ===========================

using System.Text;
using InfoCancion;

// ===========================
//           MAIN   
// ===========================

Console.WriteLine("============================");
Console.WriteLine("  LECTOR DE ARCHIVOS ID3v1  ");
Console.WriteLine("============================");

string ruta = verificarRuta();

Id3v1Tag Cancion = extraerTAG(ruta);

if (Cancion != null)
{
    Console.WriteLine("\n=== INFORMACIÓN DE LA CANCIÓN ===");
    Console.WriteLine($"Título:  {Cancion.Titulo}");
    Console.WriteLine($"Artista: {Cancion.Artista}");
    Console.WriteLine($"Álbum:   {Cancion.Album}");
    Console.WriteLine($"Año:     {Cancion.Anio}");
    Console.WriteLine("=================================");
}
else
{
    Console.WriteLine("\nError: no se pudo extraer el TAG");
}

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
        if (extension.ToLower() == ".mp3")
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

Id3v1Tag extraerTAG(string path)
{
    FileStream fs = new FileStream(path, FileMode.Open);
    
    // Me ubico en el final del archivo, y regreso 128 bytes
    fs.Seek(-128, SeekOrigin.End);

    // Creo el buffer donde guardar los 128 bytes
    byte[] buffer = new byte[128];

    // Leo los ultimos 128 bytes, los guardo en el buffer y cierro el archivo
    int leidos = fs.Read(buffer, 0, 128);
    fs.Close();

    // Verifico que realmente haya leido 128 bytes
    if (leidos != 128)
    {
        return null;
    }

    string header = Encoding.GetEncoding("latin1").GetString(buffer,0,3).Trim('\0', ' ');

    // Verifico que el archivo sea TAG
    if (header != "TAG")
    {
        return null;
    }

    string titulo = Encoding.GetEncoding("latin1").GetString(buffer,3,30).Trim('\0', ' ');
    string artista = Encoding.GetEncoding("latin1").GetString(buffer,33,30).Trim('\0', ' ');
    string album = Encoding.GetEncoding("latin1").GetString(buffer,63,30).Trim('\0', ' ');
    string anio = Encoding.GetEncoding("latin1").GetString(buffer,93,4).Trim('\0', ' ');

    return new Id3v1Tag(titulo,artista,album,anio);
}