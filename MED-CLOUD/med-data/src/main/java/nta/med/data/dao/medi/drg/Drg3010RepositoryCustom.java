package nta.med.data.dao.medi.drg;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaLabel1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaLabel2Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint1Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint2Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint3Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint4Info;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint3Info;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdDrgBunhoInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdJusaDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamJusaOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamPaQueryInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaJuOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMiMaOrdInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdPaDcInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdPaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10LayOrderJungboInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaCurInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaKInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaLabelInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaSerialInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnCurInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnRemarkInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnSerialInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99PaPrnInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99SerRemarkInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexBarcodeInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdJusaDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdListInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdMagamOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdMiMagamJusaOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPaDcListInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdPrnJusaInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99layOrderBarcodeInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99layOrderJungboInfo;
import nta.med.data.model.ihis.drgs.DRG3010Q12grdPalistInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05LabelInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05SerialInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06LabelInfo;
import nta.med.data.model.ihis.drgs.DRG3041P06SerialInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdJUSAOrderListInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderInfo;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01CurDrgOrderInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcPatientInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03getSysInfo;
import nta.med.data.model.ihis.ocsi.OCS2003U03orderJungboInfo;

/**
 * @author dainguyen.
 */
public interface Drg3010RepositoryCustom {
	public List<DrgsDRG5100P01CurDrgOrderInfo> getDrgsDRG5100P01CurDrgOrderInfo(String hospCode, String language, 
			Double masterPk, String ioGubun);

	public List<PrJihDrgIfsProcPatientInfo> getPrJihDrgIfsProcPatientInInfo(String hospitalCode,
			String bunho, Double fkdrg);

	public List<PrJihDrgIfsProcInfo> getPrJihDrgIfsProcInInfo(String hospitalCode, Double fkdrg);
	
	public List<DRG9040U01GrdJUSAOrderListInfo> getDRG9040U01GrdJUSAOrderListInfo(String hospCode, String language, String jubsuDate, String drgBunho, String magambunryu);
	
	public List<DRG9040U01GrdOrderInfo> getDRG9040U01GrdOrderInfo(String hospCode, String bunho, String fromDate, String toDate);
	
	public List<DRG9040U01GrdOrderListInfo> getDRG9040U01GrdOrderListInfo(String hospCode, String language, String jubsuDate, String drgBunho, String magambunryu);
	public List<OCS2003U03getJusaInfo> getOCS2003U03getJusaInfo(String hospCode, String language, String serialText, String JubsuDate, String drgBunho, boolean isGetRemark);
	public List<OCS2003U03getJusaInfo> getOCS2003U03getJusaInfoExt(String hospCode, String language, String serialV, String fkocs2003);
	public List<OCS2003U03orderJungboInfo> getOCS2003U03orderJungboInfo(String hospCode, String language, String jubsuDate, String drgBunho);
	public String getOCS2003U03getTocheckInfo(String hospCode, String jubsuDate, String drgBunho);
	public List<OCS2003U03getSysInfo> getOCS2003U03getSysInfo(String hospCode, String bunho, String comments);
	public ComboListItemInfo callPrDrgInpMagamProc(String hospCode, String procGubun, String jubsuDate, String orderDate, String hopeDate, String magamGubun, String magamSer, String bunho, String doctor, String magamUser);
	public String callFnDrgToiwonOrderChk(String hospCode, String toiwonDate, String bunho, String fkinp1001);
	
	public List<DRG3010Q12grdPalistInfo> getDRG3010Q12grdPalistInfo(String hospCode, String hoDong);
	public List<ComboListItemInfo> getHoDongGwaName(String hospCode, String language);

	public List<DRG3010P99grdDcOrderInfo> getDRG3010P99grdDcOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, String bunho, Integer startNum, Integer offset);

	public List<DRG3010P99grdJusaDcOrderInfo> getDRG3010P99grdJusaDcOrderInfo(String hospCode, String language,	String jubsuDate, Double drgBunho, String bunho, Integer startNum, Integer offset);

	public List<DRG3010P99grdListInfo> getDRG3010P99grdListInfo(String hospCode, String language, String hoDong, String bunho, String fromDate, String toDate, String magamGubun, Integer startNum, Integer offset);

	public List<DRG3010P99grdJusaDcOrderInfo> getDRG3010P99grdMagamJusaOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, Integer startNum, Integer offset);

	public List<DRG3010P99grdMagamOrderInfo> getDRG3010P99grdMagamOrderInfo(String hospCode, String language, String jubsuDate, Double drgBunho, Integer startNum, Integer offset);

	public List<DRG3010P99grdMiMagamJusaOrderInfo> getDRG3010P99grdMiMagamJusaOrderInfo(String hospCode, String language, String orderDate, String hopeDate, String bunho, 
			String hoDong, String resident, String magamGubun, Integer startNum, Integer offset, boolean isJusa);

	public List<DRG3010P99grdPaDcListInfo> getDRG3010P99grdPaDcListInfo(String hospCode, String language, String hoDong, String bunho, String fromDate, String toDate, String magamGubun, Integer startNum, Integer offset);

	public List<DRG3010P99PaPrnInfo> getDRG3010P99PaPrnInfo(String hospCode, String language, String hoDong, String fromDate, String toDate, Integer startNum, Integer offset);

	public List<DRG3010P99grdPaInfo> getDRG3010P99grdPaInfo(String hospCode, String language, String bunho, String fromDate, String toDate, String magamGubun, String hoDong, Integer startNum, Integer offset);

	public List<DRG3010P99grdPrnJusaInfo> getDRG3010P99grdPrnJusaInfo(String hospCode, String language, String hoDong, String orderDate, String hopeDate, String hopeTime, 
			String bunho, String resident, String emergency, Integer startNum, Integer offset);

	public List<DRG3010P99grdPrnJusaInfo> getDRG3010P99grdPrnInfo(String hospCode, String language, String hoDong, String orderDate, String hopeDate, String hopeTime, 
			String bunho, String resident, String emergency, Integer startNum, Integer offset);
	
	public List<DRG3041P06LabelInfo> getDRG3041P06LabelDataInfo(String hospCode, String language, String jubsuDate, String drgBunho, String rp);
	
	public List<DRG3041P06SerialInfo> getDRG3041P06SerialInfo(String hospCode, String language, String k, String cnt, String jubsuDate, String drgBunho, String serialText);
	
	public List<DRG3041P05LabelInfo> getDRG3041P05LabelInfo(String hospCode, String language, String jubsuDate, String drgBunho, String rp);
	
	public List<DRG3041P05SerialInfo> getDRG3041P05SerialInfo(String hospCode, String language, String k, String cnt, String jubsuDate, String drgBunho, String serialText);
	
	public List<DRG3010P10GrdDcOrderInfo> getDRG3010P10GrdDcOrderInfo(String hospCode, String language, Date jusuDate, Double drgBunho, String bunho, String magamBunryu);
	
	public List<DRG3010P10GrdDrgBunhoInfo> getDRG3010P10GrdDrgBunhoInfo(String hospCode, String language, String magamDate, String magamSer,
			String magamGubun, String hoDong, String magamBunryu);
	
	public List<DRG3010P10GrdJusaDcOrderInfo> getDRG3010P10GrdJusaDcOrderInfo(String hospCode, String language,
			String jubsuDate, String drgBunho, String bunho, String magamBunryu);

	public List<DRG3010P10GrdMagamJusaOrdInfo> getDRG3010P10GrdMagamJusaOrdInfo(String hospCode, String language, String jubsuDate, String drgBunho);
	
	public List<DRG3010P99OrdPrnCurInfo> getDRG3010P99OrdPrnCurInfo(String hospCode, String language, String jubsuDate,	Double drgBunho);

	public List<DRG3010P99OrdPrnSerialInfo> getDRG3010P99SerialvInfo(String hospCode, String language, Double sourceFkocs2003, String serialV);

	public List<DRG3010P99OrdPrnRemarkInfo> getDRG3010P99OrdPrnRemarkInfo(String hospCode, String language, String jubsuDate, Double drgBunho, String serialText);

	public List<DRG3010P99layOrderJungboInfo> getDRG3010P99layOrderJungboInfo(String hospCode, String language,	Double drgBunho, String jubsuDate);

	public String DRG3010P99getBarDrgBunho(String hospCode, String jubsuDate, Double drgBunho);

	public List<DRG3010P99getBodyIndexInfo> getDRG3010P99getBodyIndexInfo(String hospCode, String bunho, String comment);

	public List<DRG3010P99layOrderBarcodeInfo> getDRG3010P99layOrderBarcodeInfo(String hospCode, Double drgBunho, String jubsuDate);

	public List<DRG3010P99getBodyIndexBarcodeInfo> getDRG3010P99getBodyIndexBarcodeInfo(String hospCode, String bunho);

	public List<DRG3010P99JusaCurInfo> getDRG3010P99JusaCurInfo(String hospCode, String language, String jubsuDate,  Double drgBunho);

	public List<DRG3010P10GrdMagamOrdInfo> getDRG3010P10GrdMagamOrdInfo(String hospCode, String language, String jubsuDate, String drgBunho);
	
	public List<DRG3010P10GrdMagamPaQueryInfo> getDRG3010P10GrdMagamPaQueryInfo(String hospCode,
			String fromDate, String toDate, String hoDong, String bunho, String magamGubun, String pageNumber, String offset);
	
	public List<DRG3010P10GrdMiMaJuOrdInfo> getDRG3010P10GrdMiMaJuOrdInfo(String hospCode, String language, String orderDate, String bunho,
			String hopeDate, String hoDong, String doctor, String magamGubun, String magamBunryu, String pageNumber, String offset);
	
	public List<DRG3010P10GrdMiMaOrdInfo> getDRG3010P10GrdMiMaOrdInfo(String hospCode, String language,
			String orderDate, String bunho, String hopeDate, String hoDong, String doctor, String magamGubun, String magamBunryu);
	
	public List<DataStringListItemInfo> getDRG3010P99getFkocs2003Info(String hospCode, Double drgBunho, String jubsuDate);
	public List<DRG3010P10DsvJusaOrderPrint1Info> getDRG3010P10DsvJusaOrderPrint1Info(String hospCode, String language, String jubsuDate, String drgBunho);
	public List<DRG3010P10DsvJusaOrderPrint2Info> getDRG3010P10DsvJusaOrderPrint2Info(String hospCode, String language, String jubsuDate, String drgBunho, String serialText);
	public List<DRG3010P10DsvJusaOrderPrint3Info> getDRG3010P10DsvJusaOrderPrint3Info(String hospCode, String language, String serialV, String fkocs2003);
	public List<DRG3010P10DsvJusaOrderPrint4Info> getDRG3010P10DsvJusaOrderPrint4Info(String hospCode, String jubsuDate, String drgBunho, String serialText);
	public List<DRG3010P10DsvJusaLabel1Info> getDRG3010P10DsvJusaLabel1Info(String hospCode, String language, String jubsuDate, String drgBunho);
	public List<DRG3010P10DsvJusaLabel2Info> getDRG3010P10DsvJusaLabel2Info(String hospCode, String language, String k, String cnt, String jubsuDate, String drgBunho, String serialText, boolean is2);
	

	public List<DRG3010P99JusaSerialInfo> getDRG3010P99JusaSerialInfo(String hospCode, String language, String jubsuDate, String serialText, Double drgBunho);

	public List<DRG3010P99JusaSerialInfo> getDRG3010P99JusaserialvInfo(String hospCode, String language, String serialV, Double fkocs2003);

	public List<DRG3010P99SerRemarkInfo> getDRG3010P99SerRemarkInfo(String hospCode, String jubsuDate, Double drgBunho, String serialText);

	public List<DRG3010P99JusaLabelInfo> getDRG3010P99JusaLabelInfo(String hospCode, String language, String jubsuDate, Double drgBunho);

	public List<DRG3010P99JusaKInfo> getDRG3010P99JusaKInfo(String hospCode, String language, String k, String cnt, String serialText, String jubsuDate, Double drgBunho, String dataGubun);

	public String getDRG3010P99CheckDetailMaxActing(String hospCode, Double fkocs2003);

	public String getDRG3010P99FnDrgChulgoDate(String hospCode, String bunho, String orderDate, String ioGubun);

	public String getDRG3010P99MaxSeq(String hospCode, Double drgBunho, String jubsuDate, String ioGubun);

	public Integer DRG3010P99UpdateDrg3010Fkjihkey(String hospCode, Double fkjihkey, String jubsuDate, Double drgBunho,	String bunho, String mode);

	public Integer DRG3010P99UpdateDrg3010PowderYn(String hospCode, Double fkocs2003, String powderYn);

	public Integer DRG3010P99UpdateDrg3010DrgPackYn(String hospCode, Double fkocs2003, String drgPackYn);

	public Integer DRG3010P99UpdateDrg3010fkDrg4010(String hospCode, Double pkdrg4010, String jubsuDate, Double drgBunho, String bunho);

	public Integer DRG3010P99UpdateDrg3010ReUseYn(String hospCode, Double fkocs2003, String reUseYn);

	public String getDRG3010P99getYOrderGubun(String hospCode, Double drgBunho, String jubsuDate, String bunho, String orderGubun);

	public List<DRG3010P10GrdPaDcInfo> getDRG3010P10GrdPaDcInfo(String hospCode, String language,
			String bunho, String hoDong, String fromDate, String toDate, String magamGubun, String magamBunryu);

	public List<DRG3010P10GrdPaInfo> getDRG3010P10GrdPaInfo(String hospCode, String language,
			String fromDate, String toDate, String bunho, String hoDong, String magamGubun, String magamBunryu);

	public List<DRG3010P10LayOrderJungboInfo> getDRG3010P10LayOrderJungboInfo(String hospCode, String jubsuDate, String drgBunho);
	
	public ComboListItemInfo callPrMakeBongtuInp(String hospCode, String jubsuDate, String bunho, String hopeDate,
			String hopeTime, String gwa, String doctor, String jusaYn, String chulgoBuseo, String userId);

	public String callPrDrgLoadPrintGubun(String hospCode, String drgBunho, String jubsuDate, String printGubun);
	
	public List<DRG3010P10DsvOrderPrint3Info> getDRG3010P10DsvOrderPrint3Info(String hospCode, String language, String serialV, String fkocs2003);

}

