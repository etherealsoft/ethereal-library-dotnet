using System.ComponentModel.DataAnnotations;

namespace Ethereal.Library.Test
{
    public class TestModel
    {
        [Required]
        [Range(0, 1)]
        public int? RequiredProperty { get; set; }
    }
}
