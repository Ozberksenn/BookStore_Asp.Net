using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // döküğmanda açıkla , “Bu Id alanı için ben elle bir değer vermeyeceğim. Veritabanı her yeni kayıt oluşturulduğunda otomatik olarak bir sayı atsın.” 
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

    }
}