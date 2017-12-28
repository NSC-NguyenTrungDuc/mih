package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010U00SaveLayoutInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01ChkbStateHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U00GrdSpecimenListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00SaveLayoutRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00SaveLayoutResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010U00SaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL2010U00SaveLayoutRequest, CplsServiceProto.CPL2010U00SaveLayoutResponse> {   
	private static final Log LOG = LogFactory.getLog(CPL2010U00SaveLayoutHandler.class);
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;      
	@Resource   
	private Cpl0109Repository cpl0109Repository;
	@Resource  
	private Adm3300Repository adm3300Repository;
	                                                                                                                
	@Override                                                                                                       
	public CPL2010U00SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00SaveLayoutRequest request) {
      	   	CplsServiceProto.CPL2010U00SaveLayoutResponse.Builder response = CplsServiceProto.CPL2010U00SaveLayoutResponse.newBuilder();
		try {
			String hospCode = getHospitalCode(vertx, sessionId);
			String language = getLanguage(vertx, sessionId);
			CPL2010U00SaveLayoutInfo saveLayout = saveLayout(request, hospCode, language);
			// step 2
			if (saveLayout.isSave()) {
				if (saveLayout.getJubsuCnt() > 0) {
					String ioFlag = cpl2010Repository.callCPL2010U00PrCplMakeSpecimenSer(hospCode, language,
							DateUtil.toDate(request.getOrderDatePr1(), DateUtil.PATTERN_YYMMDD), request.getBunhoPr1(), request.getJubsujaPr1(), "Y", "",
							DateUtil.toDate(request.getJubsuDatePr1(), DateUtil.PATTERN_YYMMDD), request.getJubsuTimePr1());
					if (!StringUtils.isEmpty(ioFlag)) {
						if (ioFlag.equalsIgnoreCase("N")) {
							response.setWholeResult(false);
							LOG.warn("CPL2010U00SaveLayoutHandler not pass callCPL2010U00PrCplMakeSpecimenSer");
							throw new ExecutionException(response.build());
						}
					}
				}
			}
			// print Name
			String result = adm3300Repository.getLayPrintName(hospCode, request.getIpAddr());
			if (!StringUtils.isEmpty(result)) {
				response.setPrintName(result);
			}
			//param rbxMijubsu
			if (request.getRbxMijubsuChecked()) {
				//list lay bar code
				List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcodeTemp = cpl2010Repository.getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo(
						hospCode, language, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD), request.getBunho());
				if (!CollectionUtils.isEmpty(listLayBarcodeTemp)) {
					for (CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo obj : listLayBarcodeTemp) {
						CplsModelProto.CPL2010U00LayBarcodeTempListItemInfo.Builder info = CplsModelProto.CPL2010U00LayBarcodeTempListItemInfo.newBuilder();
						BeanUtils.copyProperties(obj, info, getLanguage(vertx, sessionId));
						response.addLayBarcodeTempList(info);
					}
				}

				List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcode = layBarCodeTempQueryEnd(listLayBarcodeTemp, request.getJubsuDate(), request.getBunho(), hospCode);

				if (!CollectionUtils.isEmpty(listLayBarcode)) {
					for (CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo layBarcodeOne : listLayBarcode) {
						String strCMD = cpl0109Repository.getCheckItemGrdDetail(hospCode, layBarcodeOne.getSpecimenCode(), "20", getLanguage(vertx, sessionId));
						if (StringUtils.isEmpty(strCMD)) {
							String ioFlg = cpl2010Repository.callCPL2010U00PrCplPartJubsu(hospCode, layBarcodeOne.getSpecimenSer(), layBarcodeOne.getJundalGubun(),
									DateUtil.toDate(request.getPartJubsuDatePr2(), DateUtil.PATTERN_YYMMDD), request.getPartJubsuTimePr2(), request.getPartJubsujaPr2(), request.getUserIdPr2());
							if (StringUtils.isEmpty(ioFlg)) {
								throw new ExecutionException(response.build());
							}
						}
					}
				}
			}
		} catch (Exception e) {
			response.setWholeResult(false);
			LOG.warn("CPL2010U00SaveLayoutHandler : " + e.getMessage());
			throw new ExecutionException(response.build());
		}

		response.setWholeResult(true);
		return response.build();
	}

	public List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> layBarCodeTempQueryEnd(List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> list, String jubsuDate, String bunho, String hospCode){
		 int tubeCount  = 0;
		 List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcode = new ArrayList<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo>();
		 if(!CollectionUtils.isEmpty(list)){
			 for(CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo layBarCodeInfo : list){
				 tubeCount = Integer.parseInt(layBarCodeInfo.getTubeCount());
				 for (int j = 0; j < tubeCount; j++) {
					 CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo info = new CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo(layBarCodeInfo.getJundalGubun(),
							 layBarCodeInfo.getJundalGubunName(),layBarCodeInfo.getSpecimenCode(),layBarCodeInfo.getSpecimenName(),layBarCodeInfo.getTubeCode(),
							 layBarCodeInfo.getTubeName(),layBarCodeInfo.getInOutGubun(),layBarCodeInfo.getSpecimenSer(),layBarCodeInfo.getBunho(),
							 layBarCodeInfo.getSuname(),layBarCodeInfo.getGwaName(),layBarCodeInfo.getDangerYn(),layBarCodeInfo.getSpecimenSerBa(),
							 layBarCodeInfo.getJangbiCode(),layBarCodeInfo.getJangbiName(),layBarCodeInfo.getGumsaNameRe(),layBarCodeInfo.getTubeCount(),
							 layBarCodeInfo.getTubeMaxAmt(),layBarCodeInfo.getTubeNumbering());
					 listLayBarcode.add(info);
				}
			 }
			 
			 if(cpl2010Repository.updateCpl2010LayBarcodeTempQueryEnd(hospCode,jubsuDate, bunho) <= 0){
				 throw new ExecutionException();
			 }
		 }
		 return listLayBarcode;
	}
       
	public CPL2010U00SaveLayoutInfo saveLayout(CplsServiceProto.CPL2010U00SaveLayoutRequest request, String hospCode, String language){
		boolean saveLayout = false;
		Integer jubsu_cnt = 0;
		//save layout
		if(!CollectionUtils.isEmpty(request.getInputListList())){
			for(CPL2010U00GrdSpecimenListItemInfo item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					Double result = cpl2010Repository.getCPL3010U00GrdGumQueryEnd(hospCode, CommonUtils.parseDouble(item.getPkcpl2010()));
					if(result != null){
						if(item.getJubsuFlag().equalsIgnoreCase("Y")){
							jubsu_cnt = 1;
							if(cpl2010Repository.updateCpl2010ExecuteUpdate(request.getUserId(),
									"Y", new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))>0){
								saveLayout = true;
							}else{
								throw new ExecutionException();
							}
						}else if(item.getJubsuFlag().equalsIgnoreCase("N")){
							String oFlag2 = cpl2010Repository.getCPL2010U00ExecuteGetYValue(hospCode, CommonUtils.parseDouble(item.getPkcpl2010()));
							if(!StringUtils.isEmpty(oFlag2)){
								if(cpl2010Repository.updateCpl2010ExecuteUpdate(request.getUserId(),
										"N", new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))<=0){
									throw new ExecutionException();
								}
								
								String ioFlag = cpl2010Repository.callCPL2010U00PrCplMakeSpecimenSer(hospCode, language,
										DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD),item.getBunho(), item.getJubsuja(), "N", "", 
										DateUtil.toDate(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD), item.getJubsuTime());
								if(!StringUtils.isEmpty(ioFlag)){
									if(ioFlag.equalsIgnoreCase("N")){
										throw new ExecutionException();
									}
								}
								if(cpl2010Repository.updateCpl2010ExecuteUpdate(request.getUserId(),
										null, new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))<=0){
									throw new ExecutionException();
								}
							}
							saveLayout = true;
						}
					}
				}
				
			}
		}
		CPL2010U00SaveLayoutInfo info = new CPL2010U00SaveLayoutInfo(saveLayout, jubsu_cnt);
		return info;
	}
}