package nta.med.data.dao.medi.bas;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.Bas0501;

@Repository
public interface Bas0501Repository extends JpaRepository<Bas0501, Long>, Bas0501RepositoryCustom{
	@Query("SELECT a FROM Bas0501 a WHERE a.hospCode = :hospCode AND a.language = :language AND a.tplType = :tplType AND a.activeFlg = 1 AND formatType = 'HTML' ")
	public Bas0501 findByHospCodeAndTplCode(
			@Param("hospCode") String hospCode,
			@Param("language") String language,
			@Param("tplType") String tplType);
}
