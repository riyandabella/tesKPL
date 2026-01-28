namespace tesKPL.Models
{
    public class Buku
    {
        public int id { get; set; }
        public string judul { get; set; }
        public string penulis { get; set; }
        public string tahunTerbit { get; set; }
        public int tersedia { get; set; }

        public Buku()
        {
            
        }

        public Buku(int id, string judul, string penulis, string tahunTerbit, int tersedia)
        {
            this.id = id;
            this.judul = judul;
            this.penulis = penulis;
            this.tahunTerbit = tahunTerbit;
            this.tersedia = tersedia;
        }
    }
}
