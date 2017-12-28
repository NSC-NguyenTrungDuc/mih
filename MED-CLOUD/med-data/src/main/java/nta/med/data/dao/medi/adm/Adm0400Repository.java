package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.core.domain.adm.Adm0400;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0400Repository extends JpaRepository<Adm0400, Long>, Adm0400RepositoryCustom {
	@Query("SELECT adm FROM Adm0400 adm WHERE asmName = :f_asm_name ")
	public List<Adm0400> getADM401UGrdGrp(@Param("f_asm_name") String asmName);
	
	@Modifying
	@Query(" UPDATE Adm0400 SET asmVer = :f_asm_ver,asmEssVer = :f_asm_ver WHERE asmName = :f_asm_name ")
	public Integer updateADM401U(@Param("f_asm_ver") String asmVer,@Param("f_asm_name") String asmName);
	
	@Modifying
	@Query(" UPDATE Adm0400 SET asmVer = TO_NUMBER(asmVer) + 1, asmEssVer = TO_NUMBER(asmVer) + 1 WHERE asmName = :f_asm_name ")
	public Integer updateADM401UCaseElse(@Param("f_asm_name") String asmName);
}

