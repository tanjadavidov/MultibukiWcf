using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using Data01;

namespace MultibukiWcf.WcfMultibuki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcfMultibuki" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcfMultibuki.svc or wcfMultibuki.svc.cs at the Solution Explorer and start debugging.
    public class wcfMultibuki : IwcfMultibuki
    {
        private SqlConnection konekcija = null;
        public void DoWork()
        {
        }

        public wcfMultibuki()
        {

            ExceptionLogger.ExceptionLogger.initialisation("Multibuki", "Multibuki servis");
            TraceLogging.TraceLogger.initialisation("Multibuki", "Multibuki servis");

            try
            {
                konekcija = new SqlConnection(WebConfigurationManager.ConnectionStrings["MultiBukiConnectionString"].ConnectionString);


            }
            catch (Exception exc)
            {
                exc.Message.ToString();

                ExceptionLogger.ExceptionLogger.logError(exc, this.GetType()
                , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name, this);
            }
        }

        #region aaa definition  


        public dsIzlaz KorisnikPrijava(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtKorisnikPrijavaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtKorisnikPrijavaTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillKorisnikPrijava(izlaz.dtKorisnikPrijava, dbUlaz.aaaType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.KorisnikPrijava! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.KorisnikPrijava! " + exc.Message);
            }

            return izlaz;
        }



        public dsIzlaz KorisnikUnos(dsUlaz ulaz)

        {
            TraceLogging.TraceLogger.trace(this.GetType()
                   , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                   , this, "");

            Data01.dsIzlazTableAdapters.dtKorisnikUnosTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtKorisnikUnosTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillKorisnikUnos(izlaz.dtKorisnikUnos, dbUlaz.aaaType);

            }

            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                   sqlException
                   , this.GetType()
                   , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                   , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.KorisnikUnos! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                   exc
                   , this.GetType()
                   , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                   , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.KorisnikUnos! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiFunkcijuZaKorisnika(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtVratiFunkcijuZaKorisnikaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiFunkcijuZaKorisnikaTableAdapter();
            adapter.Connection = konekcija;


            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillVratiFunkcijuZaKorisnika(izlaz.dtVratiFunkcijuZaKorisnika, dbUlaz.aaaType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.VratiFunkcijuZaKorisnika! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.VratiFunkcijuZaKorisnika! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz KorisnikPravoNaFunkciju(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtKorisnikPravoNaFunkcijuTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtKorisnikPravoNaFunkcijuTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillKorisnikPravoNaFunkciju(izlaz.dtKorisnikPravoNaFunkciju, dbUlaz.aaaType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.KorisnikPravoNaFunkciju! " + sqlException.Message);

            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.KorisnikPravoNaFunkciju! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz KorisnikPromenaPodataka(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtKorisnikPromenaPodatakaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtKorisnikPromenaPodatakaTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillKorisnikPromenaPodataka(izlaz.dtKorisnikPromenaPodataka, dbUlaz.aaaType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.KorisnikPromenaPodataka! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.KorisnikPromenaPodataka! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiUlogu()

        {

            Data01.dsIzlazTableAdapters.dtVratiUloguTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiUloguTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiUlogu(izlaz.dtVratiUlogu);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiUlogu! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiUlogu! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz VratiKorisnika(string KorisnickoIme)
        {

            Data01.dsIzlazTableAdapters.dtVratiKorisnikaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiKorisnikaTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiKorisnika(izlaz.dtVratiKorisnika, KorisnickoIme);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.VratiKorisnika! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.VratiKorisnika! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz PromenaPravaKorisnika(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtPromenaPravaKorisnikaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtPromenaPravaKorisnikaTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillPromenaPravaKorisnika(izlaz.dtPromenaPravaKorisnika, dbUlaz.aaaType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.PromenaPravaKorisnika! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.PromenaPravaKorisnika! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz RestartLozinke(dsUlaz ulaz)
        {

            Data01.dsIzlazTableAdapters.dtRestartLozinkeTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtRestartLozinkeTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();        

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtaaa, dbUlaz.aaaType);

            try
            {
                adapter.FillRestartLozinke(izlaz.dtRestartLozinke, dbUlaz.aaaType);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri aaa.RestartLozinke! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode aaa.RestartLozinke! " + exc.Message);
            }

            return izlaz;
        }

        #endregion


        #region dbo definition  

        public dsIzlaz VratiTipPosPar()
        {

            Data01.dsIzlazTableAdapters.dtVratiTipPosParTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiTipPosParTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiTipPosPar(izlaz.dtVratiTipPosPar);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiTipPosPar! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiTipPosPar! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiTipServisa()
        {

            Data01.dsIzlazTableAdapters.dtVratiTipServisaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiTipServisaTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiTipServisa(izlaz.dtVratiTipServisa);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiTipServisa! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiTipServisa! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz VratiFirmaKorisnik()
        {

            Data01.dsIzlazTableAdapters.dtVratiFirmaKorisnikTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiFirmaKorisnikTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiFirmaKorisnik(izlaz.dtVratiFirmaKorisnik);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiFirmaKorisnik! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiFirmaKorisnik! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiSliku(int IDKorisnik)
        {
            Data01.dsIzlazTableAdapters.dtVratiSlikuTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiSlikuTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiSliku(izlaz.dtVratiSliku, IDKorisnik);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiSliku! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiSliku! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz ObrisiSliku(int IDKorisnik)
        {
            Data01.dsIzlazTableAdapters.dtObrisiSlikuTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtObrisiSlikuTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillObrisiSliku(izlaz.dtObrisiSliku, IDKorisnik);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri ObrisiSliku! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiSliku! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz PromenaSlike(int IDKorisnik, byte[] Slika)
        {
            Data01.dsIzlazTableAdapters.dtPromenaSlikeTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtPromenaSlikeTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillPromenaSlike(izlaz.dtPromenaSlike, IDKorisnik, Slika);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri PromenaSlike! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiSliku! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz GetTreeViewItems(int IDKorisnik)
        {

            Data01.dsIzlazTableAdapters.dtGetTreeViewItemsTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtGetTreeViewItemsTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillGetTreeViewItems(izlaz.dtGetTreeViewItems, IDKorisnik);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri GetTreeViewItems! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode GetTreeViewItems! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiVestDetaljno()
        {
            Data01.dsIzlazTableAdapters.dtVratiVestDetaljnoTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiVestDetaljnoTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiVestDetaljno(izlaz.dtVratiVestDetaljno);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri dtVratiVestDetaljno! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode dtVratiVestDetaljno! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz VratiSelectZaIDVest(int idVest)
        {
            Data01.dsIzlazTableAdapters.dtVratiSelectZaIDVestTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiSelectZaIDVestTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiSelectZaIDVest(izlaz.dtVratiSelectZaIDVest, idVest);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri dtVratiSelectZaIDVest! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode dtVratiSelectZaIDVest! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiKorisniLinkDetaljno()
        {
            Data01.dsIzlazTableAdapters.dtVratiKorisniLinkDetaljnoTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiKorisniLinkDetaljnoTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiKorisniLinkDetaljno(izlaz.dtVratiKorisniLinkDetaljno);
            }

            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiKorisniLinkDetaljno! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiKorisniLinkDetaljno! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz FirmaKorisnikPrikazi(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtFirmaKorisnikPrikaziTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtFirmaKorisnikPrikaziTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtdbo, dbUlaz.dboType);

            try
            {
                adapter.FillFirmaKorisnikPrikazi(izlaz.dtFirmaKorisnikPrikazi, dbUlaz.dboType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri dbo.FirmaKorisnikPrikazi! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode dbo.FirmaKorisnikPrikazi! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiPoslovniPartner(int TipPosPar, int? idPosPar, string Search)
        {

            Data01.dsIzlazTableAdapters.dtVratiPoslovniPartnerTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiPoslovniPartnerTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiPoslovniPartner(izlaz.dtVratiPoslovniPartner, TipPosPar, idPosPar, Search);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiPoslovniPartner! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiPoslovniPartner! " + exc.Message);
            }

            return izlaz;
        }

        public dsIzlaz VratiMesto()
        {

            Data01.dsIzlazTableAdapters.dtVratiMestoTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiMestoTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiMesto(izlaz.dtVratiMesto);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiMesto! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiMesto! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz PoslovniPartnerPromenaPodataka(dsUlaz ulaz)
        {
            TraceLogging.TraceLogger.trace(this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this, "");

            Data01.dsIzlazTableAdapters.dtPoslovniPartnerPromenaPodatakaTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtPoslovniPartnerPromenaPodatakaTableAdapter();
            adapter.Connection = konekcija;

            dsIzlaz izlaz = new dsIzlaz();

            dsSqlUlaz dbUlaz = new dsSqlUlaz();
            Translator.Translator.translateTable(ulaz.dtdbo, dbUlaz.dboType);

            try
            {
                adapter.FillPoslovniPartnerPromenaPodataka(izlaz.dtPoslovniPartnerPromenaPodataka, dbUlaz.dboType);
            }
            catch (SqlException sqlException)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    sqlException
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri PoslovniPartnerPromenaPodataka! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                ExceptionLogger.ExceptionLogger.logError(
                    exc
                    , this.GetType()
                    , (new System.Diagnostics.StackTrace(true)).GetFrame(0).GetMethod().Name
                    , this);
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode dbo.PoslovniPartnerPromenaPodataka! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiSprat()
        {

            Data01.dsIzlazTableAdapters.dtVratiSpratTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiSpratTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiSprat(izlaz.dtVratiSprat);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiSprat! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiSprat! " + exc.Message);
            }

            return izlaz;
        }


        public dsIzlaz VratiArtikal(int idTip, int? id, string Search)
        {

            Data01.dsIzlazTableAdapters.dtVratiArtikalTableAdapter adapter = new Data01.dsIzlazTableAdapters.dtVratiArtikalTableAdapter();
            adapter.Connection = konekcija;



            dsIzlaz izlaz = new dsIzlaz();

            try
            {
                adapter.FillVratiArtikal(izlaz.dtVratiArtikal, idTip, id, Search);

            }

            catch (SqlException sqlException)
            {

                if (sqlException.Message.StartsWith("Usr:"))
                    izlaz.dtGreska.Rows.Add(sqlException.Message.Substring(4));
                else
                    izlaz.dtGreska.Rows.Add("Greška prilikom vraćanja podataka iz baze u proceduri VratiArtikal! " + sqlException.Message);
            }
            catch (Exception exc)
            {
                izlaz.dtGreska.Rows.Add("Greška u servisu kod metode VratiArtikal! " + exc.Message);
            }

            return izlaz;
        }


        #endregion
    }
}
