package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0002Repository extends JpaRepository<Adm0002, Long>, Adm0002RepositoryCustom {
	@Modifying
	@Query("UPDATE Adm0002 SET msgGubun  = :f_msg_gubun , "
			+ "koreaMsg  = :f_korea_msg ,japanMsg  = :f_japan_msg  "
			+ ",speakMsg  = :f_speak_msg WHERE adm0002Pk = :f_pk ")
	public Integer updateAdm0002(@Param("f_msg_gubun") String msgGubun, @Param("f_korea_msg") String koreaMsg, 
			@Param("f_japan_msg") String japanMsg, @Param("f_speak_msg") String speakMsg, @Param("f_pk") Double adm0002Pk );
	
	@Modifying
	@Query("DELETE Adm0002 WHERE adm0002Pk = :f_pk")
	public Integer deleteAdm0002(@Param("f_pk") Double adm0002Pk);
}

