package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.ScreenTable;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPLMASTERUPLOADERPRCplBmlUploaderInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPLMASTERUPLOADERPRCplBmlUploaderRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class CPLMASTERUPLOADERPRCplBmlUploaderHandler extends ScreenHandler<CplsServiceProto.CPLMASTERUPLOADERPRCplBmlUploaderRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CPLMASTERUPLOADERPRCplBmlUploaderHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0001Repository cpl0001Repository;  
	@Resource
	private Bas0001Repository bas0001Repository;
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPLMASTERUPLOADERPRCplBmlUploaderRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
		List<CPLMASTERUPLOADERPRCplBmlUploaderInfo> listInfo = request.getUplItemList();
		LOGGER.info("CPLMASTERUPLOADERPRCplBmlUploaderHandler Info size : " + listInfo.size());
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = request.getUserId();
		String hangmogMarkName = null;
		String result = null;
		for(CPLMASTERUPLOADERPRCplBmlUploaderInfo item : listInfo){
			Integer serial = CommonUtils.parseInteger(item.getSerial());
			Date jukyongDate = DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD);
			
			if(!StringUtils.isEmpty(item.getHangmogCode()) && !StringUtils.isEmpty(item.getSpecimenCode()) && !StringUtils.isEmpty(item.getSpecimenName())){
				if(!StringUtils.isEmpty(item.getSpecimenAmt())){
					hangmogMarkName = item.getSpecimenAmt();
				}
			result = cpl0001Repository.callPrCplBmlUploader(hospCode, language, userId, item.getGroupGubun(), item.getParentCode(), item.getHangmogCode(), serial, item.getGumsaNameRe(), item.getGumsaName(),
					item.getJlac10Code(), item.getTubeName(), item.getKeepMeansName(), item.getSpecimenCode(), item.getSpecimenName(), item.getDanui(), 
					item.getMenFromStandard(), item.getMenToStandard(), item.getWomenFromStandard(), item.getWomenToStandard(),
					item.getSgCode1(), item.getSgCode2(), null, jukyongDate, item.getDetailInfo(), hangmogMarkName, item.getEmergency());
				
				if(StringUtils.isEmpty(result)){
					if(!StringUtils.isEmpty(item.getSpecimenCode2()) && !StringUtils.isEmpty(item.getSpecimenName2())){
					result = cpl0001Repository.callPrCplBmlUploader(hospCode, language, userId, item.getGroupGubun(), item.getParentCode(), item.getHangmogCode(), serial, item.getGumsaNameRe(), item.getGumsaName(),
							item.getJlac10Code(), item.getTubeName(), item.getKeepMeansName(), item.getSpecimenCode2(), item.getSpecimenName2(), item.getDanui(), 
							item.getMenFromStandard(), item.getMenToStandard(), item.getWomenFromStandard(), item.getWomenToStandard(),
							item.getSgCode1(), item.getSgCode2(), null, jukyongDate, item.getDetailInfo(), hangmogMarkName, item.getEmergency());
						if(!StringUtils.isEmpty(result)){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
				}else{
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		//update revision
		List<Bas0001> listBas0001 =  bas0001Repository.findLatestByHospCode("NTA");
		if(!CollectionUtils.isEmpty(listBas0001)){
			String oldRevision = listBas0001.get(0).getRevision();
			String newRevision = CommonUtils.getNewGlobalRevision(oldRevision, ScreenTable.CPL0101U00.getValue());
			Bas0001 bas0001 = listBas0001.get(0);
			bas0001.setRevision(newRevision);
			bas0001Repository.save(bas0001);
			
		}
		
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}