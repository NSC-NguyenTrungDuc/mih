package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0300;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0300Repository extends JpaRepository<Ocs0300, Long>, Ocs0300RepositoryCustom {
	
	@Query("Select ocs from Ocs0300 ocs where ocs.hospCode = :hospCode and ocs.memb = :memb and ocs.inputTab = :inputTab order by seq ")
	public List<Ocs0300> findByMembAndInputTab(@Param("hospCode") String hospCode, @Param("memb") String memb, @Param("inputTab") String inputTab);
	
	@Query("Select max(ocs.pkSeq) + 1 from Ocs0300 ocs where ocs.hospCode = :hospCode and ocs.membGubun = :membGubun and ocs.memb = :memb")
	public Double getMaxPkSeq(@Param("hospCode") String hospCode, @Param("membGubun") String membGubun, @Param("memb") String memb);
	
	@Modifying
	@Query("Update Ocs0300 SET seq =:seq, yaksokGubunName =:yaksokGubunName, updId=:updId, updDate=:updDate"
			+ " where hospCode = :hospCode and membGubun = :membGubun and memb = :memb and pkSeq = :pkSeq")
	public Integer updateOCS0301U00(@Param("hospCode") String hospCode, 
			@Param("seq") Double seq, 
			@Param("yaksokGubunName") String yaksokGubunName, 
			@Param("updId") String updId, 
			@Param("updDate") Date updDate, 
			@Param("membGubun") String membGubun, 
			@Param("memb") String memb, 
			@Param("pkSeq") Double pkSeq);
	
	@Modifying
	@Query("Delete from Ocs0300 where hospCode = :hospCode and membGubun = :membGubun and memb = :memb and pkSeq = :pkSeq")
	public Integer deleteOCS0301U00(@Param("hospCode") String hospCode, 
			@Param("membGubun") String membGubun, 
			@Param("memb") String memb, 
			@Param("pkSeq") Double pkSeq);
	
	@Query("SELECT A.yaksokGubunName FROM Ocs0300 A "
			+ " WHERE A.hospCode = :f_hosp_code AND A.memb = :f_id AND A.pkSeq = :f_m0300")
	public List<String> getOCS0301Q09RbtMembCheckedChangedTableOCS0300(@Param("f_hosp_code") String hospCode,@Param("f_id") String id,
			@Param("f_m0300") Double m0300);
	
	@Query("SELECT max(ocs.seq) + 1 FROM Ocs0300 ocs   WHERE ocs.hospCode = :f_hosp_code AND ocs.membGubun = :f_memb_gubun AND ocs.memb = :f_memb ")
	public Double getSeq(@Param("f_hosp_code") String hospCode, @Param("f_memb_gubun") String membGubun, @Param("f_memb") String memb);
}

