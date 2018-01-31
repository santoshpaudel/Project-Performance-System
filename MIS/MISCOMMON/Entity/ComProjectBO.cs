using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ComProjectBO
    {
        public int ProjectId { get; set; }
        public string AyojanaEngName { get; set; }
        public string AjojanaNepName { get; set; }
        public string AyojanaLakshya { get; set; }
        public string AyojanaUdeshya { get; set; }
        public string AyojanaPratifal { get; set; }
        public string AyojanaKriyakalap { get; set; }
        public int KaryakramPrakar { get; set; }
        public string SuruMiti { get; set; }
        public string AyojanaSampannaMiti { get; set; }
        public string AyojanaSampannaMitiPratham { get; set; }
        public string AyojanaSampannaMitiDoshro { get; set; }
        public string AyojanaSampannaMitiTeshro { get; set; }
        public int Sector { get; set; }
        public int SubSector { get; set; }
        public int Rananiti { get; set; }
        public int Karyaniti1 { get; set; }
        public int Karyaniti2 { get; set; }
        public int Karyaniti3 { get; set; }
        public int SahasabdiBikashLakshya { get; set; }
        public int SahasabdiBikashGantabya { get; set; }
        public int SahasabdiBikashSuchak { get; set; }
        public int GaribiSankhet { get; set; }
        public int LaingikSankhet { get; set; }
        public string AyojanaKishim { get; set; }
        public int Priority { get; set; }
        public int AyojanaKaryanayanChetra { get; set; }
        public decimal AyojanaLagat { get; set; }
        public string KaryanayanNikay { get; set; }
        public string ChanautkoAdhar { get; set; }

        public int Swadeshi { get; set; }
        public int Bideshi { get; set; }
        public int Shrot { get; set; }
        public int BhuktaniPrakar { get; set; }
        public decimal Rakam { get; set; }
        public int AarthikBarsha { get; set; }
        public decimal RakamBadfad { get; set; }
        public string Mode { get; set; }
        public decimal IsEnable { get; set; }
        public decimal IsLocked { get; set; }
        public string Lang { get; set; }
        public int ProjectProgramType { get; set; }
        public int ProjectProposalTotalYear { get; set; }
        public int OfficeId { get; set; }
        public int UserId { get; set; }
        public int BudgetHeadId { get; set; }
        public int DistrictNumber { get; set; }
        public int ElectionAreaNumber { get; set; }
        public int VdcMunNumber { get; set; }
        public string KaryanayanBibaran { get; set; }
        public int SambhaabyataAdhyan { get; set; }
        public int SambhaabyataAdhyanYear { get; set; }
        public string SambhaabyataAdhyanNiskarsha { get; set; }
        public string PayBackPeriod { get; set; }
        public decimal BenefitCostRatio { get; set; }
        public decimal Firr { get; set; }
        public decimal Eirr { get; set; }
        public string NetPresentValue { get; set; }
        public string CostEffectiveAnalysis { get; set; }
        public string KaryanoyanNikaaya { get; set; }

        public string PayBackPeriodRemarks { get; set; }
        public string BenefitCostRatioRemarks { get; set; }
        public string FirrRemarks { get; set; }
        public string EirrRemarks { get; set; }
        public string NetPresentValueRemarks { get; set; }
        public string CostEffectiveAnalysisRemarks { get; set; }

        public int EnvironmentalBibaran { get; set; }
        public string EnvironmentalBibaranRemarks { get; set; }
        public int FiscalYearId { get; set; }
        public int ExistingJanashakti { get; set; }
        public int ThapJanashakti { get; set; }
        //added
        public string ThapJanashaktiKaifiyat { get; set; }

        public string MinistryRaaya { get; set; }
        public decimal ChuttayiyekoRakam { get; set; }
        public string DaatriBibaran { get; set; }
        public string NepalSarkarBibaran { get; set; }
        public string PhaseOutPlan { get; set; }
        public string BhautikSamagri { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal AnumanitRakam { get; set; }
        //added
        public string SamagriKaifiyat { get; set; }
        public decimal JaggaPrapti { get; set; }
        public int JaggaPraptiUnit { get; set; }
        public int LavanbitMahila { get; set; }
        public int LavanbitBalBalika { get; set; }
        public int LavanbitJanajati { get; set; }
        public int LavanbitDalit { get; set; }
        public int LavanbitMadheshi { get; set; }
        public int LavanbitMuslim { get; set; }
        public int Anya { get; set; }
        public int IsUsable { get; set; }

        //added
        public string LavanbitMahilaKaifiyat { get; set; }
        public string LavanbitBalBalikaKaifiyat { get; set; }
        public string LavanbitJanajatiKaifiyat { get; set; }
        public string LavanbitDalitKaifiyat { get; set; }
        public string LavanbitMadhesiKaifiyat { get; set; }
        public string LavanbitMuslimKaifiyat { get; set; }
        public string LavanbitAnyaKaifiyat { get; set; }

        public int Shramdin { get; set; }
        public decimal Parimaan { get; set; }
        public string Yogdan { get; set; }
        public decimal RakamSwadeshi { get; set; }
        public decimal RakamBideshi { get; set; }
        public int ThekkaSankhya { get; set; }
        public decimal ThekkaRakam { get; set; }
        public string SambhaabyataRemarks { get; set; }
        public string SansodhanDate { get; set; }
        public string FileName { get; set; }

        public int ChaumasikId { get; set; }
        public string Problems { get; set; }
        public string Reasons { get; set; }
        public string Efforts { get; set; }
        public string Suggestions { get; set; }
        public int Ndac { get; set; }

        public string PramukhStartDate { get; set; }
        public string PramukhName { get; set; }

        public int MinistryId { get; set; }
        public int SelectedMinistryId { get; set; }

        public int Order { get; set; }
        public string Output { get; set; }
        public decimal YearlyTarget { get; set; }
        public decimal FirstQuarterTarget { get; set; }
        public decimal SecondQuarterTarget { get; set; }
        public decimal ThirdQuarterTarget { get; set; }
        //added
        public string OutputRemarks { get; set; }
        public string MantralayaBibaran { get; set; }

        public decimal SwadeshiShramDin { get; set; }
        public decimal BideshiShramDin { get; set; }

        public int SahasrabdiOrDigo { get; set; }
        public int DigoBikashLakshya { get; set; }
        public int DigoBikashGantabya { get; set; }
        public int DigoBikashSuchak { get; set; }
        public int JalvayuSanket { get; set; }
        public int YojanaRananitiNo { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        //added later
        public string RananitiEngName { get; set; }
        public string RananitiNepName { get; set; }
        public int RananitiId { get; set; }

        public string KaryanitiEngName { get; set; }
        public string KaryanitiNepName { get; set; }
        public int KaryanitiId { get; set; }

    }
}
