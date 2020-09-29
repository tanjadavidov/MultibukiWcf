using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data01;

namespace MultibukiWcf.WcfMultibuki
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwcfMultibuki" in both code and config file together.
    [ServiceContract]
    public interface IwcfMultibuki
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        dsIzlaz KorisnikPrijava(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz KorisnikUnos(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz VratiTipPosPar();


        [OperationContract]
        dsIzlaz VratiTipServisa();

        [OperationContract]
        dsIzlaz VratiFirmaKorisnik();

        [OperationContract]
        dsIzlaz VratiFunkcijuZaKorisnika(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz KorisnikPravoNaFunkciju(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz KorisnikPromenaPodataka(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz VratiSliku(int IDKorisnik);

        [OperationContract]
        dsIzlaz ObrisiSliku(int IDKorisnik);

        [OperationContract]
        dsIzlaz PromenaSlike(int IDKorisnik, byte[] Slika);


        [OperationContract]
        dsIzlaz GetTreeViewItems(int IDKorisnik);


        [OperationContract]
        dsIzlaz VratiVestDetaljno();


        [OperationContract]
        dsIzlaz VratiSelectZaIDVest(int idVest);


        [OperationContract]
        dsIzlaz VratiKorisniLinkDetaljno();


        [OperationContract]
        dsIzlaz VratiUlogu();

        [OperationContract]
        dsIzlaz VratiKorisnika(string KorisnickoIme);

        [OperationContract]
        dsIzlaz PromenaPravaKorisnika(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz RestartLozinke(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz FirmaKorisnikPrikazi(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz VratiPoslovniPartner(int TipPosPar, int? idPosPar, string Search);

        [OperationContract]
        dsIzlaz VratiMesto();

        [OperationContract]
        dsIzlaz PoslovniPartnerPromenaPodataka(dsUlaz ulaz);

        [OperationContract]
        dsIzlaz VratiSprat();

        [OperationContract]
        dsIzlaz VratiArtikal(int idTip, int? id, string Search);
    }

}
