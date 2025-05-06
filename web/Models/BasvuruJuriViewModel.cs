namespace dto.viewmodels
{
    public class BasvuruJuriViewModel
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string IlanBaslik { get; set; }
		public int BasvuruId { get; set; } // ✅ Eklenen kısım

		public string? DosyaYolu { get; set; }
	}
}
