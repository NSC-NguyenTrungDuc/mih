package nta.med.data.dao.medi.bil;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bill.Bil0102;

@Repository
public interface Bil0102Repository extends JpaRepository<Bil0102, Long>, Bil0102RepositoryCustom {

	@Query("SELECT T FROM Bil0102 T WHERE T.hospCode = :f_hosp_code AND T.invoiceNo = :f_invoice_no AND T.activeFlg = 1")
	public List<Bil0102> findByHospCodeInvoiceNo(@Param("f_hosp_code") String hospCode, @Param("f_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0102 SET activeFlg = 0 WHERE hospCode = :f_hosp_code AND invoiceNo = :f_invoice_no")
	public Integer deactiveInvoiceDetail(@Param("f_hosp_code") String hospCode, @Param("f_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0102 SET amountDebt = :amountDebt , amountPaid = :amountPaid, updId = :userId WHERE hospCode = :f_hosp_code AND invoiceNo = :f_invoice_no AND activeFlg = 1 ")
	public Integer updateAmtDeptAndPaid(@Param("f_hosp_code") String hospCode, 
			@Param("f_invoice_no") String invoiceNo,
			@Param("amountDebt") BigDecimal amountDebt,
			@Param("amountPaid") BigDecimal amountPaid,
			@Param("userId") String userId);
}
