using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mostaan.Model
{

    class Context : DbContext
    {
        public Context() : base("mostaan")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<archive> Archives { get; set; }
        public DbSet<shenasname> shenasnames { get; set; }
        public DbSet<shenasnameGam> shenasnameGams { get; set; }
        public DbSet<shenasnameFounder> shenasnameFounders { get; set; }
        public DbSet<ejraeiat> ejraeiats { get; set; }
        public DbSet<sarmaye> sarmayes { get; set; }
        public DbSet<masrafi> masrafis { get; set; }
        public DbSet<edari> edaris { get; set; }
        public DbSet<omrani>  omranis { get; set; }
        public DbSet<gharardad>  gharardads { get; set; }
        public DbSet<sayer> sayers { get; set; }
        public DbSet<tashvighi> tashvighis { get; set; }
        

    }

    class ejraeiat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string  title { get; set; }
        public int dollaryP { get; set; }
        public int riallyP { get; set; }
        public int dollaryN { get; set; }
        public int riallyN { get; set; }
        public int shenasnameID { get; set; }

    }
    class sarmaye
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public string creatoreCo { get; set; }
        public int count { get; set; }
        public int vahedPR { get; set; }
        public int kollPR { get; set; }
        public int vahedPD { get; set; }
        public int kollPD { get; set; }
        public int vahedNR { get; set; }
        public int vahedND { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }
        

    }
    class gharardad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public int level { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }

    }
    class tashvighi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int shenasnameID { get; set; }
    }
    class sayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }

    }
    class omrani
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public int zirbana { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }

    }
    class edari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }

    }
    class masrafi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
        public string creatoreCo { get; set; }
        public int count { get; set; }
        public int vahedPR { get; set; }
        public int vahedPD { get; set; }
        public int kollPR { get; set; }
        public int kollPD { get; set; }
        public int vahedNR { get; set; }
        public int vahedND { get; set; }
        public int kollNR { get; set; }
        public int kollND { get; set; }
        public int shenasnameID { get; set; }


    }
    class archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "موضوع")]
        public string subject { get; set; }
        public string productType { get; set; }
        public string rank { get; set; }
        public string markaz { get; set; }
        public string project { get; set; }
        public string sanadType { get; set; }
        public string karfarma { get; set; }
        public string tarikh { get; set; }
        public string shomareSanad { get; set; }
        public string variz { get; set; }
        public string mablagh { get; set; }
        public string hesab { get; set; }

    }
    
    class shenasname
    {
        public int ID { get; set; }
        public bool isDone { get; set; }
        public string title { get; set; }
        public string hadaf { get; set; }
        public string dastgah { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public DateTime date {get; set;}
        public string token { get; set; }
        public string markaz { get; set; }
        public int final { get; set; }
        public int DrasmiT { get; set; }
        public int DrasmiHPR { get; set; }
        public int DrasmiHPD { get; set; }
        public int DgharartamamT { get; set; }
        public int DgharartamamHPR { get; set; }
        public int DgharartamamHPD { get; set; }
        public int DghararsaatT { get; set; }
        public int DghararsaatHPR { get; set; }
        public int DghararsaatHPD { get; set; }
        public int DvazifeT { get; set; }
        public int DvazifeHPR { get; set; }
        public int DvazifeHPD { get; set; }


        public int FLrasmiT { get; set; }
        public int FLrasmiHPR { get; set; }
        public int FLrasmiHPD { get; set; }
        public int FLgharartamamT { get; set; }
        public int FLgharartamamHPR { get; set; }
        public int FLgharartamamHPD { get; set; }
        public int FLghararsaatT { get; set; }
        public int FLghararsaatHPR { get; set; }
        public int FLghararsaatHPD { get; set; }
        public int FLvazifeT { get; set; }
        public int FLvazifeHPR { get; set; }
        public int FLvazifeHPD { get; set; }

        public int LrasmiT { get; set; }
        public int LrasmiHPR { get; set; }
        public int LrasmiHPD { get; set; }
        public int LgharartamamT { get; set; }
        public int LgharartamamHPR { get; set; }
        public int LgharartamamHPD { get; set; }
        public int LghararsaatT { get; set; }
        public int LghararsaatHPR { get; set; }
        public int LghararsaatHPD { get; set; }
        public int LvazifeT { get; set; }
        public int LvazifeHPR { get; set; }
        public int LvazifeHPD { get; set; }


        public int FDrasmiT { get; set; }
        public int FDrasmiHPR { get; set; }
        public int FDrasmiHPD { get; set; }
        public int FDgharartamamT { get; set; }
        public int FDgharartamamHPR { get; set; }
        public int FDgharartamamHPD { get; set; }
        public int FDghararsaatT { get; set; }
        public int FDghararsaatHPR { get; set; }
        public int FDghararsaatHPD { get; set; }
        public int FDvazifeT { get; set; }
        public int FDvazifeHPR { get; set; }
        public int FDvazifeHPD { get; set; }

        public int DirasmiT { get; set; }
        public int DirasmiHPR { get; set; }
        public int DirasmiHPD { get; set; }
        public int DigharartamamT { get; set; }
        public int DigharartamamHPR { get; set; }
        public int DigharartamamHPD { get; set; }
        public int DighararsaatT { get; set; }
        public int DighararsaatHPR { get; set; }
        public int DighararsaatHPD { get; set; }
        public int DivazifeT { get; set; }
        public int DivazifeHPR { get; set; }
        public int DivazifeHPD { get; set; }

        public int ZDirasmiT { get; set; }
        public int ZDirasmiHPR { get; set; }
        public int ZDirasmiHPD { get; set; }
        public int ZDigharartamamT { get; set; }
        public int ZDigharartamamHPR { get; set; }
        public int ZDigharartamamHPD { get; set; }
        public int ZDighararsaatT { get; set; }
        public int ZDighararsaatHPR { get; set; }
        public int ZDighararsaatHPD { get; set; }
        public int ZDivazifeT { get; set; }
        public int ZDivazifeHPR { get; set; }
        public int ZDivazifeHPD { get; set; }
        public virtual List<shenasnameGam> gamList  { get; set; }
        public virtual List<shenasnameFounder> founderList { get; set; }
        public virtual List<ejraeiat> ejraeitList { get; set; }
        public virtual List<sarmaye> Sarmayes { get; set; }
        public virtual List<masrafi> Masrafis { get; set; }
        


    }

    class markaz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string title { get; set; }
      
    }

    class markaz_shenasname
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int markazID { get; set; }
        public int shenasnameID { get; set; }
    }
    class shenasnameGam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string gamAsli { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public  string duration { get; set; }
        public int darsadeVazni { get; set; }
        public string achivement { get; set; }
        public int  shenasnameID { get; set; }
    }

    class shenasnameFounder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string fullname { get; set; }
        public string semat { get; set; }
        public int shenasnameID { get; set; }

    }

    
}
