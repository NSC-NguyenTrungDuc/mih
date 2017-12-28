package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.drg.Drg0120;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Drg0120Repository extends Drg0120RepositoryCustom, CacheRepository<Drg0120> {
	public Integer updateDrg0120(Date updDate,
			String bogyongName,
			String pattern,
			String bogyongGubun,
			String drgGrp,
			String bogyongName2,
			String bogyongGubunDefault,
			String prtGubun,
			String bunryu1,
			String bogyongCodeFull,
			String spBogyongYn,
			String blockGubun,
			String banghyang,
			String chiryoGubun,
			String donbogYn,
			String updId,
			String bogyongJoFlag,
			String bogyongJuFlag,
			String bogyongSeokFlag,
			String bogyongTime1Flag,
			String bogyongTime2Flag,
			String bogyongTime3Flag,
			String bogyongTime4Flag,
			String bogyongTime5Flag,
			String bogyongTime6Flag,
			String bogyongTime7Flag,
			String bogyongCode,
			String hospCode, 
			String language);
	
	public Integer deleteDrg0120(String bogyongCode, String hospCode, String language);
	
	public String getHIOcsBogyong(String hospCode, String bogyongCode, String language);
	
	public List<Drg0120> getObjectOBGetBogyongInfo(String hospCode,String bogyoungCode, String language);
	
	public List<Drg0120> findByHospCodeLanguage(String hospCode, String language);
}

