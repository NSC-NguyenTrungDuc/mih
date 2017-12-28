package nta.med.data.dao.medi.bil;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bill.BIL2016U01LoadPatientInfo;
import nta.med.data.model.ihis.bill.BIL2016U02PrintAmountInfo;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02SumInfo;
import nta.med.data.model.ihis.bill.LoadGridPayHistoryBIL2016U02Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public interface Bil0101RepositoryCustom {
	
	public List<ComboListItemInfo> getTotalAmount(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo);
	public List<BIL2016U01LoadPatientInfo> getPaidTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo);
	public List<BIL2016U01LoadPatientInfo> getCancelTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo);
	public List<BIL2016U01LoadPatientInfo> getUnCompletedTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo);
	public List<LoadGridBIL2016U02Info> getInvoiceDetailList(String hospCode, String invoiceNo, boolean isActive);
	public List<LoadGridBIL2016U02Info> getInvoiceUnPayDetailList(String hospCode, String language, String bunho, Double fkout1001, String bunhoType);
	public List<String> getLasteInvoiceBIL2016U02(String hospCode, String parentInvoiceNo);
	public List<LoadGridPayHistoryBIL2016U02Info> getLoadGridPayHistoryBIL2016U02Info(String hospCode, String parentInvoiceNo);
	public List<LoadGridBIL2016U02SumInfo> getLoadGridBIL2016U02SumInfoByParentInvoiceNo(String hospCode, String parentInvoiceNo);
	public List<LoadGridBIL2016U02SumInfo> getLoadGridBIL2016U02SumInfoByInvoiceNo(String hospCode, String parentInvoiceNo);
	public BigDecimal getLasteDebtBIL2016U02(String hospCode, String parentInvoiceNo);
	public BIL2016U02PrintAmountInfo getBIL2016U02PrintMoneyInfo(String hospCode, String parentInvoiceNo, String invoiceNo);
}
