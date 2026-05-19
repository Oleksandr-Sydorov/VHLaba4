using Microsoft.EntityFrameworkCore;
using Laba4.Models;

namespace Laba4.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}