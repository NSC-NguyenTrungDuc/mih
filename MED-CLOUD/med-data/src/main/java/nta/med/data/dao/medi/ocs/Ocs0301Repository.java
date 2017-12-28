package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0301;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0301Repository extends JpaRepository<Ocs0301, Long>, Ocs0301RepositoryCustom {
	@Query("Select ocs FROM Ocs0301 ocs where ocs.hospCode = :hospCode and ocs.memb = :memb and ocs.fkocs0300Seq = :fkocs0300Seq")
	public List<Ocs0301> findByMembAndFkocs0300(@Param("hospCode") String hospCode, @Param("memb") String memb, @Param("fkocs0300Seq") Double fkocs0300Seq);
	
	@Modifying
	@Query("Update Ocs0301 SET seq = :seq, yaksokName = :yaksokName, updDate = :updDate, "
			+ "updId = :updId WHERE hospCode = :hospCode and memb = :memb and fkocs0300Seq = :fkocs0300Seq "
			+ "and yaksokCode = :yaksokCode")
	public Integer updateOCS0301U00(@Param("hospCode") String hospCode,
			@Param("seq") Double seq,
			@Param("yaksokName") String yaksokName,
			@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("memb") String memb,
			@Param("fkocs0300Seq") Double fkocs0300Seq,
			@Param("yaksokCode") String yaksokCode);
	
	@Modifying
	@Query("DELETE FROM Ocs0301 WHERE hospCode = :hospCode and memb = :memb and fkocs0300Seq =:fkocs0300Seq "
			+ "and yaksokCode = :yaksokCode")
	public Integer deleteOCS0301U00(@Param("hospCode") String hospCode,
			@Param("memb") String memb,
			@Param("fkocs0300Seq") Double fkocs0300Seq,
			@Param("yaksokCode") String yaksokCode);
	@Query("SELECT yaksokName FROM Ocs0301 WHERE memb = :f_YaksokOpenID AND yaksokCode = :f_Yasok_code  AND hospCode   = :f_hosp_code")
	public List<String> getOCS0301Q09YasokCode(@Param("f_hosp_code") String hospCode,@Param("f_YaksokOpenID") String yaksokOpenId,
			@Param("f_Yasok_code") String yasokCode);
	
	@Query("SELECT 'Y' FROM  Ocs0301 Z WHERE  Z.hospCode = :f_hosp_code  AND  Z.memb = :f_memb ")
	public String getYnOCS0301Q09SetUserCheckBoxCaseMem(@Param("f_hosp_code") String hospCode,@Param("f_memb") String memb);
	
	@Query("Select max(ocs.seq) + 1 from Ocs0301 ocs where ocs.hospCode = :hospCode  and ocs.memb = :memb and ocs.membGubun = '00' and ocs.fkocs0300Seq = :fkocs0300Seq ")
	public Double getMaxPkSeqOcs0301(@Param("hospCode") String hospCode, @Param("memb") String memb,
			@Param("fkocs0300Seq") Double fkocs0300Seq);
	
}

