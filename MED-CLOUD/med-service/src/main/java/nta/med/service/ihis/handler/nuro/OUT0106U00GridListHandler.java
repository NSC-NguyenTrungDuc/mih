package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.dao.medi.out.Out0113Repository;
import nta.med.data.model.ihis.nuro.OUT0106U00GridItemInfo;
import nta.med.data.model.ihis.nuro.OUT0106U00PatientCommentItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OUT0106U00GridListHandler extends ScreenHandler<NuroServiceProto.OUT0106U00GridListRequest, NuroServiceProto.OUT0106U00GridListResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(OUT0106U00GridListHandler.class);                                        
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;   
	@Resource                                                                                                       
	private Out0113Repository out0113Repository;      

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0106U00GridListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0106U00GridListRequest request) throws Exception {
		NuroServiceProto.OUT0106U00GridListResponse.Builder response = NuroServiceProto.OUT0106U00GridListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<OUT0106U00GridItemInfo> listItem = out0106Repository.getOUT0106U00GridItemInfo(hospCode, request.getBunho());
		if(!CollectionUtils.isEmpty(listItem)){
			for(OUT0106U00GridItemInfo item : listItem){
				NuroModelProto.OUT0106U00GridItemInfo.Builder info = NuroModelProto.OUT0106U00GridItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGridItemInfo(info);
			}
		}
		
		List<OUT0106U00PatientCommentItemInfo> listPatientCommen = out0113Repository.getOUT0106U00PatientCommentItemInfo(hospCode, request.getBunho(), request.getNaewonDate());
		if(!CollectionUtils.isEmpty(listPatientCommen)){
			for(OUT0106U00PatientCommentItemInfo item : listPatientCommen){
				NuroModelProto.OUT0106U00PatientCommentItemInfo.Builder info = NuroModelProto.OUT0106U00PatientCommentItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addPatientCommentItemInfo(info);
			}
		}
		return response.build();
	}    

}
