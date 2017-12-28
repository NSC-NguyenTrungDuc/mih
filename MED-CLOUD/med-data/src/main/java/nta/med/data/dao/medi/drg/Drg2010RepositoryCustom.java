package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderInfo;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderListInfo;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdPaidInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderListOutInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderOutInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01AutoJubsuListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01CurDrgOrderInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01DrgwonneaOWnCurListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01JungboListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LabelListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01NebokLabelListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderJungboListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderOrderListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01PaidOrderListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01WnSerialQryListItemInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcPatientInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;

/**
 * @author dainguyen.
 */
public interface Drg2010RepositoryCustom {
	
	public List<DrgsDRG5100P01OrderListItemInfo> getDrgsDRG5100P01OrderListItemInfo(String hospCode, String language, String orderDate, String drgBunho,
			String gubun, String wonyoiYn, String bunho);
	
	public List<DrgsDRG5100P01AutoJubsuListItemInfo> getDrgsDRG5100P01AutoJubsuListItemInfo(String hospitalCode, String gwa, 
			Date fromDate, Date toDate, String gubun, String wonyoiYn, String bunho);
	
	public List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> getDrgsDRG5100P01DrgwonneaOWnCurList(String hospCode, String language, String jubsuDate, String drgBunho);
	
	public List<DrgsDRG5100P01WnSerialQryListItemInfo> getDrgsDRG5100P01WnSerialQryListItem(String hospCode, String language, String jubsuDate, String drgBunho
			,String oSerialText);
	
	public String getDrgsDRG5100P01SetNumberRowInsert(String bogyongName);
	
	public String getDrgsDRG5100P01GetBogyongName(String bogyongName, String b);
	
	public List<DrgsDRG5100P01OrderJungboListItemInfo> getDrgsDRG5100P01OrderJungboListItem(String hospCode, String language, String jubsuDate, String drgBunho);
	                                                   
	public String getDrgsDRG5100P01SetBarDrgBunho(String hospCode, String jubsuDate, String drgBunho);
	
	public DrgsDRG5100P01JungboListInfo getDrgsDRG5100P01JungboListInfo(String hospCode, String bunho, String comments);
	
	public String getDrgsDRG5100P01CommentNumber(String iComment, String rowNumber);
	
	public List<DrgsDRG5100P01LabelListItemInfo> getDrgsDRG5100P01LabelListItemInfo(String hospitalCode, String language, String jubsuDate, String drgBunho);
	
	public List<DrgsDRG5100P01NebokLabelListItemInfo> getDrgsDRG5100P01NebokLabelListItemInfo(String hospitalCode, String language,
			String jubsuDate, String drgBunho, String bunho);
	
	public List<DrgsDRG5100P01PaidOrderListItemInfo> getDrgsDRG5100P01PaidListItemInfo(String hospitalCode, String gwa, 
			Date fromDate, Date toDate, String gubun, String wonyoiYn, String bunho, boolean isJubsu);
	
	public List<DrgsDRG5100P01OrderOrderListItemInfo> getDrgsDRG5100P01OrderOrderListItemInfo(String hospitalCode, String language, 
			String orderDate, String drgBunho, String gubun);
	public List<DRG0201U00GrdPaidInfo> getDrg0201u00GridPaidInfo(String hospitalCode, Date orderDate, String bunho, String gubun);
	
	public List<DrgsDRG5100P01CurDrgOrderInfo> getDrgsDRG5100P01CurDrgOrderInfo(String hospCode, String language, Double masterPk, String ioGubun);
	
	public List<DRG0201U00GrdOrderInfo> getDRG0201U00DetailServerCallInfo(String hospCode, String language, String jubsuDate, String bunho, String drgBunho,String hanlderName);
	
	public List<PrJihDrgIfsProcInfo> getPrJihDrgIfsProcOutInfo(String hospitalCode, Double fkdrg);
	
	public List<PrJihDrgIfsProcPatientInfo> getPrJihDrgIfsProcPatientOutInfo(String hospitalCode, String bunho, Double fkdrg);
	
	String callPrDrgUpdateChulgo(String hospCode, Date jubsuDate, Integer drgBunho, Date chulgoDate,
			String actUser, String chulgoBuseo, String wonyoiOrderYn, String actYn);
	public List<DRG0201U00GrdOrderListInfo> getDRG0201U00GrdOrderListInfo(String hospCode,String language,String jubsuDate,String drgBunho);
	
	public List<DRG9040U01GrdOrderListOutInfo> getDRG9040U01GrdOrderListOutInfo(String hospCode, String language, String orderDate, String drgBunho, String bunho);
	
	public List<DRG9040U01GrdOrderOutInfo> getDRG9040U01GrdOrderOutInfo(String hospCode, String language, String bunho, String fromDate, String toDate);

	public List<DataStringListItemInfo> getDRG3010P99layOutOrder(String hospCode, String fromDate, String toDate, String gubun,	String wonyoiYn, String gwa, String bunho);
}

