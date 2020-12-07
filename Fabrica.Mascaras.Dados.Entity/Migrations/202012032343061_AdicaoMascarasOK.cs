namespace Fabrica.Mascaras.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoMascarasOK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mascara",
                c => new
                    {
                        IdMascara = c.Long(nullable: false, identity: true),
                        NomeMascara = c.String(nullable: false, maxLength: 100),
                        Cor = c.String(nullable: false, maxLength: 50),
                        Tamanho = c.String(nullable: false, maxLength: 50),
                        IdTecido = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMascara)
                .ForeignKey("dbo.Tecido", t => t.IdTecido, cascadeDelete: true)
                .Index(t => t.IdTecido);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mascara", "IdTecido", "dbo.Tecido");
            DropIndex("dbo.Mascara", new[] { "IdTecido" });
            DropTable("dbo.Mascara");
        }
    }
}
