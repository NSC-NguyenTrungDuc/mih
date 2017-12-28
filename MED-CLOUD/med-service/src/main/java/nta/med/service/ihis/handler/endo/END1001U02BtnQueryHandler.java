package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.dao.medi.pfe.Pfe1000Repository;
import nta.med.data.model.ihis.endo.END1001U02DsvDwInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02BtnQueryRequest;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02BtnQueryResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02BtnQueryHandler extends ScreenHandler<EndoServiceProto.END1001U02BtnQueryRequest, EndoServiceProto.END1001U02BtnQueryResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(END1001U02BtnQueryHandler.class);                                    
	@Resource                                                                                                       
	private Pfe1000Repository pfe1000Repository; 
	@Resource
	private Ocs1801Repository ocs1801Repository;

	@Override
	@Transactional(readOnly = true)
	public END1001U02BtnQueryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, END1001U02BtnQueryRequest request)
			throws Exception {
		EndoServiceProto.END1001U02BtnQueryResponse.Builder response = EndoServiceProto.END1001U02BtnQueryResponse.newBuilder();
		//END1001U02DsvDwInfo
		Double fkocs = CommonUtils.parseDouble(request.getFkocs());
		List<END1001U02DsvDwInfo> listDsDw = pfe1000Repository.getEND1001U02DsvDwInfo(getHospitalCode(vertx, sessionId), fkocs);
		if(!CollectionUtils.isEmpty(listDsDw)){
			for(END1001U02DsvDwInfo item : listDsDw){
				EndoModelProto.END1001U02DsvDwInfo.Builder info = EndoModelProto.END1001U02DsvDwInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDsvdwItem(info);
			}
		}
		//XRT1002U00GrdPaStatusInfo
		List<XRT1002U00GrdPaStatusInfo> listResult = ocs1801Repository.getXRT1002U00GrdPaStatusInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(XRT1002U00GrdPaStatusInfo item : listResult){
				EndoModelProto.END1001U02GrdPaStatusInfo .Builder info = EndoModelProto.END1001U02GrdPaStatusInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addGrdpastatusItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}