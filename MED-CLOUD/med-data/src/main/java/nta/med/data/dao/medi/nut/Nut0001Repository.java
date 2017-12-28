package nta.med.data.dao.medi.nut;

import java.util.Date;

import nta.med.core.domain.nut.Nut0001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nut0001Repository extends JpaRepository<Nut0001, Long>, Nut0001RepositoryCustom {
	@Modifying
	@Query("	UPDATE Nut0001										"
			+"	  SET updDate            = :f_upd_date,             "
			+"	      iraiDate           = :f_irai_date,            "
			+"	      bmi                 = :f_bmi,                 "
			+"	      sijijikou           = :f_sijijikou,           "
			+"	      targetweight        = :f_targetweight,        "
			+"	      sportYn            = :f_sport_yn,             "
			+"	      drinkYn            = :f_drink_yn,             "
			+"	      energy              = :f_energy,              "
			+"	      protein             = :f_protein,             "
			+"	      fat                 = :f_fat,                 "
			+"	      ps                  = :f_ps,                  "
			+"	      sugar               = :f_sugar,               "
			+"	      salt                = :f_salt,                "
			+"	      water               = :f_water,               "
			+"	      bp                  = :f_bp,                  "
			+"	      fbs                 = :f_fbs,                 "
			+"	      a1c                 = :f_a1c,                 "
			+"	      tch                 = :f_tch,                 "
			+"	      tg                  = :f_tg,                  "
			+"	      hdl                 = :f_hdl,                 "
			+"	      ldl                 = :f_ldl,                 "
			+"	      hb                  = :f_hb,                  "
			+"	      alb                 = :f_alb,                 "
			+"	      bun                 = :f_bun,                 "
			+"	      cre                 = :f_cre,                 "
			+"	      astGot             = :f_ast_got,              "
			+"	      altGpt             = :f_alt_gpt,              "
			+"	      gammagt             = :f_gammagt,             "
			+"	      nutritionist        = :f_nutritionist,        "
			+"	      nutritionistName   = :f_nutritionist_name,   "
			+"	      nutritionObject    = :f_nutrition_object,    "
			+"	      actingDate         = :f_acting_date,         "
			+"	      remark              = :f_remark,              "
			+"	      height              = :f_height,              "
			+"	      weight              = :f_weight,              "
			+"	      syokaiGubun        = :f_syokai_gubun         "
			+"	WHERE hospCode   = :f_hosp_code                     "
			+"	  AND pknut0001      = :f_pknut0001                 ")
	public Integer updateNut0001U00SaveLayout(
			@Param("f_upd_date") Date updDate,
			@Param("f_irai_date") Date iraiDate,
			@Param("f_bmi") Double bmi,
			@Param("f_sijijikou") String sijijikou,
			@Param("f_targetweight") Double targetweight,
			@Param("f_sport_yn") String sportYn,
			@Param("f_drink_yn") String drinkYn,
			@Param("f_energy") Double energy,
			@Param("f_protein") Double protein,
			@Param("f_fat") Double fat,
			@Param("f_ps") Double ps,
			@Param("f_sugar") Double sugar,
			@Param("f_salt") Double salt,
			@Param("f_water") Double water,
			@Param("f_bp") String bp,
			@Param("f_fbs") Double fbs,
			@Param("f_a1c") Double a1c,
			@Param("f_tch") Double tch,
			@Param("f_tg") Double tg,
			@Param("f_hdl") Double hdl,
			@Param("f_ldl") Double ldl,
			@Param("f_hb") Double hb,
			@Param("f_alb") Double alb,
			@Param("f_bun") Double bun,
			@Param("f_cre") Double cre,
			@Param("f_ast_got") Double astGot,
			@Param("f_alt_gpt") Double altGpt,
			@Param("f_gammagt") Double gammagt,
			@Param("f_nutritionist") String nutritionist,
			@Param("f_nutritionist_name") String nutritionistName,
			@Param("f_nutrition_object") String nutritionObject,
			@Param("f_acting_date") Date actingDate,
			@Param("f_remark") String remark,
			@Param("f_height") Double height,
			@Param("f_weight") Double weight,
			@Param("f_syokai_gubun") String syokaiGubun,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pknut0001") Double pknut0001);
	
	@Modifying
	@Query("	DELETE Nut0001                       "
		  +" WHERE pknut0001      = :f_pknut0001     ")
	public Integer deleteNut0001U00SaveLayout(@Param("f_pknut0001") Double pknut0001);
	
}

