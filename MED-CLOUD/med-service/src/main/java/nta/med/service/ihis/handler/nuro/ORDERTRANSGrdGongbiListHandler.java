package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp3018Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.dao.medi.out.Out1007Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;
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
public class ORDERTRANSGrdGongbiListHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdGongbiListRequest, NuroServiceProto.ORDERTRANSGrdGongbiListResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdGongbiListHandler.class);                                    
	@Resource                                                                                                       
	private Out0105Repository out0105Repository; 
	@Resource
	private Out1007Repository out1007Repository;
	@Resource
	private Inp3018Repository inp3018Repository;
	                                                                                                                

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdGongbiListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdGongbiListRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdGongbiListResponse.Builder response = NuroServiceProto.ORDERTRANSGrdGongbiListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Double out1001 = CommonUtils.parseDouble(request.getOut1001());
		List<ORDERTRANSGrdGongbiListInfo> listResult = new ArrayList<ORDERTRANSGrdGongbiListInfo>();
		if("O".equalsIgnoreCase(request.getIoGubun())){
			if("N".equalsIgnoreCase(request.getSendYn())){
				listResult = out0105Repository.getORDERTRANSGrdGongbiListInfoCaseEqualOAndN(hospCode, request.getBunho(), request.getOut1001(), language);
			}else {
				listResult = out1007Repository.getORDERTRANSGrdGongbiListInfoCaseEqualOAndElse(hospCode, request.getBunho(), out1001, language);
			}
		}else{
			if("N".equalsIgnoreCase(request.getSendYn())){
				listResult = out0105Repository.getORDERTRANSGrdGongbiListInfoCaseElseEqualN(hospCode, request.getBunho(), request.getOut1001(), language);
			}else{
				listResult = inp3018Repository.getORDERTRANSGrdGongbiListInfoCaseElseElse(hospCode, out1001, language);
			}
		}
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdGongbiListInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdGongbiListInfo.Builder info = NuroModelProto.ORDERTRANSGrdGongbiListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdGongbiItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}