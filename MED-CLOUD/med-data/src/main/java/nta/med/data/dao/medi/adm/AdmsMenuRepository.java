package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.AdmsMenu;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface AdmsMenuRepository extends JpaRepository<AdmsMenu, Long>, AdmsMenuRepositoryCustom {
	@Modifying
	@Query("UPDATE AdmsMenu SET selectFlg = :selectFlg WHERE systemId = :systemId AND hospCode = :hospCode AND trId= :trId")
	public Integer updateADMS2015U01SettingMenu(
			@Param("selectFlg") Integer selectFlg,
			@Param("systemId") String systemId,
			@Param("hospCode") String hospCode,
			@Param("trId") String trId);
}

