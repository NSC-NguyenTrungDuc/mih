package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6012Repository extends JpaRepository<Nur6012, Long>, Nur6012RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Nur6012 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') "
			+ " AND bedsoreBuwi = :f_besore_buwi AND assessorDate = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d') ")
	public Integer deleteNur6012FromNUR6011(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_from_date") String fromDate,
			@Param("f_besore_buwi") String bedsoreBuwi,
			@Param("f_assessor_date") String assessorDate);
	
	@Modifying
	@Query("DELETE FROM Nur6012 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') ")
	public Integer deleteNur6012SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_from_date") String fromDate);
	
	@Modifying
	@Query("UPDATE Nur6012 SET updId = :f_user_id, updDate = SYSDATE(), assessor = :f_assessor, bedsoreDeep = :f_bedsore_deep, bedsoreDepth = :f_bedsore_depth, "
			+ " bedsoreColor = :f_bedsore_color, 		bedsoreSize1 = :f_bedsore_size1, 			bedsoreSizeStart1 = :f_bedsore_size_start1, 			bedsoreSizeFinish1 = :f_bedsore_size_finish1, "
			+ " bedsorePoket1 = :f_bedsore_poket1, 		bedsorePoketStart1 = :f_bedsore_poket_start1, bedsorePoketFinish1  = :f_bedsore_poket_finish1, "
			+ " bedsoreDeath = :f_bedsore_death, 		exudationVolume = :f_exudation_volume, 		exudationState = :f_exudation_state, 					exudationColor = :f_exudation_color, "
			+ " exudationSmell = :f_exudation_smell, 	bedsoreSkin = :f_bedsore_skin, 				bedsoreInfe = :f_bedsore_infe, 							bedsoreMoist = :f_bedsore_moist, "
			+ " bedsoreMoistRate = :f_bedsore_moist_rate, bedsoreGita = :f_bedsore_gita, 			bedsoreNut = :f_bedsore_nut, bedsoreHb = :f_bedsore_hb, bedsoreAlb = :f_bedsore_alb, "
			+ " bedsoreFbs = :f_bedsore_fbs, 			bedsoreZn = :f_bedsore_zn, 					bedsoreSize2 = :f_bedsore_size2, 						bedsoreSizeStart2 = :f_bedsore_size_start2, "
			+ " bedsoreSizeFinish2 = :f_bedsore_size_finish2, bedsorePoket2 = :f_bedsore_poket2, 	bedsorePoketStart2 = :f_bedsore_poket_start2, "
			+ " bedsorePoketFinish2  = :f_bedsore_poket_finish2, endYn = :f_end_yn, 				exudationState1 = :f_exudation_state1, 					exudationState2 = :f_exudation_state2, "
			+ " bedsoreColor2 = :f_bedsore_color2, 		bedsoreColor3 = :f_bedsore_color3, 			bedsoreColor4 = :f_bedsore_color4, firstSayu = :f_first_sayu, lastSayu = :f_last_sayu, "
			+ " yokchangDeep = :f_yokchang_deep, 		samchulYang = :f_samchul_yang, 				yokchangSize = :f_yokchang_size, 						yokchangSizeStart = :f_yokchang_size_start, "
			+ " yokchangSizeEnd = :f_yokchang_size_end, yokchangGamyum = :f_yokchang_gamyum, 		yukajojik = :f_yukajojik, 								gaesajojik = :f_gaesajojik, "
			+ " pocketGubun = :f_pocket_gubun, 			pocketSizeStart = :f_pocket_size_start, 	pocketSizeEnd = :f_pocket_size_end, 					yokchangStage = :f_yokchang_stage, "
			+ " totalCount = :f_total_count, 			yungyangSiksaGubun = :f_yungyang_siksa_gubun, yungyangSiksaYang = :f_yungyang_siksa_yang, "
			+ " yungyangSiksaPercent = :f_yungyang_siksa_percent, yungyangSuaekYn = :f_yungyang_suaek_yn, yungyangSuaekYang = :f_yungyang_suaek_yang, "
			+ " chuchiText = :f_chuchi_text, 			yokchangHb = :f_yokchang_hb, 				yokchangAlb = :f_yokchang_alb,	 						yokchangTp = :f_yokchang_tp "
			+ " WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fromDate = STR_TO_DATE(:f_from_date, '%Y/%m/%d') "
			+ " AND bedsoreBuwi = :f_bedsore_buwi AND assessorDate = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')")
	public Integer updateNur6012SaveLayout(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_from_date") String fromDate,
			@Param("f_bedsore_buwi") String bedsoreBuwi,
			@Param("f_assessor_date") String assessorDate,
			@Param("f_user_id") String updId,
			@Param("f_assessor") String assessor,
			@Param("f_bedsore_deep") String bedsoreDeep,
			@Param("f_bedsore_depth") Double bedsoreDepth,
			@Param("f_bedsore_color") String bedsoreColor,
			@Param("f_bedsore_size1") Double bedsoreSize1,
			@Param("f_bedsore_size_start1") Double bedsoreSizeStart1,
			@Param("f_bedsore_size_finish1") Double bedsoreSizeFinish1,
			@Param("f_bedsore_poket1") Double bedsorePoket1,
			@Param("f_bedsore_poket_start1") Double bedsorePoketStart1,
			@Param("f_bedsore_poket_finish1") Double bedsorePoketFinish1,
			@Param("f_bedsore_death") String bedsoreDeath,
			@Param("f_exudation_volume") String exudationVolume,
			@Param("f_exudation_state") String exudationState,
			@Param("f_exudation_color") String exudationColor,
			@Param("f_exudation_smell") String exudationSmell,
			@Param("f_bedsore_skin") String bedsoreSkin,
			@Param("f_bedsore_infe") String bedsoreInfe,
			@Param("f_bedsore_moist") String bedsoreMoist,
			@Param("f_bedsore_moist_rate") Double bedsoreMoistRate,
			@Param("f_bedsore_gita") String bedsoreGita,
			@Param("f_bedsore_nut") String bedsoreNut,
			@Param("f_bedsore_hb") Double bedsoreHb,
			@Param("f_bedsore_alb") Double bedsoreAlb,
			@Param("f_bedsore_fbs") Double bedsoreFbs,
			@Param("f_bedsore_zn") Double bedsoreZn,
			@Param("f_bedsore_size2") Double bedsoreSize2,
			@Param("f_bedsore_size_start2") Double bedsoreSizeStart2,
			@Param("f_bedsore_size_finish2") Double bedsoreSizeFinish2,
			@Param("f_bedsore_poket2") Double bedsorePoket2,
			@Param("f_bedsore_poket_start2") Double bedsorePoketStart2,
			@Param("f_bedsore_poket_finish2") Double bedsorePoketFinish2,
			@Param("f_end_yn") String endYn,
			@Param("f_exudation_state1") String exudationState1,
			@Param("f_exudation_state2") String exudationState2,
			@Param("f_bedsore_color2") String bedsoreColor2,
			@Param("f_bedsore_color3") String bedsoreColor3,
			@Param("f_bedsore_color4") String bedsoreColor4,
			@Param("f_first_sayu") String firstSayu,
			@Param("f_last_sayu") String lastSayu,
			@Param("f_yokchang_deep") String yokchangDeep,
			@Param("f_samchul_yang") String samchulYang,
			@Param("f_yokchang_size") String yokchangSize,
			@Param("f_yokchang_size_start") Double yokchangSizeStart,
			@Param("f_yokchang_size_end") Double yokchangSizeEnd,
			@Param("f_yokchang_gamyum") String yokchangGamyum,
			@Param("f_yukajojik") String yukajojik,
			@Param("f_gaesajojik") String gaesajojik,
			@Param("f_pocket_gubun") String pocketGubun,
			@Param("f_pocket_size_start") Double pocketSizeStart,
			@Param("f_pocket_size_end") Double pocketSizeEnd,
			@Param("f_yokchang_stage") String yokchangStage,
			@Param("f_total_count") Double totalCount,
			@Param("f_yungyang_siksa_gubun") String yungyangSiksaGubun,
			@Param("f_yungyang_siksa_yang") Double yungyangSiksaYang,
			@Param("f_yungyang_siksa_percent") Double yungyangSiksaPercent,
			@Param("f_yungyang_suaek_yn") String yungyangSuaekYn,
			@Param("f_yungyang_suaek_yang") Double yungyangSuaekYang,
			@Param("f_chuchi_text") String chuchiText,
			@Param("f_yokchang_hb") Double yokchangHb,
			@Param("f_yokchang_alb") Double yokchangAlb,
			@Param("f_yokchang_tp") Double yokchangTp
			);
	
}

