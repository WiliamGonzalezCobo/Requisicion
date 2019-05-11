using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using MODELO_DATOS;
using System.Data.Entity.SqlServer;


namespace REPOSITORIOS
{
    public class CONTEXTO : DbContext
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;

        public CONTEXTO()
            : base("name=CONTEXTO")
        {
        }


		public CONTEXTO(string CADENA_CONEXION)
			: base(CADENA_CONEXION)
		{
		}

		public virtual DbSet<MODIFICACIONES> MODIFICACIONES { get; set; }
        public virtual DbSet<CORREOS> CORREOS { get; set; }
        public virtual DbSet<CORREOS_DESTINOS> CORREOS_DESTINOS { get; set; }
        public virtual DbSet<PLANTILLAS_CORREOS> PLANTILLAS_CORREOS { get; set; }
        public virtual DbSet<TIPOS_CORREOS> TIPOS_CORREOS { get; set; }
        public virtual DbSet<CAUSA_RETIROS_TIPO_SOPORTES> CAUSA_RETIROS_TIPO_SOPORTES { get; set; }
        public virtual DbSet<TIPO_SOPORTES> TIPO_SOPORTES { get; set; }
        public virtual DbSet<ESTADOS> ESTADOS { get; set; }
        public virtual DbSet<RETIROS> RETIROS { get; set; }
        public virtual DbSet<SOPORTES> SOPORTES { get; set; }
        public virtual DbSet<DEPURARCION> DEPURARCION { get; set; }
        public virtual DbSet<ERRORES> ERRORES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MODIFICACIONES>()
                .Property(e => e.COD_AUDITORIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MODIFICACIONES>()
                .Property(e => e.COD_TABLA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS>()
                .Property(e => e.COD_CORREO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS>()
                .Property(e => e.COD_TIPO_CORREO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<CORREOS>()
                .Property(e => e.PUERTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS>()
                .HasMany(e => e.CORREOS_DESTINOS)
                .WithRequired(e => e.CORREOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CORREOS>()
                .HasMany(e => e.PLANTILLAS_CORREOS)
                .WithRequired(e => e.CORREOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CORREOS_DESTINOS>()
                .Property(e => e.COD_CORREO_DESTINO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS_DESTINOS>()
                .Property(e => e.COD_CORREO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CORREOS_DESTINOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<PLANTILLAS_CORREOS>()
                .Property(e => e.COD_PLANTILLA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PLANTILLAS_CORREOS>()
                .Property(e => e.COD_CORREO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PLANTILLAS_CORREOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<TIPOS_CORREOS>()
                .Property(e => e.COD_TIPO_CORREO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TIPOS_CORREOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<TIPOS_CORREOS>()
                .HasMany(e => e.CORREOS)
                .WithRequired(e => e.TIPOS_CORREOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUSA_RETIROS_TIPO_SOPORTES>()
                .Property(e => e.COD_CAUSA_RETIRO_TIPO_SOPORTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CAUSA_RETIROS_TIPO_SOPORTES>()
                .Property(e => e.COD_CAUSA_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CAUSA_RETIROS_TIPO_SOPORTES>()
                .Property(e => e.COD_TIPO_SOPORTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CAUSA_RETIROS_TIPO_SOPORTES>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<TIPO_SOPORTES>()
                .Property(e => e.COD_TIPO_SOPORTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TIPO_SOPORTES>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<TIPO_SOPORTES>()
                .HasMany(e => e.CAUSA_RETIROS_TIPO_SOPORTES)
                .WithRequired(e => e.TIPO_SOPORTES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPO_SOPORTES>()
                .HasMany(e => e.SOPORTES)
                .WithRequired(e => e.TIPO_SOPORTES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ESTADOS>()
                .Property(e => e.COD_ESTADO_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ESTADOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ESTADOS>()
                .HasMany(e => e.RETIROS)
                .WithRequired(e => e.ESTADOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RETIROS>()
                .Property(e => e.COD_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RETIROS>()
                .Property(e => e.COD_CARGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RETIROS>()
                .Property(e => e.COD_CAUSA_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RETIROS>()
                .Property(e => e.COD_ESTADO_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RETIROS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<RETIROS>()
                .HasMany(e => e.SOPORTES)
                .WithRequired(e => e.RETIROS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOPORTES>()
                .Property(e => e.COD_SOPORTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SOPORTES>()
                .Property(e => e.COD_RETIRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SOPORTES>()
                .Property(e => e.COD_TIPO_SOPORTE)
                .HasPrecision(18, 0);

			modelBuilder.Entity<SOPORTES>()
				.Property(e => e.ESTADO)
				.HasPrecision(1, 0);

            modelBuilder.Entity<DEPURARCION>()
                .Property(e => e.NOMBRE_CLASE)
                .IsUnicode(false);

			modelBuilder.Entity<DEPURARCION>()
				.Property(e => e.NOMBRE_METODO)
				.IsUnicode(false);

			modelBuilder.Entity<DEPURARCION>()
				.Property(e => e.CODIGO_ERROR)
				.IsUnicode(false);

			modelBuilder.Entity<DEPURARCION>()
				.Property(e => e.DETALLE)
				.IsUnicode(false);

            modelBuilder.Entity<ERRORES>()
                .Property(e => e.NOMBRE_CLASE)
                .IsUnicode(false);

			modelBuilder.Entity<ERRORES>()
				.Property(e => e.NOMBRE_METODO)
				.IsUnicode(false);

			modelBuilder.Entity<ERRORES>()
				.Property(e => e.CODIGO_ERROR)
				.IsUnicode(false);

			modelBuilder.Entity<ERRORES>()
				.Property(e => e.DETALLE)
				.IsUnicode(false);

			//ESTO HAY QUE AGREGARLO SIEMPRE 
			modelBuilder.Configurations.Add(new MAPEOS.MAPEOS_RETIROS());
            modelBuilder.Configurations.Add(new MAPEOS.MAPEOS_SOPORTES());
            modelBuilder.Configurations.Add(new MAPEOS.MAPEO_ERRORES());
            modelBuilder.Configurations.Add(new MAPEOS.MAPEO_DEPURACION());
            modelBuilder.Configurations.Add(new MAPEOS.MAPEOS_CORREOS());
        }
        
    }
}
