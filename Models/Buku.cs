namespace tesKPL.Models
{
    public class Buku
    {
        public string judul;
        public string penulis;
        public string tahunTerbit;
        public int tersedia;

        public Buku()
        {
            
        }

        public Buku(string judul, string penulis, string tahunTerbit, int tersedia)
        {
            this.judul = judul;
            this.penulis = penulis;
            this.tahunTerbit = tahunTerbit;
            this.tersedia = tersedia;
        }
    }
}
