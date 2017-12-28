package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.data.dao.medi.pfe.Pfe1000Repository;
import nta.med.data.model.ihis.endo.END1001U02DsvDwInfo;
import nta.med.data.model.ihis.endo.END1001U02DsvLDOCS0801Info;
import nta.med.data.model.ihis.endo.END1001U02GrdPurposeInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02OnLoadRequest;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02OnLoadResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02OnLoadHandler extends ScreenHandler<EndoServiceProto.END1001U02OnLoadRequest, EndoServiceProto.END1001U02OnLoadResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02OnLoadHandler.class);                                    
	@Resource                                                                                                       
	private Pfe1000Repository pfe1000Repository;        
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;
	@Resource
	private Pfe0102Repository pfe0102Repository;
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;   
	@Resource                                                                                                       
	private Ocs1801Repository ocs1801Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public END1001U02OnLoadResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, END1001U02OnLoadRequest request)
			throws Exception {
		EndoServiceProto.END1001U02OnLoadResponse.Builder response = EndoServiceProto.END1001U02OnLoadResponse.newBuilder();
		Double fkocs = CommonUtils.parseDouble(request.getFkocs());
		//END1001U02DsvDwInfo 
		List<END1001U02DsvDwInfo> listDsvDw = pfe1000Repository.getEND1001U02DsvDwInfo(getHospitalCode(vertx, sessionId), fkocs);
		if(!CollectionUtils.isEmpty(listDsvDw)){
			for(END1001U02DsvDwInfo item : listDsvDw){
				EndoModelProto.END1001U02DsvDwInfo.Builder info = EndoModelProto.END1001U02DsvDwInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOnloadDsvdwItem(info);
			}
		}
		//END1001U02StrInfo 
		List<String> list2S = ocs0103Repository.getHangmogNameByHospCodeAndHangmogCode(getHospitalCode(vertx, sessionId), request.getCode());
		if(!CollectionUtils.isEmpty(list2S)){
			for(String item : list2S){
				EndoModelProto.END1001U02StrInfo.Builder info = EndoModelProto.END1001U02StrInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setValue(item);
				}
				response.addOnloadDsvgumsanameItem(info);
			}
		}
		//END1001U02GrdPurposeInfo 
		List<END1001U02GrdPurposeInfo> listGrdPurpose = pfe0102Repository.getEND1001U02GrdPurposeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrdPurpose)){
			for(END1001U02GrdPurposeInfo item : listGrdPurpose){
				EndoModelProto.END1001U02GrdPurposeInfo.Builder info = EndoModelProto.END1001U02GrdPurposeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addOnloadGrdpurposeItem(info);
			}
		}
		//END1001U02DsvLDOCS0801Info 
		List<END1001U02DsvLDOCS0801Info> listDsvlDocs0801 = ocs0801Repository.getEND1001U02DsvLDOCS0801Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId) , request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listDsvlDocs0801)){
			for(END1001U02DsvLDOCS0801Info item : listDsvlDocs0801){
				EndoModelProto.END1001U02DsvLDOCS0801Info.Builder info = EndoModelProto.END1001U02DsvLDOCS0801Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addOnloadDsvldocs0801Item(info);
			}
		}
		//END1001U02GrdPaStatusInfo 
		List<XRT1002U00GrdPaStatusInfo> listResult = ocs1801Repository.getXRT1002U00GrdPaStatusInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(XRT1002U00GrdPaStatusInfo item : listResult){
				EndoModelProto.END1001U02GrdPaStatusInfo .Builder info = EndoModelProto.END1001U02GrdPaStatusInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addOnloadGrdpastatusItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}