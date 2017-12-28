package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs2003;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2003Repository extends JpaRepository<Ocs2003, Long>, Ocs2003RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ocs2003  WHERE hospCode = :f_hosp_code  AND pkocs2003 = :f_pkocskey ")
	public Integer deleteOCS0103U13SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_pkocskey") Double pkocs2003);
	
	@Query("SELECT ocs FROM Ocs2003 ocs  WHERE hospCode = :f_hosp_code AND pkocs2003 = :f_pkocskey")
	public List<Ocs2003> listOcs2003OCS0103U13SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_pkocskey") Double pkocs2003);
	
	@Modifying
	@Query("	UPDATE Ocs2003 A					              "
			+"	  SET A.updId        = :updId                     "
			+"	    , A.updDate      = SYSDATE()                  "
			+"	    , A.jundalPart  = :jundalPart                 "
			+"	    , A.jundalTable = :jundalTable                "
			+"	    , A.movePart    = :movePart                   "
			+"	    , A.inputGubun  = :inputGubun                 "
			+"	    , A.nalsu        = :nalsu                     "
			+"	    , A.suryang      = :suryang                   "
			+"	    , A.dv           = :dv                        "
			+"	    , A.approveYn   = 'Y'                         "
			+"	    , A.approveId   = :approveId                  "
			+"	    , A.approveDate = SYSDATE()                   "
			+"	    , A.approveTime = DATE_FORMAT(SYSDATE(), '%H%i')         "
			+"	    , A.inputId     = :inputId                    "
			+"	    , A.muhyo        = :muhyo                     "
			+"	WHERE A.hospCode    = :hospCode                   "
			+"	  AND A.pkocs2003    = :pkocs2003                 ")
	public Integer updateOCSAPPROVEOcs2003(
			@Param("updId") String updId,
			@Param("jundalPart") String jundalPart,
			@Param("jundalTable") String jundalTable,
			@Param("movePart") String movePart,
			@Param("inputGubun") String inputGubun,
			@Param("nalsu") Double nalsu,
			@Param("suryang") Double suryang,
			@Param("dv") Double dv,
			@Param("approveId") String approveId,
			@Param("inputId") String inputId,
			@Param("muhyo") String muhyo,
			@Param("hospCode") String hospCode,
			@Param("pkocs2003") Double pkocs2003);
	
	@Query("select ifDataSendYn from Ocs2003 where hospCode  = :hospCode AND pkocs2003 = :f_pkocs")
	public List<String> getIfDataSendYnOCS2003(@Param("hospCode") String hospCode,@Param("f_pkocs") Double pkocs2003);
	
	@Modifying
	@Query("UPDATE Ocs2003 SET nurseRemark = :f_remark,updId = 'UPD_REC_'  WHERE hospCode = :f_hosp_code AND pkocs2003 = :f_pkocs")
	public Integer updateOCSACTOcs2003ChangeNurSeRemarkAndUpdId(@Param("f_hosp_code") String hospCode,@Param("f_remark") String reMark,@Param("f_pkocs") Double pkocs2003);
	
	@Modifying
	@Query("UPDATE Ocs2003 SET nurseRemark = :f_remark,fkocs1003 = :fkocs1003,updId = 'UPD_REC_'  WHERE hospCode = :f_hosp_code AND pkocs2003 = :f_pkocs2003")
	public Integer updateOCSACTOcs2003ChangeNurSeRemarkAndFkOcs1003AndUpdId(@Param("f_hosp_code") String hospCode,@Param("f_remark") String reMark,
			@Param("fkocs1003") Double fkocs1003,@Param("f_pkocs2003") Double pkocs2003);
	
	
	@Modifying
	@Query("UPDATE Ocs2003 A SET A.suryang = :f_suryang, A.nalsu   = :f_nalsu WHERE A.hospCode = :f_hosp_code AND A.pkocs2003 = :f_pkocskey")
	public Integer updateOCSATOcs2003ChangeSuRyangNalsu(@Param("f_hosp_code") String hospCode,@Param("f_suryang") Double suryang,
			@Param("f_nalsu") Double nalsu,@Param("f_pkocskey") Double pkocs2003);
	
	@Modifying
	@Query("UPDATE Ocs2003 SET jubsuDate = null , actingDate = null WHERE hospCode  = :f_hosp_code  AND pkocs2003  = :f_pkocs")
	public Integer updateOCSACTOcs2003ChangeJubsuDateAndActingDate(@Param("f_hosp_code") String hospCode,@Param("f_pkocs") Double pkocs2003);
	
	@Modifying
	@Query(   " UPDATE Ocs2003                                    "
            + "    SET updDate          = :f_sys_date             "
            + "      , updId            = :f_user_id              "
            + "      , orderGubun       = :f_order_gubun          "
            + "      , suryang          = :f_suryang              "
            + "      , dvTime           = :f_dv_time              "
            + "      , dv               = :f_dv                   "
            + "      , ndayYn           = :f_nday_yn              "
            + "      , nalsu            = :f_nalsu                "
            + "      , jusa             = :f_jusa                 "
            + "      , bogyongCode      = :f_bogyong_code         "
            + "      , emergency        = :f_emergency            "
            + "      , jaeryoJundalYn   = :f_jaeryo_jundal_yn     "
            + "      , jundalTable      = :f_jundal_table         "
            + "      , jundalPart       = :f_jundal_part          "
            + "      , movePart         = :f_move_part            "
            + "      , muhyo            = :f_muhyo                "
            + "      , portableYn       = :f_portable_yn          "
            + "      , antiCancerYn     = :f_anti_cancer_yn       "
            + "      , dcYn             = :f_dc_yn                "
            + "      , dcGubun          = :f_dc_gubun             "
            + "      , bannabYn         = :f_bannab_yn            "
            + "      , bannabConfirm    = :f_bannab_confirm       "
            + "      , powderYn         = :f_powder_yn            "
            + "      , hopeDate         = :f_hope_date            "
            + "      , hopeTime         = :f_hope_time            "
            + "      , dv1              = :f_dv_1                 "
            + "      , dv2              = :f_dv_2                 "
            + "      , dv3              = :f_dv_3                 "
            + "      , dv4              = :f_dv_4                 "
            + "      , mixGroup         = :f_mix_group            "
            + "      , orderRemark      = :f_order_remark         "
            + "      , nurseRemark      = :f_nurse_remark         "
            + "      , bomOccurYn       = :f_bom_occur_yn         "
            + "      , bomSourceKey     = :f_bom_source_key       "
            + "      , nurseConfirmUser = :f_nurse_confirm_user "
            + "      , nurseConfirmDate = :f_nurse_confirm_date "
            + "      , nurseConfirmTime = :f_nurse_confirm_time "
            + "      , regularYn        = :f_regular_yn           "
            + "      , hubalChangeYn    = :f_hubal_change_yn      "
            + "      , pharmacy         = :f_pharmacy             "
            + "      , jusaSpdGubun     = :f_jusa_spd_gubun       "
            + "      , drgPackYn        = :f_drg_pack_yn          "
            + "      , sortFkocskey     = :f_sort_fkocskey        "
            + "      , wonyoiOrderYn    = :f_wonyoi_order_yn      "
            + "      , displayYn        = CASE WHEN dcGubun = 'Y' "
            + "        AND sortFkocskey IS NOT NULL               "
			+ "        AND :f_dc_gubun = 'N' THEN 'N'             "
			+ "        ELSE displayYn END                         "
            + "      , specimenCode     = :f_specimen_code        "
            + "  WHERE hospCode  = :f_hosp_code                   "
            + "    AND pkocs2003 = :f_pkocskey                    ")
	public Integer updateOCS0103U15SaveLayout(
			@Param("f_sys_date") Date updDate,
			@Param("f_user_id") String updId,
			@Param("f_order_gubun") String orderGubun,
			@Param("f_suryang") String suryang,
			@Param("f_dv_time") String dvTime,
			@Param("f_dv") Double dv,
			@Param("f_nday_yn") String ndayYn,
			@Param("f_nalsu") String nalsu,
			@Param("f_jusa") String jusa,
			@Param("f_bogyong_code") String bogyongCode,
			@Param("f_jaeryo_jundal_yn") String jaeryoJundalYn,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_move_part") String movePart,
			@Param("f_muhyo") String muhyo,
			@Param("f_portable_yn") String portableYn,
			@Param("f_anti_cancer_yn") String antiCancerYn,
			@Param("f_dc_yn") String dcYn,
			@Param("f_dc_gubun") String dcGubun,
			@Param("f_bannab_yn") String bannabYn,
			@Param("f_bannab_confirm") String bannabConfirm,
			@Param("f_powder_yn") String powderYn,
			@Param("f_hope_date") Date hopeDate,
			@Param("f_hope_time") String hopeTime,
			@Param("f_dv_1") Double dv1,
			@Param("f_dv_2") Double dv2,
			@Param("f_dv_3") Double dv3,
			@Param("f_dv_4") Double dv4,
			@Param("f_mix_group") String mixGroup,
			@Param("f_order_remark") String orderRemark,
			@Param("f_nurse_remark") String nurseRemark,
			@Param("f_bom_occur_yn") String bomOccurYn,
			@Param("f_bom_source_key") Double bomSourceKey,
			@Param("f_nurse_confirm_user") String nurseConfirmUser,
			@Param("f_nurse_confirm_date") Date nurseConfirmDate,
			@Param("f_nurse_confirm_time") String nurseConfirmTime,
			@Param("f_regular_yn") String regularYn,
			@Param("f_hubal_change_yn") String hubalChangeYn,
			@Param("f_pharmacy") String pharmacy,
			@Param("f_jusa_spd_gubun") String jusaSpdGubun,
			@Param("f_drg_pack_yn") String drgPackYn,
			@Param("f_sort_fkocskey") Double sortFkocskey,
			@Param("f_wonyoi_order_yn") String wonyoiOrderYn,
			@Param("f_specimen_code") String specimenCode,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkocskey") String pkocs2003);
	
	@Modifying
	@Query(   " UPDATE Ocs2003                                    "
            + "    SET updDate          = :f_sys_date             "
            + "      , updId            = :f_user_id              "
            + "      , orderGubun       = :f_order_gubun          "
            + "      , suryang          = :f_suryang              "
            + "      , ordDanui         = :f_ord_danui            "
            + "      , dvTime           = :f_dv_time              "
            + "      , dv               = :f_dv                   "
            + "      , ndayYn           = :f_nday_yn              "
            + "      , nalsu            = :f_nalsu                "
            + "      , jusa             = :f_jusa                 "
            + "      , bogyongCode      = :f_bogyong_code         "
            + "      , emergency        = :f_emergency            "
            + "      , jaeryoJundalYn   = :f_jaeryo_jundal_yn     "
            + "      , jundalTable      = :f_jundal_table         "
            + "      , jundalPart       = :f_jundal_part          "
            + "      , movePart         = :f_move_part            "
            + "      , muhyo            = :f_muhyo                "
            + "      , portableYn       = :f_portable_yn          "
            + "      , antiCancerYn     = :f_anti_cancer_yn       "
            + "      , dcYn             = :f_dc_yn                "
            + "      , dcGubun          = :f_dc_gubun             "
            + "      , bannabYn         = :f_bannab_yn            "
            + "      , bannabConfirm    = :f_bannab_confirm       "
            + "      , powderYn         = :f_powder_yn            "
            + "      , hopeDate         = :f_hope_date            "
            + "      , hopeTime         = :f_hope_time            "
            + "      , dv1              = :f_dv_1                 "
            + "      , dv2              = :f_dv_2                 "
            + "      , dv3              = :f_dv_3                 "
            + "      , dv4              = :f_dv_4                 "
            + "      , dv5              = :f_dv_5                 "
            + "      , dv6              = :f_dv_6                 "
            + "      , dv7              = :f_dv_7                 "
            + "      , dv8              = :f_dv_8                 "
            + "      , mixGroup         = :f_mix_group            "
            + "      , orderRemark      = :f_order_remark         "
            + "      , nurseRemark      = :f_nurse_remark         "
            + "      , bomOccurYn       = :f_bom_occur_yn         "
            + "      , bomSourceKey     = :f_bom_source_key       "
            + "      , nurseConfirmUser = :f_nurse_confirm_user   "
            + "      , nurseConfirmDate = :f_nurse_confirm_date   "
            + "      , nurseConfirmTime = :f_nurse_confirm_time   "
            + "      , regularYn        = :f_regular_yn           "
            + "      , hubalChangeYn    = :f_hubal_change_yn      "
            + "      , pharmacy         = :f_pharmacy             "
            + "      , jusaSpdGubun     = :f_jusa_spd_gubun       "
            + "      , drgPackYn        = :f_drg_pack_yn          "
            + "      , sortFkocskey     = :f_sort_fkocskey        "
            + "      , wonyoiOrderYn    = :f_wonyoi_order_yn      "
            + "      , displayYn        = CASE WHEN dcGubun = 'Y' "
            + "        AND sortFkocskey IS NOT NULL               "
			+ "        AND :f_dc_gubun = 'N' THEN 'N'             "
			+ "        ELSE displayYn END                         "
            + "      , specimenCode     = :f_specimen_code        "
			+ "      , groupSer     	= :f_group_ser		      "
			+ "      , inputGubun       = :f_input_gubun       	  "
			+ "      , broughtDrgYn   	= :f_brought_drg_yn       "
			+ "      , startDate       	= :f_start_date       	  "
			+ "      , startTime       	= :f_start_time       	  "
			+ "      , startId         	= :f_start_id       	  "
			+ "      , endDate         	= :f_end_date       	  "
			+ "      , endTime         	= :f_end_time             "
			+ "      , endId           	= :f_end_id               "
			+ "      , pkocs1024        = :f_pkocs1024            "
            + "  WHERE hospCode  = :f_hosp_code                   "
            + "    AND pkocs2003 = :f_pkocskey                    ")
	public Integer updateOcs2003P01(
			@Param("f_sys_date") Date updDate,
			@Param("f_user_id") String updId,
			@Param("f_order_gubun") String orderGubun,
			@Param("f_suryang") Double suryang,
			@Param("f_ord_danui") String ordDanui,
			@Param("f_dv_time") String dvTime,
			@Param("f_dv") Double dv,
			@Param("f_nday_yn") String ndayYn,
			@Param("f_nalsu") Double nalsu,
			@Param("f_jusa") String jusa,
			@Param("f_bogyong_code") String bogyongCode,
			@Param("f_emergency") String emergency,
			@Param("f_jaeryo_jundal_yn") String jaeryoJundalYn,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_move_part") String movePart,
			@Param("f_muhyo") String muhyo,
			@Param("f_portable_yn") String portableYn,
			@Param("f_anti_cancer_yn") String antiCancerYn,
			@Param("f_dc_yn") String dcYn,
			@Param("f_dc_gubun") String dcGubun,
			@Param("f_bannab_yn") String bannabYn,
			@Param("f_bannab_confirm") String bannabConfirm,
			@Param("f_powder_yn") String powderYn,
			@Param("f_hope_date") Date hopeDate,
			@Param("f_hope_time") String hopeTime,
			@Param("f_dv_1") Double dv1,
			@Param("f_dv_2") Double dv2,
			@Param("f_dv_3") Double dv3,
			@Param("f_dv_4") Double dv4,
			@Param("f_dv_5") Double dv5,
			@Param("f_dv_6") Double dv6,
			@Param("f_dv_7") Double dv7,
			@Param("f_dv_8") Double dv8,
			@Param("f_mix_group") String mixGroup,
			@Param("f_order_remark") String orderRemark,
			@Param("f_nurse_remark") String nurseRemark,
			@Param("f_bom_occur_yn") String bomOccurYn,
			@Param("f_bom_source_key") Double bomSourceKey,
			@Param("f_nurse_confirm_user") String nurseConfirmUser,
			@Param("f_nurse_confirm_date") Date nurseConfirmDate,
			@Param("f_nurse_confirm_time") String nurseConfirmTime,
			@Param("f_regular_yn") String regularYn,
			@Param("f_hubal_change_yn") String hubalChangeYn,
			@Param("f_pharmacy") String pharmacy,
			@Param("f_jusa_spd_gubun") String jusaSpdGubun,
			@Param("f_drg_pack_yn") String drgPackYn,
			@Param("f_sort_fkocskey") Double sortFkocskey,
			@Param("f_wonyoi_order_yn") String wonyoiOrderYn,
			@Param("f_specimen_code") String specimenCode,
			@Param("f_group_ser") Double groupSer,
			@Param("f_input_gubun") String inputGubun,
			@Param("f_brought_drg_yn") String broughtDrgYn,
			@Param("f_start_date") Date startDate,
			@Param("f_start_time") String startTime,
			@Param("f_start_id") String startId,
			@Param("f_end_date") Date endDate,
			@Param("f_end_time") String endTime,
			@Param("f_end_id") String endId,
			@Param("f_pkocs1024") Double pkocs1024,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkocskey") Double pkocskey);
	
	
	@Modifying
	@Query(   " UPDATE Ocs2003                                                     "
			+ " SET  updId              = :q_user_id                               "
			+ "    , updDate            = SYSDATE()                                "
			+ "    , nursePickupUser    = :f_act_user                              "
			+ "    , nursePickupDate    = STR_TO_DATE(:f_act_res_date, '%Y/%m/%d') "
			+ "    , nursePickupTime    = REPLACE(:f_acting_time, ':', '')         "
			+ " WHERE hospCode   = :f_hosp_code                                    "
			+ " AND pkocs2003    = :f_pkocs2003                                    "
			+ " AND nursePickupUser IS NULL                                        "
			+ " AND nursePickupDate IS NULL                                        "
			+ " AND nursePickupTime IS NULL                                        ")
	public Integer updateOcs2003InNUR2017U01(@Param("q_user_id") String userId,
											 @Param("f_act_user") String actUser,
											 @Param("f_act_res_date") String actResDate,
											 @Param("f_acting_time") String actingTime,
											 @Param("f_hosp_code") String hospCode,
											 @Param("f_pkocs2003") Double pkocs2003);
	
}

