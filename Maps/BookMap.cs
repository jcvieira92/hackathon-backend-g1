using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using hackathon_backdotnet_g1.Models;

namespace hackathon_backdotnet_g1.Maps
{
    public class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BookId);

            entityBuilder.Property(x => x.BookName).HasColumnName("book_name");
        }
    }
}