package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0310;
import nta.med.data.dao.medi.CacheRepository;

import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

/**
 * @author dainguyen.
 */
public interface Bas0310Repository extends Bas0310RepositoryCustom, CacheRepository<Bas0310> {
	@Query("	DELETE FROM Bas0310	"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	AND sgCode = :f_sg_code	"
			+"	AND sgYmd = :f_sg_ymd	")
	public Integer deleteBAS0310WhereHospSgCodeYmd(
			String hospCode,
			String sgCode, 
			Date sgYmd);
	
	@Query("	UPDATE Bas0310	"
			+"	SET updId = :f_user_id	"
			+"	, updDate = :f_upd_date	"
			+"	, sgName = :f_sg_name	"
			+"	, sgNameKana = :f_sg_name_kana	"
			+"	, bulyongYmd = :f_bulyong_ymd	"
			+"	, sgUnion = :f_sg_union 	"
			+"	, groupGubun = :f_group_gubun	"
			+"	, bunCode = :f_bun_code	"
			+"	, marumeGubun = :f_marume_gubun	"
			+"	, hubalDrgYn = :f_hubal_drg_yn	"
			+"	, danui = :f_danui	"
			+"	, sunabQcodeOut = :f_sunab_qcode_out 	"
			+"	, sunabQcodeInp = :f_sunab_qcode_inp	"
			+"	, sugaChange = :f_suga_change	"
			+"	, bulyongSayu = :f_bulyong_sayu	"
			+"	, remark = :f_remark	"
			+"	, taxYn = :f_tax_yn	"
			+"	, modifyFlg = :modifyFlg	"
			+"	, privateFeeYn = :privateFeeYn	"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	AND sgCode = :f_sg_code	"
			+"	AND sgYmd = :f_sg_ymd	")
	public Integer updateBAS0310WhereHospSgCodeYmd(
			String updId,
			Date updDate,
			String sgName,
			String sgNameKana,
			Date bulyongYmd,
			String sgUnion,
			String groupGubun,
			String bunCode,
			String marumeGubun,
			String hubalDrgYn,
			String danui,
			String sunabQcodeOut,
			String sunabQcodeInp,
			String sugaChange,
			String bulyongSayu,
			String remark,
			String taxYn,
			String modifyFlg,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn);
	
	@Query("	UPDATE Bas0310	"
			+"	SET updId = :f_user_id	"
			+"	, updDate = :f_upd_date	"
			+"	, sgName = :f_sg_name	"
			+"	, sgNameKana = :f_sg_name_kana	"
			+"	, bulyongYmd = :f_bulyong_ymd	"
			+"	, sgUnion = :f_sg_union 	"
			+"	, groupGubun = :f_group_gubun	"
			+"	, bunCode = :f_bun_code	"
			+"	, marumeGubun = :f_marume_gubun	"
			+"	, hubalDrgYn = :f_hubal_drg_yn	"
			+"	, danui = :f_danui	"
			+"	, sunabQcodeOut = :f_sunab_qcode_out 	"
			+"	, sunabQcodeInp = :f_sunab_qcode_inp	"
			+"	, sugaChange = :f_suga_change	"
			+"	, bulyongSayu = :f_bulyong_sayu	"
			+"	, remark = :f_remark	"
			+"	, taxYn = :f_tax_yn	"
			+"	, privateFeeYn = :privateFeeYn	"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	AND sgCode = :f_sg_code	"
			+"	AND sgYmd = :f_sg_ymd	")
	public Integer updateBAS0310WhereHospSgCodeYmdIgnoreModifyFlg(
			String updId,
			Date updDate,
			String sgName,
			String sgNameKana,
			Date bulyongYmd,
			String sgUnion,
			String groupGubun,
			String bunCode,
			String marumeGubun,
			String hubalDrgYn,
			String danui,
			String sunabQcodeOut,
			String sunabQcodeInp,
			String sugaChange,
			String bulyongSayu,
			String remark,
			String taxYn,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn);
	
	@Modifying		
	@Query("	UPDATE Bas0310	"
			+"	SET updDate = :f_sys_date	"
			+"	, updId = :f_user_id	"
			+"	, bulyongYmd = :f_bulyong_ymd	"
			+"	, modifyFlg = :modifyFlg	"
			+"	, privateFeeYn = :privateFeeYn	"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	AND sgCode = :f_sg_code	"
			+"	AND sgYmd <= :f_sg_ymd	")
	public Integer updateBAS0310WhereHospSgCodeYmd2(
			Date updDate,
			String updId,
			Date bulyongYmd,
			String modifyFlg,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn);

	@Query("SELECT DISTINCT 'Y' FROM Bas0310 WHERE hospCode = :f_hosp_code AND sgCode = :f_sg_code AND sgYmd = :f_sg_ymd ")
	public String getYFromBAS0310ItemInfo(String hospCode,
			String sgCode,
			Date sgYmd);

	public String callPrUpdateMasterData(String hospCode);
}

