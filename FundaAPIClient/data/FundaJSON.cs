// FundaJSON myDeserializedClass = JsonConvert.DeserializeObject<FundaJSON>(myJsonResponse); 
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FundaAPIClient
{
    public class Metadata
    {
        [JsonProperty("ObjectType")]
        public string ObjectType { get; set; }

        [JsonProperty("Omschrijving")]
        public string Omschrijving { get; set; }

        [JsonProperty("Titel")]
        public string Titel { get; set; }
    }

    public class Prijs
    {
        [JsonProperty("GeenExtraKosten")]
        public bool? GeenExtraKosten { get; set; }

        [JsonProperty("HuurAbbreviation")]
        public string HuurAbbreviation { get; set; }

        [JsonProperty("Huurprijs")]
        public object Huurprijs { get; set; }

        [JsonProperty("HuurprijsOpAanvraag")]
        public string HuurprijsOpAanvraag { get; set; }

        [JsonProperty("HuurprijsTot")]
        public object HuurprijsTot { get; set; }

        [JsonProperty("KoopAbbreviation")]
        public string KoopAbbreviation { get; set; }

        [JsonProperty("Koopprijs")]
        public int? Koopprijs { get; set; }

        [JsonProperty("KoopprijsOpAanvraag")]
        public string KoopprijsOpAanvraag { get; set; }

        [JsonProperty("KoopprijsTot")]
        public int? KoopprijsTot { get; set; }

        [JsonProperty("OriginelePrijs")]
        public object OriginelePrijs { get; set; }

        [JsonProperty("VeilingText")]
        public string VeilingText { get; set; }
    }

    public class Project
    {
        [JsonProperty("AantalKamersTotEnMet")]
        public object AantalKamersTotEnMet { get; set; }

        [JsonProperty("AantalKamersVan")]
        public object AantalKamersVan { get; set; }

        [JsonProperty("AantalKavels")]
        public object AantalKavels { get; set; }

        [JsonProperty("Adres")]
        public object Adres { get; set; }

        [JsonProperty("FriendlyUrl")]
        public object FriendlyUrl { get; set; }

        [JsonProperty("GewijzigdDatum")]
        public object GewijzigdDatum { get; set; }

        [JsonProperty("GlobalId")]
        public object GlobalId { get; set; }

        [JsonProperty("HoofdFoto")]
        public string HoofdFoto { get; set; }

        [JsonProperty("IndIpix")]
        public bool? IndIpix { get; set; }

        [JsonProperty("IndPDF")]
        public bool? IndPDF { get; set; }

        [JsonProperty("IndPlattegrond")]
        public bool? IndPlattegrond { get; set; }

        [JsonProperty("IndTop")]
        public bool? IndTop { get; set; }

        [JsonProperty("IndVideo")]
        public bool? IndVideo { get; set; }

        [JsonProperty("InternalId")]
        public string InternalId { get; set; }

        [JsonProperty("MaxWoonoppervlakte")]
        public object MaxWoonoppervlakte { get; set; }

        [JsonProperty("MinWoonoppervlakte")]
        public object MinWoonoppervlakte { get; set; }

        [JsonProperty("Naam")]
        public object Naam { get; set; }

        [JsonProperty("Omschrijving")]
        public object Omschrijving { get; set; }

        [JsonProperty("OpenHuizen")]
        public List<object> OpenHuizen { get; set; }

        [JsonProperty("Plaats")]
        public object Plaats { get; set; }

        [JsonProperty("Prijs")]
        public object Prijs { get; set; }

        [JsonProperty("PrijsGeformatteerd")]
        public object PrijsGeformatteerd { get; set; }

        [JsonProperty("PublicatieDatum")]
        public object PublicatieDatum { get; set; }

        [JsonProperty("Type")]
        public int? Type { get; set; }

        [JsonProperty("Woningtypen")]
        public object Woningtypen { get; set; }
    }

    public class PromoLabel
    {
        [JsonProperty("HasPromotionLabel")]
        public bool? HasPromotionLabel { get; set; }

        [JsonProperty("PromotionPhotos")]
        public List<string> PromotionPhotos { get; set; }

        [JsonProperty("PromotionPhotosSecure")]
        public List<string> PromotionPhotosSecure { get; set; }

        [JsonProperty("PromotionType")]
        public int? PromotionType { get; set; }

        [JsonProperty("RibbonColor")]
        public int? RibbonColor { get; set; }

        [JsonProperty("RibbonText")]
        public object RibbonText { get; set; }

        [JsonProperty("Tagline")]
        public string Tagline { get; set; }
    }

    public class Object
    {
        [JsonProperty("AangebodenSindsTekst")]
        public string AangebodenSindsTekst { get; set; }

        [JsonProperty("AanmeldDatum")]
        public DateTime AanmeldDatum { get; set; }

        [JsonProperty("AantalBeschikbaar")]
        public object AantalBeschikbaar { get; set; }

        [JsonProperty("AantalKamers")]
        public int? AantalKamers { get; set; }

        [JsonProperty("AantalKavels")]
        public object AantalKavels { get; set; }

        [JsonProperty("Aanvaarding")]
        public string Aanvaarding { get; set; }

        [JsonProperty("Adres")]
        public string Adres { get; set; }

        [JsonProperty("Afstand")]
        public int? Afstand { get; set; }

        [JsonProperty("BronCode")]
        public string BronCode { get; set; }

        [JsonProperty("ChildrenObjects")]
        public List<object> ChildrenObjects { get; set; }

        [JsonProperty("DatumAanvaarding")]
        public object DatumAanvaarding { get; set; }

        [JsonProperty("DatumOndertekeningAkte")]
        public object DatumOndertekeningAkte { get; set; }

        [JsonProperty("Foto")]
        public string Foto { get; set; }

        [JsonProperty("FotoLarge")]
        public string FotoLarge { get; set; }

        [JsonProperty("FotoLargest")]
        public string FotoLargest { get; set; }

        [JsonProperty("FotoMedium")]
        public string FotoMedium { get; set; }

        [JsonProperty("FotoSecure")]
        public string FotoSecure { get; set; }

        [JsonProperty("GewijzigdDatum")]
        public object GewijzigdDatum { get; set; }

        [JsonProperty("GlobalId")]
        public int? GlobalId { get; set; }

        [JsonProperty("GroupByObjectType")]
        public string GroupByObjectType { get; set; }

        [JsonProperty("Heeft360GradenFoto")]
        public bool? Heeft360GradenFoto { get; set; }

        [JsonProperty("HeeftBrochure")]
        public bool? HeeftBrochure { get; set; }

        [JsonProperty("HeeftOpenhuizenTopper")]
        public bool? HeeftOpenhuizenTopper { get; set; }

        [JsonProperty("HeeftOverbruggingsgrarantie")]
        public bool? HeeftOverbruggingsgrarantie { get; set; }

        [JsonProperty("HeeftPlattegrond")]
        public bool? HeeftPlattegrond { get; set; }

        [JsonProperty("HeeftTophuis")]
        public bool? HeeftTophuis { get; set; }

        [JsonProperty("HeeftVeiling")]
        public bool? HeeftVeiling { get; set; }

        [JsonProperty("HeeftVideo")]
        public bool? HeeftVideo { get; set; }

        [JsonProperty("HuurPrijsTot")]
        public object HuurPrijsTot { get; set; }

        [JsonProperty("Huurprijs")]
        public object Huurprijs { get; set; }

        [JsonProperty("HuurprijsFormaat")]
        public object HuurprijsFormaat { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("InUnitsVanaf")]
        public object InUnitsVanaf { get; set; }

        [JsonProperty("IndProjectObjectType")]
        public bool? IndProjectObjectType { get; set; }

        [JsonProperty("IndTransactieMakelaarTonen")]
        public object IndTransactieMakelaarTonen { get; set; }

        [JsonProperty("IsSearchable")]
        public bool? IsSearchable { get; set; }

        [JsonProperty("IsVerhuurd")]
        public bool? IsVerhuurd { get; set; }

        [JsonProperty("IsVerkocht")]
        public bool? IsVerkocht { get; set; }

        [JsonProperty("IsVerkochtOfVerhuurd")]
        public bool? IsVerkochtOfVerhuurd { get; set; }

        [JsonProperty("Koopprijs")]
        public int? Koopprijs { get; set; }

        [JsonProperty("KoopprijsFormaat")]
        public string KoopprijsFormaat { get; set; }

        [JsonProperty("KoopprijsTot")]
        public int? KoopprijsTot { get; set; }

        [JsonProperty("Land")]
        public string Land { get; set; }

        [JsonProperty("MakelaarId")]
        public int? MakelaarId { get; set; }

        [JsonProperty("MakelaarNaam")]
        public string MakelaarNaam { get; set; }

        [JsonProperty("MobileURL")]
        public string MobileURL { get; set; }

        [JsonProperty("Note")]
        public object Note { get; set; }

        [JsonProperty("OpenHuis")]
        public List<object> OpenHuis { get; set; }

        [JsonProperty("Oppervlakte")]
        public int? Oppervlakte { get; set; }

        [JsonProperty("Perceeloppervlakte")]
        public int? Perceeloppervlakte { get; set; }

        [JsonProperty("Postcode")]
        public string Postcode { get; set; }

        [JsonProperty("Prijs")]
        public Prijs Prijs { get; set; }

        [JsonProperty("PrijsGeformatteerdHtml")]
        public string PrijsGeformatteerdHtml { get; set; }

        [JsonProperty("PrijsGeformatteerdTextHuur")]
        public string PrijsGeformatteerdTextHuur { get; set; }

        [JsonProperty("PrijsGeformatteerdTextKoop")]
        public string PrijsGeformatteerdTextKoop { get; set; }

        [JsonProperty("Producten")]
        public List<string> Producten { get; set; }

        [JsonProperty("Project")]
        public Project Project { get; set; }

        [JsonProperty("ProjectNaam")]
        public object ProjectNaam { get; set; }

        [JsonProperty("PromoLabel")]
        public PromoLabel PromoLabel { get; set; }

        [JsonProperty("PublicatieDatum")]
        public DateTime PublicatieDatum { get; set; }

        [JsonProperty("PublicatieStatus")]
        public int? PublicatieStatus { get; set; }

        [JsonProperty("SavedDate")]
        public object SavedDate { get; set; }

        [JsonProperty("Soort-aanbod")]
        public string SoortAanbodNumber { get; set; }

        [JsonProperty("SoortAanbod")]
        public int? SoortAanbod { get; set; }

        [JsonProperty("StartOplevering")]
        public object StartOplevering { get; set; }

        [JsonProperty("TimeAgoText")]
        public object TimeAgoText { get; set; }

        [JsonProperty("TransactieAfmeldDatum")]
        public object TransactieAfmeldDatum { get; set; }

        [JsonProperty("TransactieMakelaarId")]
        public object TransactieMakelaarId { get; set; }

        [JsonProperty("TransactieMakelaarNaam")]
        public object TransactieMakelaarNaam { get; set; }

        [JsonProperty("TypeProject")]
        public int? TypeProject { get; set; }

        [JsonProperty("URL")]
        public string URL { get; set; }

        [JsonProperty("VerkoopStatus")]
        public string VerkoopStatus { get; set; }

        [JsonProperty("WGS84_X")]
        public double? WGS84X { get; set; }

        [JsonProperty("WGS84_Y")]
        public double? WGS84Y { get; set; }

        [JsonProperty("WoonOppervlakteTot")]
        public int? WoonOppervlakteTot { get; set; }

        [JsonProperty("Woonoppervlakte")]
        public int? Woonoppervlakte { get; set; }

        [JsonProperty("Woonplaats")]
        public string Woonplaats { get; set; }

        [JsonProperty("ZoekType")]
        public List<int> ZoekType { get; set; }
    }

    public class Paging
    {
        [JsonProperty("AantalPaginas")]
        public int? AantalPaginas { get; set; }

        [JsonProperty("HuidigePagina")]
        public int? HuidigePagina { get; set; }

        [JsonProperty("VolgendeUrl")]
        public string VolgendeUrl { get; set; }

        [JsonProperty("VorigeUrl")]
        public object VorigeUrl { get; set; }
    }

    public class FundaJSON
    {
        [JsonProperty("AccountStatus")]
        public int? AccountStatus { get; set; }

        [JsonProperty("EmailNotConfirmed")]
        public bool? EmailNotConfirmed { get; set; }

        [JsonProperty("ValidationFailed")]
        public bool? ValidationFailed { get; set; }

        [JsonProperty("ValidationReport")]
        public object ValidationReport { get; set; }

        [JsonProperty("Website")]
        public int? Website { get; set; }

        [JsonProperty("Metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("Objects")]
        public List<Object> Objects { get; set; }

        [JsonProperty("Paging")]
        public Paging Paging { get; set; }

        [JsonProperty("TotaalAantalObjecten")]
        public int? TotaalAantalObjecten { get; set; }
    }

}