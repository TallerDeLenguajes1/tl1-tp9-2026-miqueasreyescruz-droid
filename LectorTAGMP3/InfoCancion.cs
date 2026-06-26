namespace InfoCancion;

public class Id3v1Tag
{
    private string _titulo;
    private string _artista;
    private string _album;
    private string _fechapublicacion;

    public string Titulo { get => _titulo; }
    public string Artista { get => _artista; }
    public string Album { get => _album; }
    public string Fechapublicacion { get => _fechapublicacion; }

    public Id3v1Tag (string _titulo, string _artista, string _album, string _fechapublicacion)
    {
        this._titulo = _titulo;
        this._artista = _artista;
        this._album = _album;
        this._fechapublicacion = _fechapublicacion;
    }
}