namespace ScriptureMemorization
{
    public class Reference
    {
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verses { get; set; }
        public Reference(string book, string chapter, string verses)
        {
            Book = book;
            Chapter = chapter;
            Verses = verses;
        }
        public override string ToString()
        {
            return $"{Book} {Chapter}:{Verses}";
        }
    }
}
