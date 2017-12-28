package nta.med.data.dao.medi.inv;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv4002;

@Repository
public interface Inv4002Repository extends JpaRepository<Inv4002, Long>, Inv4002RepositoryCustom{
	@Modifying
	@Query("UPDATE Inv4002 							"
			+ "SET ipgoQty = :f_ipgo_qty,		    "
			+ " ipgoDanga = :f_ipgo_danga,	        "
			+ " remark = :f_remark,				    "
			+ " updDate = SYSDATE(),				"
			+ " startDate = :start_date,  		    "
			+ " lot = :lot ,                        "
			+ " expiredDate = :expired_date , 		"
			+ " updId = :q_user_id  		    	"
			+ "WHERE hospCode = :hosp_code 		"
			+ " AND fkinv4001 = :fkinv4001          "
			+ " AND  jaeryoCode = :jaeryoCode ")
	public Integer updateINV4002(@Param("hosp_code") String hospCode,
			@Param("fkinv4001") Double fkinv4001,
			@Param("jaeryoCode") String jaeryoCode,
			@Param("f_ipgo_qty") Double ipgoQty,
			@Param("f_ipgo_danga") Double ipgoDanga,
			@Param("f_remark") String remark,
			@Param("start_date") Date startDate,
			@Param("lot") String lot,
			@Param("expired_date") Date expiredDate,
			@Param("q_user_id") String updId);
	
	@Modifying
	@Query("DELETE Inv4002 							"
			+ "WHERE hospCode = :hosp_code 		"
			+ " AND fkinv4001 = :fkinv4001"
			+ " AND  jaeryoCode = :jaeryoCode ")
	public Integer deleteINV4002(@Param("hosp_code") String hospCode,
			@Param("fkinv4001") Double fkinv4001,
			@Param("jaeryoCode") String jaeryoCode);
	
	@Query("SELECT 'Y' FROM Inv4002 							"
			+ "WHERE hospCode = :hosp_code 		"
			+ " AND fkinv4001 = :fkinv4001"
			+ " AND  jaeryoCode = :jaeryoCode ")
	public String checkExists(@Param("hosp_code") String hospCode,
			@Param("fkinv4001") Double fkinv4001,
			@Param("jaeryoCode") String jaeryoCode);
}
