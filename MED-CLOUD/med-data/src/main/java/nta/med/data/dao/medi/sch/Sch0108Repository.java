package nta.med.data.dao.medi.sch;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.sch.Sch0108;
import nta.med.data.dao.medi.CacheRepository;

import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

/**
 * @author dainguyen.
 */
public interface Sch0108Repository extends Sch0108RepositoryCustom, CacheRepository<Sch0108> {
	public List<Sch0108> getSCH0109U00GrdMasterInfo(String hospCode,
			String codeType,
			String codeTypeName,
			String language);
	
	public List<Sch0108> getSCH0109U01GrdMasterInfo(String hospCode,
			String codeType,
			String codeTypeName,
			String language);
	
	public String getSCH0109U00LayDupM(String hospCode,
			String codeType,
			String language);
	
	public Integer updateSCH0108XSavePerformer(String updId,
			Date updDate,
			String codeTypeName,
			String hospCode,
			String codeType,
			String language);
	
	public Integer updateSCH0109U01Execute(String updId,
			Date updDate,
			String codeTypeName,
			String adminGubun,
			String remark,
			String hospCode,
			String codeType,
			String language);
	
	@Modifying
	@Query("DELETE Sch0108 WHERE codeType = :codeType ")
	public Integer deleteSCH0108XSavePerformer(String hospCode,
			String codeType,
			String language);
}

