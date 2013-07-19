
namespace Markit.Models {
    public class Company {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }

        public override string ToString() {
            return (new { Symbol, Name, Exchange }).ToString();
        }
    }
}
