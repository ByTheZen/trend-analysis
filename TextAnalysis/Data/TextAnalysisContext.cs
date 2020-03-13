using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalysis.Models;

namespace TextAnalysis.Data
{
    public class TextAnalysisContext : DbContext
    {
        public TextAnalysisContext(DbContextOptions<TextAnalysisContext> options)
        : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }
    }
}
