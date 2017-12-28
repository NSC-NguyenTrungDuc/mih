package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010U01SaveLayoutInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U01grdSpecimenInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01SaveLayoutRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01SaveLayoutResponse;

@Service
@Scope("prototype")
public class CPL2010U01SaveLayoutHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01SaveLayoutRequest, CplsServiceProto.CPL2010U01SaveLayoutResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(CPL2010U01SaveLayoutHandler.class);
	
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;      
	@Resource   
	private Cpl0109Repository cpl0109Repository;
	@Resource  
	private Adm3300Repository adm3300Repository;
	
	@Override
	@Transactional
	public CPL2010U01SaveLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01SaveLayoutRequest request) throws Exception {
		CplsServiceProto.CPL2010U01SaveLayoutResponse.Builder response = CplsServiceProto.CPL2010U01SaveLayoutResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		CPL2010U01SaveLayoutInfo info = saveLayout(request, hospCode, language, userId);
		response.setResult(info.isSaveResult());
		response.setParentJubsuCnt(String.valueOf(info.getJubsuCnt()));
		response.setParentCancelCnt(String.valueOf(info.getCancelCnt()));
		response.setParentMerrmsg(info.getMsg() == null ? "" : info.getMsg());
		
		if(!info.isSaveResult()){
			LOGGER.info(String.format("Save Fail, hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		if (info.getJubsuCnt() > 0) {
			String ioFlag = cpl2010Repository.callCPL2010U00PrCplMakeSpecimenSer(hospCode
					, language
					, DateUtil.toDate(request.getIOrderDate(), DateUtil.PATTERN_YYMMDD)
					, request.getIBunho(), request.getIJubsuja(), "Y", ""
					, DateUtil.toDate(request.getIJubsuDate(), DateUtil.PATTERN_YYMMDD)
					, request.getIJubsuTime());
			response.setParentOFlag(ioFlag);
			
			if ("N".equalsIgnoreCase(ioFlag)) {
				response.setResult(false);
				response.setParentMerrmsg("MSG_002");
				LOGGER.info(String.format("Execute procedure PR_CPL_MAKE_SPECIMEN_SER fail, hosp_code = %s, message = MSG_002", hospCode));
			}
		}
		
		response.setResult(true);
		response.setParentJubsuCnt(String.valueOf(info.getJubsuCnt()));
		response.setParentCancelCnt(String.valueOf(info.getCancelCnt()));
		
		return response.build();
	}
	
	private CPL2010U01SaveLayoutInfo saveLayout(CplsServiceProto.CPL2010U01SaveLayoutRequest request, String hospCode, String language, String userId) {
		CPL2010U01SaveLayoutInfo saveInfo = new CPL2010U01SaveLayoutInfo();
		List<CplsModelProto.CPL2010U01grdSpecimenInfo> listInfo = request.getGrdspecimenList();
		if(CollectionUtils.isEmpty(listInfo)){
			saveInfo.setSaveResult(false);
			saveInfo.setJubsuCnt(0);
			saveInfo.setCancelCnt(0);
			return saveInfo;
		}
		
		int jubsuCnt = 0;
		int cancelCnt = 0;
		
		for (CPL2010U01grdSpecimenInfo item : listInfo) {
			if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				Double result = cpl2010Repository.getCPL3010U00GrdGumQueryEnd(hospCode, CommonUtils.parseDouble(item.getPkcpl2010()));
				if(result == null){
					LOGGER.info(String.format("Could not find data in CPL2010: hosp_code = %s, pkcpl2010 = %s", hospCode, item.getPkcpl2010()));
					saveInfo.setSaveResult(false);
					saveInfo.setJubsuCnt(jubsuCnt);
					saveInfo.setCancelCnt(cancelCnt);
					return saveInfo;
				}
				
				if ("Y".equals(item.getJubsuFlag())) {
					jubsuCnt++;
					if(cpl2010Repository.updateCpl2010ExecuteUpdate(userId,
							"Y", new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))>0){
						saveInfo.setSaveResult(true);
					}else{
						saveInfo.setSaveResult(false);
						saveInfo.setJubsuCnt(jubsuCnt);
						saveInfo.setCancelCnt(cancelCnt);
						return saveInfo;
					}
				} else if ("N".equals(item.getJubsuFlag())) {
					String oFlag2 = cpl2010Repository.getCPL2010U00ExecuteGetYValue(hospCode, CommonUtils.parseDouble(item.getPkcpl2010()));
					
					if ("Y".equals(oFlag2)) {
						cancelCnt++;
						String flag = cpl2010Repository.getNValueByPkcpl2010AndpartJubsuDateNotNull(hospCode, CommonUtils.parseDouble(item.getPkcpl2010()));
						if(!StringUtils.isEmpty(flag)){
							saveInfo.setoFlag(flag);
							if("N".equals(flag)){
								saveInfo.setSaveResult(false);
								saveInfo.setMsg("MSG_001");
								saveInfo.setJubsuCnt(jubsuCnt);
								saveInfo.setCancelCnt(cancelCnt);
								return saveInfo;
							}
						}
						
						if(cpl2010Repository.updateCpl2010ExecuteUpdate(userId,
								"N", new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))<=0){
							saveInfo.setSaveResult(false);
							saveInfo.setJubsuCnt(jubsuCnt);
							saveInfo.setCancelCnt(cancelCnt);
							return saveInfo;
						}
						
						String ioFlag = cpl2010Repository.callCPL2010U00PrCplMakeSpecimenSer(hospCode
								, language
								, DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD)
								, item.getBunho()
								, item.getJubsuja()
								, "N"
								, ""
								, DateUtil.toDate(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD)
								, item.getJubsuTime());
						
						if(!StringUtils.isEmpty(ioFlag)){
							if(ioFlag.equalsIgnoreCase("N")){
								saveInfo.setSaveResult(false);
								saveInfo.setMsg("MSG_001");
								saveInfo.setJubsuCnt(jubsuCnt);
								saveInfo.setCancelCnt(cancelCnt);
								return saveInfo;
							}
						}
						
						if(cpl2010Repository.updateCpl2010ExecuteUpdate(userId,
								null, new Date(), hospCode, CommonUtils.parseDouble(item.getPkcpl2010()))<=0){
							saveInfo.setSaveResult(false);
							saveInfo.setJubsuCnt(jubsuCnt);
							saveInfo.setCancelCnt(cancelCnt);
							return saveInfo;
						}
					}
				}
			}
		}
		
		saveInfo.setSaveResult(true);
		saveInfo.setJubsuCnt(jubsuCnt);
		saveInfo.setCancelCnt(cancelCnt);
		return saveInfo;
	}
}
