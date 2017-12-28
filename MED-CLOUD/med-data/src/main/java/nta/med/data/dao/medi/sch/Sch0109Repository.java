package nta.med.data.dao.medi.sch;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.sch.Sch0109;
import nta.med.data.dao.medi.CacheRepository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
public interface Sch0109Repository extends Sch0109RepositoryCustom, CacheRepository<Sch0109> {
	public List<Sch0109> getSCH0109U00GrdDetailInfo(String hospCode, String language,
			String codeType);
	
	public List<Sch0109> getSCH0201Q04GetCboInfo(String hospCode, String language,
			String codeType);
	
	public String getSCH0109U00LayDupD(String hospCode,
			String language,
			String codeType,
			String code);
	
	public String getSCH0109XSavePerformer(String hospCode,String language,
			String codeType);
	
	@Modifying
	public Integer deleteSCH0109XSavePerformer1(String hospCode,
			String language,
			String codeType);
	
	public Integer deleteSCH0109XSavePerformer(String hospCode,String language,
			String codeType,
			String code);
	
	public Integer updateSCH0109XSavePerformer(String sysId,
			Date updDate,
			String codeName,
			String codeName2,
			String code2,
			String hospCode,
			String codeType,
			String code);
	
	public Integer updateSCH0109WithSeq(String sysId,
			Date updDate,
			String codeName,
			String codeName2,
			String code2,
			Double seq,
			String hospCode,
			String language,
			String codeType,
			String code);
	
	public boolean isExistedSCH0109(String hospCode, String codeType, String code, String language);
}

