package nta.med.data.dao.medi.clis;

import java.math.BigDecimal;
import java.util.Date;

import nta.med.core.domain.clis.ClisSmo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface ClisSmoRepository extends JpaRepository<ClisSmo, Long>, ClisSmoRepositoryCustom{
	
	@Modifying
	@Query("	Update ClisSmo						   "			
		+"	SET startDate = :startDate,                "
		+"	    endDate = :endDate,                    "
		+"	    smoName = :smoName,                    "
		+"	    smoName1 = :smoName1,                  "
		+"	    zipCode1 = :zipCode1,                  "
		+"	    zipCode2 = :zipCode2,                  "
		+"	    address = :address,                    "
		+"	    address1 = :address1,                  "
		+"	    tel = :tel,                            "
		+"	    tel1 = :tel1,                          "
		+"	    fax = :fax,                            "
		+"	    dodobuhyeunNo = :dodobuhyeunNo,         "
		+"	    homePage = :homePage,                  "
		+"	    email = :email,                        "
		+"	    updId = :updId,                        "
		+"	    updated = :updated                      "
		+"	    WHERE clisSmoId = :clisSmoId	        ")
	public Integer updateClis2015U09Save(
			@Param("startDate") Date startDate,
			@Param("endDate") Date endDate,
			@Param("smoName") String smoName,
			@Param("smoName1") String smoName1,
			@Param("zipCode1") String zipCode1,
			@Param("zipCode2") String zipCode2,
			@Param("address") String address,
			@Param("address1") String address1,
			@Param("tel") String tel,
			@Param("tel1") String tel1,
			@Param("fax") String fax,
			@Param("dodobuhyeunNo") String dodobuhyeunNo,
			@Param("homePage") String homePage,
			@Param("email") String email,
			@Param("updId") String updId,
			@Param("updated") Date updated,
			@Param("clisSmoId") Integer clisSmoId);
	
	@Modifying
	@Query(" Update ClisSmo						"
		+"   SET updated = :updated,			"
		+ "      updId = :updId,				"
		+ "      activeFlg = :activeFlg 		"
		+"	    WHERE clisSmoId = :clisSmoId	")
	public Integer deleteClis2015U09Save(
			@Param("updated") Date updated,
			@Param("updId") String updId,
			@Param("activeFlg") BigDecimal activeFlg,
			@Param("clisSmoId") Integer clisSmoId);

}
