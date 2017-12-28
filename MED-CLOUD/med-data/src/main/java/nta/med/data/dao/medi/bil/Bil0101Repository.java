package nta.med.data.dao.medi.bil;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bill.Bil0101;

@Repository
public interface Bil0101Repository extends JpaRepository<Bil0101, Long>, Bil0101RepositoryCustom {

	@Query("SELECT T FROM Bil0101 T WHERE T.hospCode = :f_hosp_code AND T.invoiceNo = :f_invoice_no AND T.activeFlg = 1")
	public List<Bil0101> findByHospCodeInvoiceNo(@Param("f_hosp_code") String hospCode, @Param("f_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0101 SET activeFlg = 0, updId = :userId, revertComment = :revertComment, amountDebt = :amountDebt WHERE hospCode = :f_hosp_code AND invoiceNo = :f_invoice_no")
	public Integer deactiveInvoiceMaster(@Param("userId") String userId, 
			@Param("revertComment") String revertComment, 
			@Param("amountDebt") BigDecimal amountDebt, 
			@Param("f_hosp_code") String hospCode, 
			@Param("f_invoice_no") String invoiceNo);
	
	@Query("SELECT T FROM Bil0101 T WHERE T.hospCode = :f_hosp_code AND T.parentInvoiceNo = :f_invoice_no AND T.activeFlg = 1 order by T.invoiceDate DESC")
	public List<Bil0101> findByHospCodeParentInvoiceNo(@Param("f_hosp_code") String hospCode, @Param("f_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0101 SET amountDebt = :amountDebt, updId = :updId, updated = :updDate, statusFlg = :statusFlg WHERE hospCode = :hosp_code AND invoiceNo = :invoice_no AND activeFlg = 1")
	public Integer updateAmountDebt(@Param("amountDebt") BigDecimal amountDebt,
			@Param("updId") String updId,
			@Param("updDate") Date updDate, 
			@Param("statusFlg") BigDecimal statusFlg,
			@Param("hosp_code") String hospCode,
			@Param("invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0101 SET amountDebt = :amountDebt, amountPaid = :amountPaid, updId = :updId, updated = :updDate, statusFlg = :statusFlg WHERE hospCode = :hosp_code AND parentInvoiceNo = :parentInvoiceNo AND activeFlg = 1")
	public Integer updateAmountPaidDebt(@Param("amountDebt") BigDecimal amountDebt,
			@Param("amountPaid") BigDecimal amountPaid,
			@Param("updId") String updId,
			@Param("updDate") Date updDate, 
			@Param("statusFlg") BigDecimal statusFlg,
			@Param("hosp_code") String hospCode,
			@Param("parentInvoiceNo") String parentInvoiceNo);
	
	
	@Query("SELECT T FROM Bil0101 T WHERE T.hospCode = :f_hosp_code  AND T.parentInvoiceNo = T.invoiceNo AND T.parentInvoiceNo = :parent_invoice_no AND T.activeFlg = 1 order by T.invoiceDate DESC")
	public List<Bil0101> findByHospCodeParentInvoiceEqualInvoice(@Param("f_hosp_code") String hospCode, @Param("parent_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0101 SET activeFlg = 0, updId = :userId, revertComment = :revertComment WHERE hospCode = :f_hosp_code AND invoiceNo = :f_invoice_no AND activeFlg = 1")
	public Integer deactiveInvoiceByInvoiceNo(@Param("userId") String userId, 
			@Param("revertComment") String revertComment, 
			@Param("f_hosp_code") String hospCode, 
			@Param("f_invoice_no") String invoiceNo);
	
	@Modifying
	@Query("UPDATE Bil0101 SET  amountDebt = :amountDebt, updId = :userId WHERE hospCode = :f_hosp_code AND parentInvoiceNo = :parent_invoice_no AND invoiceNo = parentInvoiceNo ")
	public Integer updateDebtByParentInvoiceEqualInvoice(@Param("amountDebt") BigDecimal amountDebt,
			@Param("userId") String userId, 
			@Param("f_hosp_code") String hospCode, 
			@Param("parent_invoice_no") String parentInvoiceNo);
	
	@Query("SELECT T FROM Bil0101 T WHERE T.hospCode = :f_hosp_code AND T.parentInvoiceNo = :parent_invoice_no order by T.created DESC")
	public List<Bil0101> findByParentInvoiceNoOrderByCreated(@Param("f_hosp_code") String hospCode, @Param("parent_invoice_no") String parentInvoiceNo);
}
