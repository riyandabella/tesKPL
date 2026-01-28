namespace tesKPL.Models
{
    public class Buku
    {
        public string judul { get; set; }
        public string penulis { get; set; }
        public string tahunTerbit { get; set; }
        public int tersedia { get; set; }

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
