using System.Collections.Generic;

namespace Markit.Models {
    public class Companys : List<Company> {
        public Companys() {
        }

        public Companys(IEnumerable<Company> collection)
            : base(collection) {
        }
    }
}
